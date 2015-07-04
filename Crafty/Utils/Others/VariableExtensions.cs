﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Crafty
{
    public static class VariableExtensions
    {

        public static string ToYesNoString(this bool variable)
        {
            if (variable)
                return "yes";
            else
                return "no";
        }

        public static bool ToBoolean(this string variable)
        {
            if (variable == "yes")
                return true;
            else
                return false;
        }

    }
}