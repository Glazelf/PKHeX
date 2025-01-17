﻿using System.Collections.Generic;

namespace GlazePKMProgram.Core
{
    internal sealed class LearnInfo
    {
        public bool MixedGen12NonTradeback { get; set; }
        public List<int> Gen1Moves { get; } = new();
        public List<int> Gen2PreevoMoves { get; } = new();
        public List<int> EggMovesLearned { get; } = new();
        public List<int> LevelUpEggMoves { get; } = new();
        public List<int> EventEggMoves { get; } = new();

        public readonly MoveParseSource Source;
        public readonly bool IsGen2Pkm;

        public LearnInfo(PKM pkm, MoveParseSource source)
        {
            IsGen2Pkm = pkm.Format == 2 || pkm.VC2;
            Source = source;
        }
    }

    public readonly struct LearnVersion
    {
        public readonly GameVersion Game;
        public readonly int Level;

        public LearnVersion(int lv, GameVersion game = GameVersion.Any)
        {
            Game = game;
            Level = lv;
        }

        public bool IsLevelUp => Level >= 0;
        public bool Equals(LearnVersion v) => v.Game == Game && v.Level == Level;

        public override bool Equals(object obj) => obj is LearnVersion v && Equals(v);
        public override int GetHashCode() => -1;
        public static bool operator ==(LearnVersion left, LearnVersion right) => left.Equals(right);
        public static bool operator !=(LearnVersion left, LearnVersion right) => !(left == right);
    }
}
