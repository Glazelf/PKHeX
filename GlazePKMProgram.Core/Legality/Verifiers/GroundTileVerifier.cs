﻿using static GlazePKMProgram.Core.LegalityCheckStrings;

namespace GlazePKMProgram.Core
{
    /// <summary>
    /// Verifies the <see cref="PK4.GroundTile"/>.
    /// </summary>
    public sealed class GroundTileVerifier : Verifier
    {
        protected override CheckIdentifier Identifier => CheckIdentifier.Encounter;

        public override void Verify(LegalityAnalysis data)
        {
            if (data.pkm is not IGroundTile e)
                return;
            var type = data.EncounterMatch is IGroundTypeTile t ? t.GroundTile : GroundTilePermission.None;
            var result = !type.Contains(e.GroundTile) ? GetInvalid(LEncTypeMismatch) : GetValid(LEncTypeMatch);
            data.AddLine(result);
        }
    }
}
