﻿using System.Linq;
using FluentAssertions;
using GlazePKMProgram.Core;
using Xunit;

namespace GlazePKMProgram.Tests.Legality
{
    public static class LearnabilityTests
    {
        [Theory]
        [InlineData(nameof(Species.Bulbasaur),  "Razor Leaf", "Vine Whip")]
        [InlineData(nameof(Species.Charizard), "Fly")]
        [InlineData(nameof(Species.Mew), "Pound")]
        [InlineData(nameof(Species.Smeargle), "Hyperspace Fury")]
        public static void VerifyCanLearn(string species, params string[] moves)
        {
            var encs = EncounterLearn.GetLearn(species, moves);
            encs.Any().Should().BeTrue($"{species} should be able to learn all moves: {string.Join(", ", moves)}");
        }

        [Theory]
        [InlineData(nameof(Species.Perrserker), "Swift")]
        [InlineData(nameof(Species.Perrserker), "Shock Wave")]
        [InlineData(nameof(Species.Sirfetchd), "False Swipe")]
        [InlineData(nameof(Species.Bulbasaur), "Fly")]
        [InlineData(nameof(Species.Charizard), "Bubble")]
        [InlineData(nameof(Species.Mew), "Struggle")]
        [InlineData(nameof(Species.Smeargle), "Chatter")]
        public static void VerifyCannotLearn(string species, params string[] moves)
        {
            var encs = EncounterLearn.GetLearn(species, moves);
            encs.Any().Should().BeFalse($"{species} should not be able to learn all moves: {string.Join(", ", moves)}");
        }

        [Theory]
        [InlineData(nameof(Species.Chansey), "Wish")]
        [InlineData("Ho-Oh", "Celebrate")]
        [InlineData(nameof(Species.Pikachu), "Happy Hour")]
        [InlineData(nameof(Species.Rayquaza), "V-Create")]
        public static void VerifyCanLearnSpecial(string species, params string[] moves)
        {
            var encs = EncounterLearn.GetLearn(species, moves);
            encs.Any().Should().BeTrue($"{species} should be able to learn all moves: {string.Join(", ", moves)}");
        }

        [Theory]
        [InlineData("flaBeBe", "pEtaL Dance")]
        public static void VerifyCanLearnParse(string species, params string[] moves)
        {
            var encs = EncounterLearn.GetLearn(species, moves);
            encs.Any().Should().BeTrue($"{species} should be able to learn all moves: {string.Join(", ", moves)}");
        }
    }
}
