using System.Linq;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager current;

    public GameObject canvas;

    private DataManager dataManager;

    private void Awake()
    {
        current = this;

        dataManager = GetComponentInChildren<DataManager>();
    }

    private void Start()
    {
        dataManager.LoadDataUser();
        dataManager.LoadDataPlant();
    }

    public void SetLevel(int amount)
    {
        LevelChangedGameEvent info = new LevelChangedGameEvent(amount);
        EventManager.Instance.QueueEvent(info);
    }

    public void SetCoins(int amount)
    {
        CurrencyChangeGameEvent info = new CurrencyChangeGameEvent(amount);
        EventManager.Instance.QueueEvent(info);
    }

    public void SetIdle(int amount)
    {
        EmployeeIdleChangedGameEvent info = new EmployeeIdleChangedGameEvent(amount);
        EventManager.Instance.QueueEvent(info);
    }

    public void SetWorking()
    {
        EmployeeWorkingChangedGameEvent info = new EmployeeWorkingChangedGameEvent();
        EventManager.Instance.QueueEvent(info);
    }

    public void SetSeedTomato(int amount)
    {
        SeedChangedGameEvent info = new SeedChangedGameEvent(amount, SeedType.Tomato);
        EventManager.Instance.QueueEvent(info);
    }

    public void SetSeedCow(int amount)
    {
        SeedChangedGameEvent info = new SeedChangedGameEvent(amount, SeedType.Cow);
        EventManager.Instance.QueueEvent(info);
    }

    public void SetFruitTomato(int amount)
    {
        FruitChangedGameEvent info = new FruitChangedGameEvent(amount, FruitType.Tomato);
        EventManager.Instance.QueueEvent(info);
    }

    public void SetFruitMilk(int amount)
    {
        FruitChangedGameEvent info = new FruitChangedGameEvent(amount, FruitType.Milk);
        EventManager.Instance.QueueEvent(info);
    }

    public void SetLandSpace(int amount)
    {
        LandSpaceChangedGameEvent info = new LandSpaceChangedGameEvent(amount);
        EventManager.Instance.QueueEvent(info);
    }

    public void SetLandPlated(int amount, PlantType plantType)
    {
        Plant plant = dataManager.Plants.FirstOrDefault(x => x.PlantType == plantType);

        //Plant plant = new Plant()
        //{
        //    Name = "Tomato",
        //    GrowthTime = 600,
        //    NumbersInLifeCycle = 40,
        //    SellPrice = 5
        //};

        LandPlatedChangedGameEvent info = new LandPlatedChangedGameEvent(amount, plant);
        EventManager.Instance.QueueEvent(info);
    }
}
