using UnityEngine;

public class ConfigManager : IConfigManager
{
    public Config config => _config;
    Config _config;

    public ConfigManager()
    {
        TextAsset jsonText = Resources.Load<TextAsset>("config");
        if (jsonText == null)
        {
            Debug.LogError("Файл не найден");
        }
        _config = JsonUtility.FromJson<Config>(jsonText.text);
    }
}
