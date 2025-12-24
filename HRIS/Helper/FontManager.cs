using System;
using System.Drawing;
using System.Drawing.Text;
using System.IO;

namespace HRIS.Helper
{
    internal class FontManager
    {
        private static PrivateFontCollection _fontCollection;
        private static bool _loaded = false;

        public static void LoadFonts()
        {
            if (_loaded) return;

            _fontCollection = new PrivateFontCollection();

            string baseDir = AppDomain.CurrentDomain.BaseDirectory;
            string fontDir = Path.Combine(baseDir, "Fonts");

            string regular = Path.Combine(fontDir, "Poppins-Regular.ttf");
            string bold = Path.Combine(fontDir, "Poppins-Bold.ttf");
            string semiBold = Path.Combine(fontDir, "Poppins-SemiBold.ttf");

            if (!File.Exists(regular))
                throw new FileNotFoundException("Font tidak ditemukan: " + regular);

            _fontCollection.AddFontFile(regular);
            _fontCollection.AddFontFile(bold);
            _fontCollection.AddFontFile(semiBold);

            _loaded = true;
        }

        public static Font Regular(float size)
        {
            LoadFonts();
            return new Font(_fontCollection.Families[0], size, FontStyle.Regular);
        }

        public static Font Bold(float size)
        {
            LoadFonts();
            return new Font(_fontCollection.Families[0], size, FontStyle.Bold);
        }
    }
}
