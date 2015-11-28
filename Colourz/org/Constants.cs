using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Colourz.org
{
    /// <summary>
    /// Contains all the constants
    /// </summary>
    public class Constants
    {
        /// <summary>
        /// The folder we are accessing
        /// </summary>
        public static string USER_DATA = Environment.ExpandEnvironmentVariables("%AppData%");

        /// <summary>
        /// The cache path
        /// </summary>
        public static string CACHE_PATH = System.IO.Path.Combine(USER_DATA, ".colourz\\");

    }
}
