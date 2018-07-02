﻿#define SUPPRESS

using System;
using System.Collections.Generic;
using System.Linq;
using static PKHeX.Core.LegalityCheckStrings;

namespace PKHeX.Core
{
    /// <summary>
    /// Legality Check object containing the <see cref="CheckResult"/> data and overview values from the parse.
    /// </summary>
    public partial class LegalityAnalysis
    {
        internal readonly PKM pkm;
        private readonly bool Error;
        private readonly List<CheckResult> Parse = new List<CheckResult>();

        private IEncounterable EncounterOriginalGB;
        public IEncounterable EncounterMatch => Info.EncounterMatch;
        public IEncounterable EncounterOriginal => EncounterOriginalGB ?? EncounterMatch;

        public readonly bool Parsed;
        public readonly bool Valid;
        public readonly PersonalInfo PersonalInfo;
        public LegalInfo Info { get; private set; }
        public string Report(bool verbose = false) => verbose ? GetVerboseLegalityReport() : GetLegalityReport();
        private IEnumerable<int> AllSuggestedMoves
        {
            get
            {
                if (_allSuggestedMoves != null)
                    return _allSuggestedMoves;
                if (Error || Info == null)
                    return new int[4];
                return _allSuggestedMoves = GetSuggestedMoves(true, true, true);
            }
        }
        private IEnumerable<int> AllSuggestedRelearnMoves
        {
            get
            {
                if (_allSuggestedRelearnMoves != null)
                    return _allSuggestedRelearnMoves;
                if (Error || Info == null)
                    return new int[4];
                var gender = pkm.PersonalInfo.Gender;
                var inheritLvlMoves = gender > 0 && gender < 255 || Legal.MixedGenderBreeding.Contains(Info.EncounterMatch.Species);
                return _allSuggestedRelearnMoves = Legal.GetValidRelearn(pkm, Info.EncounterMatch.Species, inheritLvlMoves).ToArray();
            }
        }
        private int[] _allSuggestedMoves, _allSuggestedRelearnMoves;
        public int[] AllSuggestedMovesAndRelearn => AllSuggestedMoves.Concat(AllSuggestedRelearnMoves).ToArray();
        private string EncounterName
        {
            get
            {
                var enc = EncounterOriginal;
                return $"{enc.GetEncounterTypeName()} ({SpeciesStrings[enc.Species]})";
            }
        }
        private string EncounterLocation
        {
            get
            {
                var enc = EncounterOriginal as ILocation;
                return enc?.GetEncounterLocation(Info.Generation, pkm.Version);
            }
        }

        /// <summary>
        /// Checks the input <see cref="PKM"/> data for legality.
        /// </summary>
        /// <param name="pk">Input data to check</param>
        /// <param name="table"><see cref="SaveFile"/> specific personal data</param>
        public LegalityAnalysis(PKM pk, PersonalTable table = null)
        {
            pkm = pk;
#if SUPPRESS
            try
#endif
            {
                PersonalInfo = table?.GetFormeEntry(pkm.Species, pkm.AltForm) ?? pkm.PersonalInfo;
                ParseLegality();

                if (Parse.Count <= 0)
                    return;

                Valid = Parse.All(chk => chk.Valid)
                    && Info.Moves.All(m => m.Valid)
                    && Info.Relearn.All(m => m.Valid);

                if (pkm.FatefulEncounter && Info.Relearn.Any(chk => !chk.Valid) && EncounterMatch is EncounterInvalid)
                    AddLine(Severity.Indeterminate, V188, CheckIdentifier.Fateful);
            }
#if SUPPRESS
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
                Valid = false;
                AddLine(Severity.Invalid, V190, CheckIdentifier.Misc);
                Error = true;
            }
#endif
            Parsed = true;
        }
        private void ParseLegality()
        {
            if (!pkm.IsOriginValid)
                AddLine(Severity.Invalid, V187, CheckIdentifier.GameOrigin);

            if (pkm.Format == 1 || pkm.Format == 2) // prior to storing GameVersion
            {
                ParsePK1();
                return;
            }
            switch (pkm.GenNumber)
            {
                case 3: ParsePK3(); return;
                case 4: ParsePK4(); return;
                case 5: ParsePK5(); return;
                case 6: ParsePK6(); return;

                case 1: case 2:
                case 7: ParsePK7(); return;
            }
        }
        private void ParsePK1()
        {
            SetTradebackStatusInitial();
            UpdateInfo();
            SetTradebackStatusPost();
            Nickname.Verify(this);
            Level.Verify(this);
            Level.VerifyG1(this);
            Trainer.VerifyOTG1(this);
            Misc.VerifyMiscG1(this);
            if (pkm.Format == 2)
                Item.Verify(this);
        }
        private void ParsePK3()
        {
            UpdateInfo();
            UpdateChecks();
            if (pkm.Format > 3)
                Transfer.VerifyTransferLegalityG3(this);

            if (pkm.Version == (int)GameVersion.CXD)
                CXD.Verify(this);

            if (Info.EncounterMatch is WC3 z && z.NotDistributed)
                AddLine(Severity.Invalid, V413, CheckIdentifier.Encounter);
        }
        private void ParsePK4()
        {
            UpdateInfo();
            UpdateChecks();
            if (pkm.Format > 4)
                Transfer.VerifyTransferLegalityG4(this);
        }
        private void ParsePK5()
        {
            UpdateInfo();
            UpdateChecks();
            NHarmonia.Verify(this);
        }
        private void ParsePK6()
        {
            UpdateInfo();
            UpdateChecks();
        }
        private void ParsePK7()
        {
            UpdateInfo();
            if (pkm.VC)
                UpdateVCTransferInfo();
            UpdateChecks();
        }

        public void AddLine(Severity s, string c, CheckIdentifier i) => AddLine(new CheckResult(s, c, i));
        public void AddLine(CheckResult chk) => Parse.Add(chk);

        private void UpdateVCTransferInfo()
        {
            EncounterOriginalGB = EncounterMatch;
            if (EncounterOriginalGB is EncounterInvalid)
                return;
            Info.EncounterMatch = EncounterStaticGenerator.GetVCStaticTransferEncounter(pkm);
            if (!(Info.EncounterMatch is EncounterStatic s) || !EncounterStaticGenerator.IsVCStaticTransferEncounterValid(pkm, s))
            { AddLine(Severity.Invalid, V80, CheckIdentifier.Encounter); return; }

            foreach (var z in Transfer.VerifyVCEncounter(pkm, EncounterOriginalGB, s, Info.Moves))
                AddLine(z);
        }
        private void UpdateInfo()
        {
            Info = EncounterFinder.FindVerifiedEncounter(pkm);
            Parse.AddRange(Info.Parse);
        }
        private void SetTradebackStatusInitial()
        {
            if (pkm is PK1 pk1)
            {
                Legal.SetTradebackStatusRBY(pk1);
                return;
            }

            if (pkm.Format == 2 || pkm.VC2)
            {
                // Check for impossible tradeback scenarios
                bool g2only = !pkm.CanInhabitGen1();
                pkm.TradebackStatus = g2only ? TradebackType.Gen2_NotTradeback : TradebackType.Any;
                return;
            }

            // VC2 is released, we can assume it will be TradebackType.Any.
            // Is impossible to differentiate a VC1 pokemon traded to Gen7 after VC2 is available.
            // Met Date cannot be used definitively as the player can change their system clock.
            pkm.TradebackStatus = TradebackType.Any;
        }

        private void SetTradebackStatusPost()
        {
            // Example: GSC Pokemon with only possible encounters in RBY, like the legendary birds
            if (pkm.TradebackStatus == TradebackType.Any && Info.Generation != pkm.Format)
                pkm.TradebackStatus = TradebackType.WasTradeback;
        }
        private void UpdateChecks()
        {
            PIDEC.Verify(this);
            Nickname.Verify(this);
            Language.Verify(this);
            Trainer.Verify(this);
            IndividualValues.Verify(this);
            EffortValues.Verify(this);
            Level.Verify(this);
            Ribbon.Verify(this);
            Ability.Verify(this);
            Ball.Verify(this);
            Form.Verify(this);
            Misc.Verify(this);
            Gender.Verify(this);
            Item.Verify(this);
            if (pkm.Format <= 6 && pkm.Format >= 4)
                EncounterType.Verify(this); // Gen 6->7 transfer deletes encounter type data

            if (pkm.Format < 6)
                return;

            Memory.Verify(this);
            Medal.Verify(this);
            ConsoleRegion.Verify(this);

            if (pkm.Format >= 7)
            {
                HyperTraining.Verify(this);
                Misc.VerifyVersionEvolution(this);
            }
        }
        private string GetLegalityReport()
        {
            if (!Parsed || Info == null)
                return V189;

            var lines = new List<string>();
            var vMoves = Info.Moves;
            var vRelearn = Info.Relearn;
            for (int i = 0; i < 4; i++)
                if (!vMoves[i].Valid)
                    lines.Add(string.Format(V191, vMoves[i].Rating, i + 1, vMoves[i].Comment));

            if (pkm.Format >= 6)
            for (int i = 0; i < 4; i++)
                if (!vRelearn[i].Valid)
                    lines.Add(string.Format(V192, vRelearn[i].Rating, i + 1, vRelearn[i].Comment));

            if (lines.Count == 0 && Parse.All(chk => chk.Valid) && Valid)
                return V193;

            // Build result string...
            var outputLines = Parse.Where(chk => !chk.Valid); // Only invalid
            lines.AddRange(outputLines.Select(chk => string.Format(V196, chk.Rating, chk.Comment)));

            if (lines.Count == 0)
                return V190;

            return string.Join(Environment.NewLine, lines);
        }
        private string GetVerboseLegalityReport()
        {
            if (!Parsed || Info == null)
                return V189;

            const string separator = "===";
            string[] br = {separator, ""};
            var lines = new List<string> {br[1]};
            lines.AddRange(br);
            int rl = lines.Count;

            var vMoves = Info.Moves;
            var vRelearn = Info.Relearn;
            for (int i = 0; i < 4; i++)
                if (vMoves[i].Valid)
                    lines.Add(string.Format(V191, vMoves[i].Rating, i + 1, vMoves[i].Comment));

            if (pkm.Format >= 6)
            for (int i = 0; i < 4; i++)
                if (vRelearn[i].Valid)
                    lines.Add(string.Format(V192, vRelearn[i].Rating, i + 1, vRelearn[i].Comment));

            if (rl != lines.Count) // move info added, break for next section
                lines.Add(br[1]);

            var outputLines = Parse.Where(chk => chk?.Valid == true && chk.Comment != V).OrderBy(chk => chk.Judgement); // Fishy sorted to top
            lines.AddRange(outputLines.Select(chk => string.Format(V196, chk.Rating, chk.Comment)));

            lines.AddRange(br);
            lines.Add(string.Format(V195, EncounterName));
            var loc = EncounterLocation;
            if (!string.IsNullOrEmpty(loc))
                lines.Add(string.Format(V196, "Location", loc));
            if (pkm.VC)
                lines.Add(string.Format(V196, nameof(GameVersion), Info.Game));
            var pidiv = Info.PIDIV ?? MethodFinder.Analyze(pkm);
            if (pidiv != null)
            {
                if (!pidiv.NoSeed)
                    lines.Add(string.Format(V248, pidiv.OriginSeed.ToString("X8")));
                lines.Add(string.Format(V249, pidiv.Type));
            }
            if (!Valid && Info.InvalidMatches != null)
            {
                lines.Add("Other match(es):");
                lines.AddRange(Info.InvalidMatches.Select(z => $"{z.Name}: {z.Reason}"));
            }

            return GetLegalityReport() + string.Join(Environment.NewLine, lines);
        }

        // Suggestions
        public int[] GetSuggestedRelearn()
        {
            if (Info?.RelearnBase == null || Info.Generation < 6)
                return new int[4];

            if (!EncounterMatch.EggEncounter)
                return Info.RelearnBase;

            List<int> window = new List<int>(Info.RelearnBase.Where(z => z != 0));
            window.AddRange(pkm.Moves.Where((_, i) => !Info.Moves[i].Valid || Info.Moves[i].Flag));
            window = window.Distinct().ToList();
            int[] moves = new int[4];
            int start = Math.Max(0, window.Count - 4);
            int count = Math.Min(4, window.Count);
            window.CopyTo(start, moves, 0, count);
            return moves;
        }
        public int[] GetSuggestedMoves(bool tm, bool tutor, bool reminder)
        {
            if (!Parsed)
                return new int[4];
            if (pkm.IsEgg && pkm.Format <= 5) // pre relearn
                return Legal.GetBaseEggMoves(pkm, pkm.Species, (GameVersion)pkm.Version, pkm.CurrentLevel);
            if (!(tm || tutor || reminder) && (Info.Generation <= 2 || pkm.Species == EncounterOriginal.Species))
            {
                var lvl = Info.Generation <= 2 && pkm.Format >= 7 ? pkm.Met_Level : pkm.CurrentLevel;
                var ver = Info.Generation <= 2 && EncounterOriginal is IVersion v ? v.Version : (GameVersion)pkm.Version;
                return MoveLevelUp.GetEncounterMoves(pkm, lvl, ver);
            }
            var evos = Info.EvoChainsAllGens;
            return Legal.GetValidMoves(pkm, evos, Tutor: tutor, Machine: tm, MoveReminder: reminder).Skip(1).ToArray(); // skip move 0
        }
        public EncounterStatic GetSuggestedMetInfo() => EncounterSuggestion.GetSuggestedMetInfo(pkm);
    }
}
