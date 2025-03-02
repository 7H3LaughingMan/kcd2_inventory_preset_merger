using System.Text;

public sealed class ASCIIStringWriter: StringWriter {
    public override Encoding Encoding => Encoding.ASCII;
}