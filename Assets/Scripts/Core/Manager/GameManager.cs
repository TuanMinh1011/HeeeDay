using System;
using System.Linq;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private DataManager dataManager;

    [SerializeField] private GameObject plant;

    private void Awake()
    {
        Instance = this;

        dataManager = GetComponentInChildren<DataManager>();
    }

    private void Start()
    {
        dataManager.LoadDataUser();
        dataManager.LoadDataPlant();

        SetLandFromData();
    }
    public void SetLandSpace(int amount, Action<Land> OnLandSpaceSelected, Vector3 position)
    {
        LandSpaceChangedGameEvent info = new LandSpaceChangedGameEvent(amount, OnLandSpaceSelected, position);
        EventManager.Instance.QueueEvent(info);
    }

    public void SetLandPlated(Land land, PlantType plantType, Action<Land> onLandSelected)
    {
        Plant plant = dataManager.Plants.FirstOrDefault(x => x.PlantType == plantType);

        //Plant plant = new Plant()
        //{
        //    Name = "Tomato",
        //    GrowthTime = 600,
        //    NumbersInLifeCycle = 40,
        //    SellPrice = 5
        //};

        LandPlatedChangedGameEvent info = new LandPlatedChangedGameEvent(1, land, plant, onLandSelected);
        EventManager.Instance.QueueEvent(info);

        //SeedChangedGameEvent infoo = new SeedChangedGameEvent(-1, (SeedType)plantType);
        //EventManager.Instance.QueueEvent(infoo);
    }
        
    private void SetLandFromData()
    {
        var lands = dataManager.CurrentUser.Lands.ToList();

        if (lands.Count <= 0) return;

        foreach (Land land in lands)
        {
            BuildingSystem.Current.InitializeWithObjectFromData(plant, new Vector3(land.LandPos.x, land.LandPos.y, land.LandPos.z), land);

            Debug.Log("Land " + lands.Count);
        }
    }


    public double GetCurrentTimestamp()
    {
        return (DateTime.UtcNow - new DateTime(2000, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalSeconds;
    }

    #region Old Test
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
    #endregion
}
