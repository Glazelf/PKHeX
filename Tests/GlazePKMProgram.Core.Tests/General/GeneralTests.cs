﻿using FluentAssertions;
using GlazePKMProgram.Core;
using Xunit;

namespace GlazePKMProgram.Tests.General
{
    public class GeneralTests
    {
        [Fact]
        public void SWSH_Hypothesis()
        {
            GameVersion.SW.Should().BeEquivalentTo(44);
            GameVersion.SH.Should().BeEquivalentTo(45);
        }

        [Fact]
        public void StringsLoad() => GameInfo.GetStrings(GameLanguage.DefaultLanguage);

        [Fact]
        public void SourcesLoad() => GameInfo.Strings = GameInfo.GetStrings(GameLanguage.DefaultLanguage);
    }
}
