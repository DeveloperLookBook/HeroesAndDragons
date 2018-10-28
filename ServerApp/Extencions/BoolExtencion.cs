using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerApp.Extencions
{
    public static class BoolExtencion
    {
        /// <summary>
        /// Runs action if boolean value is True.
        /// </summary>
        /// <param name="value">Boolean value.</param>
        /// <param name="action">Action that must be done if boolean value is True.</param>
        public static void Then(this bool value, Action action)
        {
            if (value) { action(); }
        }
    }
}
