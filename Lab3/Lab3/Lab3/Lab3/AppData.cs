using System;
using System.Collections.Generic;
using System.Text;

namespace Lab3
{
    public static class AppData
    {
        public static Student CurrentStudent { get; set; }
        public static Student SelectedStudent { get; set; }

        public static bool LanguageChanged = false;
        public static bool GallaryOpen = false; 
    }
}
