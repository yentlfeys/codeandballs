﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace Examenmonitor
{
    public class Validatie
    {
        private static Regex JuisteMailRegex = MaakJuisteEmailRegex();

        private static Regex MaakJuisteEmailRegex()
        {
            string mailPatroon = @"^(?!\.)(""([^""\r\\]|\\[""\r\\])*""|"
                + @"([-a-z0-9!#$%&'*+/=?^_`{|}~]|(?<!\.)\.)*)(?<!\.)"
                + @"@[a-z0-9][\w\.-]*[a-z0-9]\.[a-z][a-z\.]*[a-z]$";

            return new Regex(mailPatroon, RegexOptions.IgnoreCase);
        }

        public static bool Email(string mail)
        {
            return JuisteMailRegex.IsMatch(mail);
        }
    }
}