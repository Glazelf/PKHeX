namespace GlazePKMProgram.Core
{
    public interface ISecureValueStorage
    {
        ulong TimeStampPrevious { get; set; }
        ulong TimeStampCurrent { get; set; }
    }
}
