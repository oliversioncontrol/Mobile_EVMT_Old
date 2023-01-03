using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnLocationEVMT.Controls
{
    /// <summary>
    /// Static Class Screen Height Width
    /// </summary>
   public static class ScreenHeightWidth
    {
        public static int ScreenWidth { get; set; }

        public static int ScreenHeight { get; set; }

        public static int CurrentSDKVersion { get; set; }

        public static string LastInstalledVersionName { get; set; }
        public static string LastInstalledVersionCode { get; set; }
        public static string OSVersion { get; set; }
        public static bool IsCheckApp { get; set; }
    }
}
