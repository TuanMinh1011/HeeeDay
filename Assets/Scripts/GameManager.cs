using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

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
    }

    public void GetLevel(int amount)
    {
        LevelChangedGameEvent info = new LevelChangedGameEvent(amount);
        EventManager.Instance.QueueEvent(info);
    }

    public void GetCoins(int amount)
    {
        CurrencyChangeGameEvent info = new CurrencyChangeGameEvent(amount);
        EventManager.Instance.QueueEvent(info);
    }

    public void GetIdle()
    {
        EmployeeChangedGameEvent info = new EmployeeChangedGameEvent(1, 0);
        EventManager.Instance.QueueEvent(info);
    }

    public void GetWorking()
    {
        EmployeeChangedGameEvent info = new EmployeeChangedGameEvent(0, 1);
        EventManager.Instance.QueueEvent(info);
    }

    public void GetSeedTomato()
    {
        SeedChangedGameEvent info = new SeedChangedGameEvent(1, SeedType.Tomato);
        EventManager.Instance.QueueEvent(info);
    }

    public void GetSeedCow()
    {
        SeedChangedGameEvent info = new SeedChangedGameEvent(1, SeedType.Cow);
        EventManager.Instance.QueueEvent(info);
    }

    public void GetFruitTomato()
    {
        FruitChangedGameEvent info = new FruitChangedGameEvent(1, FruitType.Tomato);
        EventManager.Instance.QueueEvent(info);
    }

    public void GetFruitMilk()
    {
        FruitChangedGameEvent info = new FruitChangedGameEvent(1, FruitType.Milk);
        EventManager.Instance.QueueEvent(info);
    }

    public void GetLandSpace()
    {
        LandSpaceChangedGameEvent info = new LandSpaceChangedGameEvent(1);
        EventManager.Instance.QueueEvent(info);
    }

    public void GetLandPlated()
    {
        Plant plant = new Plant()
        {
            Name = "Tomato",
            GrowthTime = 600,
            NumbersInLifeCycle = 40,
            SellPrice = 5
        };

        LandPlatedChangedGameEvent info = new LandPlatedChangedGameEvent(1, plant);
        EventManager.Instance.QueueEvent(info);
    }
}
