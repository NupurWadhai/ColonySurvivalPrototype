using System.IO;
using UnityEngine;

public class ConfigLoader
{
    public static PopulationConfig LoadPopulationConfig()
    {
        string path = Path.Combine(Application.streamingAssetsPath, "population.json");

        if (!File.Exists(path))
        {
            Debug.LogError($"Population config not found at: {path}");
            return null;
        }

        string json = File.ReadAllText(path);
        PopulationConfig config = JsonUtility.FromJson<PopulationConfig>(json);

        return config;
    }

    public static ConsumptionConfig LoadConsumptionConfig()
    {
        string path = Path.Combine(Application.streamingAssetsPath, "consumption.json");

        if (!File.Exists(path))
        {
            Debug.LogError($"Consumption config not found at: {path}");
            return null;
        }

        string json = File.ReadAllText(path);
        ConsumptionConfig config = JsonUtility.FromJson<ConsumptionConfig>(json);

        return config;
    }
}