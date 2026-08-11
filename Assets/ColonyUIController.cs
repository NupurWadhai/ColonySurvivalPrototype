using TMPro;
using UnityEngine;

public class ColonyUIController : MonoBehaviour
{
    [Header("Simulation")]
    [SerializeField] private ColonySimulationController simulationController;

    [Header("UI")]
    [SerializeField] private TMP_Text gameDayText;
    [SerializeField] private TMP_Text villagerText;
    [SerializeField] private TMP_Text foodText;
    [SerializeField] private TMP_Text waterText;
    [SerializeField] private TMP_Text foodDaysText;
    [SerializeField] private TMP_Text waterDaysText;
    [SerializeField] private TMP_Text statusText;

    private void Update()
    {
        if (simulationController == null)
            return;

        gameDayText.text =
            $"Game Day: {simulationController.GameDay}";

        villagerText.text =
            $"Villagers: {simulationController.VillagerCount}";

        foodText.text =
            $"Food: {simulationController.FoodStored:F0}";

        waterText.text =
            $"Water: {simulationController.WaterStored:F0}";

        foodDaysText.text =
            $"Food Days Remaining: {simulationController.FoodDaysRemaining:F1}";

        waterDaysText.text =
            $"Water Days Remaining: {simulationController.WaterDaysRemaining:F1}";

        if (simulationController.IsStarving)
        {
            statusText.text = "STATUS: COLONY STARVING";
        }
        else
        {
            statusText.text = "STATUS: SURVIVING";
        }
    }
}