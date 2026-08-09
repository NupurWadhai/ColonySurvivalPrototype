using UnityEngine;

public class ColonySimulationController : MonoBehaviour
{
    private const float SecondsPerGameDay = 1f;

    private ColonySimulation simulation;
    private float dayTimer;

    public int GameDay => simulation != null ? simulation.GameDay : 0;

    public int VillagerCount =>
        simulation != null ? simulation.VillagerCount : 0;

    public float FoodStored =>
        simulation != null ? simulation.FoodStored : 0f;

    public float WaterStored =>
        simulation != null ? simulation.WaterStored : 0f;

    public float FoodDaysRemaining =>
        simulation != null ? simulation.FoodDaysRemaining : 0f;

    public float WaterDaysRemaining =>
        simulation != null ? simulation.WaterDaysRemaining : 0f;

    public bool IsStarving =>
        simulation != null && simulation.IsStarving;


    private void Start()
    {
        PopulationConfig population =
            ConfigLoader.LoadPopulationConfig();

        ConsumptionConfig consumption =
            ConfigLoader.LoadConsumptionConfig();

        if (population == null || consumption == null)
        {
            Debug.LogError("Failed to load colony configuration.");
            return;
        }

        simulation = new ColonySimulation(
            population,
            consumption
        );

        dayTimer = 0f;

        Debug.Log("Colony simulation started.");
        LogSimulationState();
    }


    private void Update()
    {
        if (simulation == null)
            return;

        if (simulation.IsStarving)
            return;

        dayTimer += Time.deltaTime;

        while (dayTimer >= SecondsPerGameDay)
        {
            dayTimer -= SecondsPerGameDay;

            simulation.AdvanceOneDay();

            LogSimulationState();

            if (simulation.IsStarving)
            {
                Debug.LogWarning("COLONY STARVING!");
                break;
            }
        }
    }


    private void LogSimulationState()
    {
        Debug.Log(
            $"Day {simulation.GameDay} | " +
            $"Food: {simulation.FoodStored:F1} | " +
            $"Water: {simulation.WaterStored:F1} | " +
            $"Food Days: {simulation.FoodDaysRemaining:F1} | " +
            $"Water Days: {simulation.WaterDaysRemaining:F1}"
        );
    }
}