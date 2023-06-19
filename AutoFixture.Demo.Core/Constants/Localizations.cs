// ReSharper disable MemberCanBePrivate.Global

using System.Reflection;

namespace AutoFixture.Demo.Core.Constants;

public static class Localizations
{
    public const string Afrikaans = "af_ZA";
    public const string Arabic = "Ar";
    public const string Azerbaijani = "az";
    public const string Czech = "cz";
    public const string German  = "de";
    public const string GermanAustria  = "de_AT";
    public const string GermanSwitzerland  = "de_CH";
    public const string Greek  = "el";
    public const string English  = "en";
    public const string EnglishAustralia = "en_AU";
    public const string EnglishAustraliaOcker = "en_AU_ocker";
    public const string EnglishBork  = "en_BORK";
    public const string EnglishCanada  = "en_CA";
    public const string EnglishGreatBritain  = "en_GB";
    public const string EnglishIreland  = "en_IE";
    public const string EnglishIndia  = "en_IND";
    public const string EnglishNigeria  = "en_NG"; 
    public const string EnglishUnitedStates  = "en_US";
    public const string EnglishSouthAfrica  = "en_ZA";
    public const string Spanish  = "es"; 
    public const string SpanishMexico  = "es_MX";
    public const string Farsi  = "fa";
    public const string Finnish  = "fi";
    public const string French  = "fr";
    public const string FrenchCanada  = "fr_CA";
    public const string FrenchSwitzerland  = "fr_CH";
    public const string Georgian  = "ge";
    public const string Hrvatski = "hr";
    public const string Indonesia  = "id_ID";
    public const string Italian  = "it";
    public const string Japanese  = "ja";
    public const string Korean  = "ko";
    public const string Latvian  = "lv";
    public const string Norwegian  = "nb_NO";
    public const string Nepalese  = "ne";
    public const string Dutch  = "nl";
    public const string DutchBelgium  = "nl_BE";
    public const string Polish  = "pl";
    public const string PortugueseBrazil  = "pt_BR";
    public const string PortuguesePortugal = "pt_PT";
    public const string Romanian  = "ro";
    public const string Russian  = "ru";
    public const string Slovakian  = "sk";
    public const string Swedish  = "sv";
    public const string Turkish  = "tr";
    public const string Ukrainian = "uk";
    public const string Vietnamese  = "vi";
    public const string Chinese  = "zh_CN";
    public const string ChineseTaiwan  = "zh_TW";
    public const string ZuluSouthAfrica  = "zu_ZA";

    // Do not change: This is for reference
    public const string DefaultFallbackLocalization = English;
    
    // Change if and as needed
    public const string DefaultLocalization = German;

    #region -- Utility Methods -- 

    private static List<string> _allLocalizations = new();

    public static IReadOnlyList<string> GetAllLocalizations()
    {
        if (_allLocalizations.Count != 0)
            return _allLocalizations;

        _allLocalizations =  typeof(Localizations)
            .GetFields(BindingFlags.Public | BindingFlags.Static)
            .Where(f => f.FieldType == typeof(string))
            .Select(f => (string)f.GetValue(string.Empty)! ?? string.Empty)
            .ToList();

        return _allLocalizations;
    }

    #endregion
}

 