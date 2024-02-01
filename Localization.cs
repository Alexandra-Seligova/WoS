using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json.Linq;

public class Localization
{
    private static Localization _instance;
    public static Localization Instance => _instance ?? (_instance = new Localization());

    private Dictionary<string, Dictionary<string, string>> localizationData;
    private string currentLanguage = "cz"; // Defaultní jazyk

    private Localization()
    {
        LoadLocalizationData();
    }

    private void LoadLocalizationData()
    {
        localizationData = new Dictionary<string, Dictionary<string, string>>();
        // Načíst data pro každý jazyk
        LoadLanguage("en");
        LoadLanguage("cz");
    }

    private void LoadLanguage(string language)
    {
        string path = $"{language}.json";
        //path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "WoS", $"{language}.json");

        string jsonContent = File.ReadAllText(path);
        JObject json = JObject.Parse(jsonContent);

        var languageData = new Dictionary<string, string>();
        foreach (var item in json)
        {
            languageData.Add(item.Key, item.Value.ToString());
        }

        localizationData[language] = languageData;
    }

    public void SetLanguage(string language)
    {
        if (localizationData.ContainsKey(language))
            currentLanguage = language;
    }

    public string GetText(string className, string variableName)
    {
        string key = $"{className}.{variableName}";
        if (localizationData[currentLanguage].TryGetValue(key, out string value))
            return value;

        return null; // Nebo vratit defaultní text nebo klíč
    }
}