using UnityEngine;

public class SimulationTester : MonoBehaviour
{
    private ColonySimulation simulation;

    private void Start()
    {
        PopulationConfig population =
            ConfigLoader.LoadPopulationConfig();

        ConsumptionConfig consumption =
            ConfigLoader.LoadConsumptionConfig();

        if (population == null || consumption == null)
        {
            Debug.LogError("Failed to load configuration.");
            return;
        }

        simulation = new ColonySimulation(
            population,
            consumption
        );

        Debug.Log(
            $"Simulation started. " +
            $"Villagers: {simulation.VillagerCount}, " +
            $"Food: {simulation.FoodStored}, " +
            $"Water: {simulation.WaterStored}"
        );

        Debug.Log(
            $"Food days remaining: {simulation.FoodDaysRemaining}, " +
            $"Water days remaining: {simulation.WaterDaysRemaining}"
        );

        simulation.AdvanceOneDay();

        Debug.Log(
            $"After 1 day → " +
            $"Food: {simulation.FoodStored}, " +
            $"Water: {simulation.WaterStored}, " +
            $"Game Day: {simulation.GameDay}"
        );
    }
}