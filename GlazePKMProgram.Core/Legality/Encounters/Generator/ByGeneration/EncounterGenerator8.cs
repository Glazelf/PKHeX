﻿using System.Collections.Generic;

using static GlazePKMProgram.Core.MysteryGiftGenerator;
using static GlazePKMProgram.Core.EncounterTradeGenerator;
using static GlazePKMProgram.Core.EncounterSlotGenerator;
using static GlazePKMProgram.Core.EncounterStaticGenerator;
using static GlazePKMProgram.Core.EncounterEggGenerator;
using static GlazePKMProgram.Core.EncounterMatchRating;

namespace GlazePKMProgram.Core
{
    internal static class EncounterGenerator8
    {
        public static IEnumerable<IEncounterable> GetEncounters(PKM pkm)
        {
            var chain = EncounterOrigin.GetOriginChain(pkm);
            return pkm.Version switch
            {
                (int)GameVersion.GO => EncounterGenerator7.GetEncountersGO(pkm, chain),
                _ => GetEncountersMainline(pkm, chain),
            };
        }

        private static IEnumerable<IEncounterable> GetEncountersMainline(PKM pkm, IReadOnlyList<EvoCriteria> chain)
        {
            int ctr = 0;
            if (pkm.FatefulEncounter)
            {
                foreach (var z in GetValidGifts(pkm, chain))
                { yield return z; ++ctr; }
                if (ctr != 0) yield break;
            }

            if (Locations.IsEggLocationBred6(pkm.Egg_Location))
            {
                foreach (var z in GenerateEggs(pkm, 8))
                { yield return z; ++ctr; }
                if (ctr == 0) yield break;
            }

            IEncounterable? cache = null;
            EncounterMatchRating rating = None;

            // Trades
            if (pkm.Met_Location == Locations.LinkTrade6NPC)
            {
                foreach (var z in GetValidEncounterTrades(pkm, chain))
                {
                    var match = z.GetMatchRating(pkm);
                    if (match == Match)
                    {
                        yield return z;
                    }
                    else if (match < rating)
                    {
                        cache = z;
                        rating = match;
                    }
                }

                if (cache != null)
                    yield return cache;
                yield break;
            }

            // Static Encounters can collide with wild encounters (close match); don't break if a Static Encounter is yielded.
            var encs = GetValidStaticEncounter(pkm, chain);
            foreach (var z in encs)
            {
                var match = z.GetMatchRating(pkm);
                if (match == Match)
                {
                    yield return z;
                }
                else if (match < rating)
                {
                    cache = z;
                    rating = match;
                }
            }

            foreach (var z in GetValidWildEncounters(pkm, chain))
            {
                var match = z.GetMatchRating(pkm);
                if (match == Match)
                {
                    yield return z;
                }
                else if (match < rating)
                {
                    cache = z;
                    rating = match;
                }
            }

            if (cache != null)
                yield return cache;
        }
    }
}
