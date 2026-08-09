using UnityEngine;

public class ConfigLoaderTester : MonoBehaviour
{
    private void Start()
    {
        PopulationConfig population = ConfigLoader.LoadPopulationConfig();
        ConsumptionConfig consumption = ConfigLoader.LoadConsumptionConfig();

        if (population == null || consumption == null)
        {
            Debug.LogError("Failed to load configuration.");
            return;
        }

        Debug.Log(
            $"Population Loaded: {population.villagerCount} villagers, " +
            $"Food: {population.startingFood}, " +
            $"Water: {population.startingWater}"
        );

        Debug.Log(
            $"Consumption Loaded: " +
            $"Food: {consumption.foodPerVillagerPerDay}/villager/day, " +
            $"Water: {consumption.waterPerVillagerPerDay}/villager/day"
        );
    }
}