using NUnit.Framework;

public class ColonySimulationTests
{
    private PopulationConfig populationConfig;
    private ConsumptionConfig consumptionConfig;

    [SetUp]
    public void Setup()
    {
        populationConfig = new PopulationConfig
        {
            villagerCount = 10,
            startingFood = 1000,
            startingWater = 800
        };

        consumptionConfig = new ConsumptionConfig
        {
            foodPerVillagerPerDay = 10,
            waterPerVillagerPerDay = 8
        };
    }


    [Test]
    public void InitialState_IsLoadedCorrectly()
    {
        ColonySimulation simulation =
            new ColonySimulation(
                populationConfig,
                consumptionConfig
            );

        Assert.AreEqual(10, simulation.VillagerCount);
        Assert.AreEqual(1000f, simulation.FoodStored);
        Assert.AreEqual(800f, simulation.WaterStored);
        Assert.AreEqual(0, simulation.GameDay);
    }


    [Test]
    public void AdvanceOneDay_ConsumesCorrectResources()
    {
        ColonySimulation simulation =
            new ColonySimulation(
                populationConfig,
                consumptionConfig
            );

        simulation.AdvanceOneDay();

        Assert.AreEqual(900f, simulation.FoodStored);
        Assert.AreEqual(720f, simulation.WaterStored);
        Assert.AreEqual(1, simulation.GameDay);
    }


    [Test]
    public void DaysRemaining_IsCalculatedCorrectly()
    {
        ColonySimulation simulation =
            new ColonySimulation(
                populationConfig,
                consumptionConfig
            );

        Assert.AreEqual(10f, simulation.FoodDaysRemaining);
        Assert.AreEqual(10f, simulation.WaterDaysRemaining);

        simulation.AdvanceOneDay();

        Assert.AreEqual(9f, simulation.FoodDaysRemaining);
        Assert.AreEqual(9f, simulation.WaterDaysRemaining);
    }


    [Test]
    public void Starvation_IsTriggeredWhenResourcesReachZero()
    {
        ColonySimulation simulation =
            new ColonySimulation(
                populationConfig,
                consumptionConfig
            );

        for (int i = 0; i < 10; i++)
        {
            simulation.AdvanceOneDay();
        }

        Assert.AreEqual(0f, simulation.FoodStored);
        Assert.AreEqual(0f, simulation.WaterStored);
        Assert.IsTrue(simulation.IsStarving);
    }


    [Test]
    public void Simulation_DoesNotGoBelowZero()
    {
        ColonySimulation simulation =
            new ColonySimulation(
                populationConfig,
                consumptionConfig
            );

        for (int i = 0; i < 15; i++)
        {
            simulation.AdvanceOneDay();
        }

        Assert.AreEqual(0f, simulation.FoodStored);
        Assert.AreEqual(0f, simulation.WaterStored);
    }
}