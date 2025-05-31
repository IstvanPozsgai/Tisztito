using PdfSharp.Fonts;
using System.IO;

namespace Tisztito.Minden
{
    public class PDFhezBetû : IFontResolver
    {
        public string DefaultFontName => "Arial";

        public byte[] GetFont(string faceName)
        {
            // Betûtípus elérési útja a bin\Debug (vagy Release) mappában
            string fontPath = Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "Fonts", "arial.ttf");
            return File.ReadAllBytes(fontPath);
        }

        public FontResolverInfo ResolveTypeface(string familyName, bool isBold, bool isItalic)
        {
            if (familyName.Equals("Arial", System.StringComparison.OrdinalIgnoreCase))
            {
                return new FontResolverInfo("Arial");
            }
            return null;
        }


    }

}