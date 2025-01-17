using System;

namespace GlazePKMProgram.Core
{
    /// <summary>
    /// Data representing info for an individual slot.
    /// </summary>
    public interface ISlotInfo : IEquatable<ISlotInfo>
    {
        /// <summary>
        /// Indicates the type of format the slot originates. Useful for legality purposes.
        /// </summary>
        SlotOrigin Origin { get; }

        /// <summary>
        /// Differentiating slot number from other infos of the same type.
        /// </summary>
        int Slot { get; }

        /// <summary>
        /// Indicates if this slot can write to the requested <see cref="sav"/>.
        /// </summary>
        /// <param name="sav">Save file to try writing to.</param>
        /// <returns>True if can write to</returns>
        bool CanWriteTo(SaveFile sav);

        /// <summary>
        /// Checks if the <see cref="pkm"/> can be written to the <see cref="sav"/> for this slot.
        /// </summary>
        /// <param name="sav">Save file to try writing to.</param>
        /// <param name="pkm">Entity data to try writing.</param>
        /// <returns>True if can write to</returns>
        WriteBlockedMessage CanWriteTo(SaveFile sav, PKM pkm);

        /// <summary>
        /// Tries writing the <see cref="pkm"/> to the <see cref="sav"/>.
        /// </summary>
        /// <param name="sav">Save file to try writing to.</param>
        /// <param name="pkm">Entity data to try writing.</param>
        /// <param name="setting">Setting to use when importing the <see cref="pkm"/> data</param>
        /// <returns>Returns false if it did not succeed.</returns>
        bool WriteTo(SaveFile sav, PKM pkm, PKMImportSetting setting = PKMImportSetting.UseDefault);
        PKM Read(SaveFile sav);
    }
}
