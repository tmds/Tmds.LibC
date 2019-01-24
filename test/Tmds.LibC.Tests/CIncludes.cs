namespace Tmds.LibC.Tests
{
    public class CIncludes
    {
        public string[] Headers { get; private set; }
        public bool GnuSource { get; private set; }

        public CIncludes(string header, bool gnuSource = false)
        {
            Headers = new string[] { header };
            GnuSource = gnuSource;
        }

        public CIncludes(string[] headers, bool gnuSource = false)
        {
            Headers = headers;
            GnuSource = gnuSource;
        }

        public static implicit operator CIncludes(string header)
        {
            return new CIncludes(header);
        }
    }
}