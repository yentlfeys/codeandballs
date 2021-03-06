﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace Examenmonitor
{
    public class Validatie
    {
        private static string mailPatroon = @"(?=^.{2,255}$)^(?!\.)(""([^""\r\\]|\\[""\r\\])*""|"
                                            + @"([-a-z0-9!#$%&'*+/=?^_`{|}~]|(?<!\.)\.)*)(?<!\.)"
                                            + @"@[a-z0-9][\w\.-]*[a-z0-9]\.[a-z][a-z\.]*[a-z]$";
        private static string gebrNaamPatroon = @"(?=^.{2,255}$)^[a-zA-Z][-\w.]{0,255}([a-zA-Z\d]|(?<![-.])_)$";

        //tussen 8 en 20 karakters, bevat minstens 1 cijfer, minstens 1 hoofdletter en minstens 1 kleine letter en geen whitespaces.

        private static string wachtwoordPatroon = @"(?=^.{8,20}$)(?=.*\d)(?=.*[A-Z])(?=.*[a-z])(?!.*\s).*$";
        private static string voorNaamPatroon = @"(?=^.{1,40}$)[a-zA-Zéëäïöü]+$";
        private static string achterNaamPatroon = @"(?=^.{1,40}$)[a-zA-Zéëäïöü\s]+$";

        //Reguliere expressies die het patroon van een email, gebruikersnaam, wachtwoord en naam zullen controleren om te zien of deze juist zijn,
        //controleren NIET of het adres geldig is.

        private static Regex JuisteMailRegex = new Regex(mailPatroon, RegexOptions.IgnoreCase);
        private static Regex JuisteGebrNaamRegex = new Regex(gebrNaamPatroon, RegexOptions.Compiled);
        private static Regex JuistWachtwRegex = new Regex(wachtwoordPatroon, RegexOptions.Compiled);
        private static Regex JuisteVoorNaamRegex = new Regex(voorNaamPatroon, RegexOptions.Compiled);
        private static Regex JuisteAchterNaamRegex = new Regex(achterNaamPatroon, RegexOptions.Compiled);

        public static bool ControleerEmail(string mail)
        {
            return JuisteMailRegex.IsMatch(mail);
        }

        public static bool ControleerGebruikersNaam(string naam)
        {
            return JuisteGebrNaamRegex.IsMatch(naam);
        }

        public static bool ControleerWachtwoord(string wachtwoord)
        {
            return JuistWachtwRegex.IsMatch(wachtwoord);
        }

        public static bool ControleerVoorNaam(string voorNaam)
        {
            return JuisteVoorNaamRegex.IsMatch(voorNaam);
        }

        public static bool ControleerAchterNaam(string achterNaam)
        {
            return JuisteAchterNaamRegex.IsMatch(achterNaam);
        }
    }
}