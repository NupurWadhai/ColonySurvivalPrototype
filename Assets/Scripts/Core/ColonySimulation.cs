using System;

public class ColonySimulation
{
    private readonly int villagerCount;
    private readonly float dailyFoodConsumption;
    private readonly float dailyWaterConsumption;

    private float foodStored;
    private float waterStored;

    private int gameDay;

    public int VillagerCount => villagerCount;
    public float FoodStored => foodStored;
    public float WaterStored => waterStored;
    public int GameDay => gameDay;

    public float FoodDaysRemaining
    {
        get
        {
            if (dailyFoodConsumption <= 0f)
                return float.PositiveInfinity;

            return foodStored / dailyFoodConsumption;
        }
    }

    public float WaterDaysRemaining
    {
        get
        {
            if (dailyWaterConsumption <= 0f)
                return float.PositiveInfinity;

            return waterStored / dailyWaterConsumption;
        }
    }

    public bool IsStarving
    {
        get
        {
            return foodStored <= 0f || waterStored <= 0f;
        }
    }

    public ColonySimulation(
        PopulationConfig populationConfig,
        ConsumptionConfig consumptionConfig)
    {
        if (populationConfig == null)
            throw new ArgumentNullException(nameof(populationConfig));

        if (consumptionConfig == null)
            throw new ArgumentNullException(nameof(consumptionConfig));

        villagerCount = populationConfig.villagerCount;

        foodStored = populationConfig.startingFood;
        waterStored = populationConfig.startingWater;

        dailyFoodConsumption =
            villagerCount * consumptionConfig.foodPerVillagerPerDay;

        dailyWaterConsumption =
            villagerCount * consumptionConfig.waterPerVillagerPerDay;

        gameDay = 0;
    }

    public void AdvanceOneDay()
    {
        if (IsStarving)
            return;

        foodStored -= dailyFoodConsumption;
        waterStored -= dailyWaterConsumption;

        foodStored = Math.Max(0f, foodStored);
        waterStored = Math.Max(0f, waterStored);

        gameDay++;
    }
}