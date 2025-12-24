using System;
using System.IO;

namespace HRIS.Helper
{
    public static class PhotoHelper
    {
        public static string PhotoUserFolder
        {
            get
            {
                string projectRoot = Path.GetFullPath(
                    Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..")
                );

                string folder = Path.Combine(projectRoot, "Resources", "PhotoUser");

                if (!Directory.Exists(folder))
                    Directory.CreateDirectory(folder);

                return folder;
            }
        }

        public static string GetPhotoPath(string fileName)
        {
            return Path.Combine(PhotoUserFolder, fileName);
        }
    }
}
