using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public User CurrentUser;
    public Plant[] Plants;
    private JsonManager jsonManager;

    private void Awake()
    {
        jsonManager = GetComponent<JsonManager>();
    }

    private void Start()
    {
        EventManager.Instance.AddListener<CurrencyChangeGameEvent>(OnCurrencyChange);
        EventManager.Instance.AddListener<LevelChangedGameEvent>(OnLevelChanged);
        EventManager.Instance.AddListener<EmployeeIdleChangedGameEvent>(OnEmployeeIdleChanged);
        EventManager.Instance.AddListener<EmployeeWorkingChangedGameEvent>(OnEmployeeWorkingChanged);
        EventManager.Instance.AddListener<SeedChangedGameEvent>(OnSeedChanged);
        EventManager.Instance.AddListener<FruitChangedGameEvent>(OnFruitChanged);
        EventManager.Instance.AddListener<LandSpaceChangedGameEvent>(OnLandSpaceChanged);
        EventManager.Instance.AddListener<LandPlatedChangedGameEvent>(OnLandPlatedChanged);
    }

    public void LoadDataUser()
    {
        CurrentUser = jsonManager.LoadUser();
        LoadDataGameEvent info = new LoadDataGameEvent(CurrentUser);
        EventManager.Instance.QueueEvent(info);
    }

    public void LoadDataPlant()
    {
        Plants = jsonManager.LoadPlants();
    }

    private void OnCurrencyChange(CurrencyChangeGameEvent info)
    {
        CurrentUser.Coins += info.Amount;
        jsonManager.SaveUser(CurrentUser);
    }

    private void OnLevelChanged(LevelChangedGameEvent info)
    {
        CurrentUser.Level += info.newLvl;
        jsonManager.SaveUser(CurrentUser);
    }

    private void OnEmployeeIdleChanged(EmployeeIdleChangedGameEvent info)
    {
        List<Employee> employees = CurrentUser.Employees.ToList();

        Employee newEmployee = new Employee()
        {
            Name = "Employee " + (employees.Count + 1),
            RentPrice = 500,
            TimeFinishWork = 120,
            IsWorking = false
        };
        employees.Add(newEmployee);

        CurrentUser.Employees = employees.ToArray();

        jsonManager.SaveUser(CurrentUser);
    }

    private void OnEmployeeWorkingChanged(EmployeeWorkingChangedGameEvent info)
    {
        Employee employee = CurrentUser.Employees.FirstOrDefault(x => !x.IsWorking);

        if (employee != null)
        {
            employee.IsWorking = true;

            EmployeeWorkingSuccessGameEvent success = new EmployeeWorkingSuccessGameEvent(1);
            EventManager.Instance.TriggerEvent(success);

            jsonManager.SaveUser(CurrentUser);
        }
        else
        {
            EmployeeWorkingFailedGameEvent failed = new EmployeeWorkingFailedGameEvent("No idle employee available.");
            EventManager.Instance.TriggerEvent(failed);
        }
    }

    private void OnSeedChanged(SeedChangedGameEvent info)
    {
        CurrentUser.SeedUnused.FirstOrDefault(x => x.SeedType == info.SeedType).Amount += info.Amount;

        jsonManager.SaveUser(CurrentUser);
    }

    private void OnFruitChanged(FruitChangedGameEvent info)
    {
        CurrentUser.FruitHarvest.FirstOrDefault(x => x.FruitType == info.FruitType).Amount += info.Amount;

        jsonManager.SaveUser(CurrentUser);
    }

    private void OnLandSpaceChanged(LandSpaceChangedGameEvent info)
    {
        List<Land> lands = CurrentUser.Lands.ToList();

        Land newLandSpace = new Land()
        {
            Name = "Land " + (lands.Count + 1),
            TimeToHarvest = 0,
            IsPlanted = false,
            PlantedWith = null
        };
        lands.Add(newLandSpace);

        CurrentUser.Lands = lands.ToArray();

        jsonManager.SaveUser(CurrentUser);
    }

    private void OnLandPlatedChanged(LandPlatedChangedGameEvent info)
    {
        Land landSpace = CurrentUser.Lands.FirstOrDefault(x => !x.IsPlanted);
        if (landSpace != null)
        {
            landSpace.IsPlanted = true;
            landSpace.PlantedWith = info.PlantedWith;
            landSpace.TimeToHarvest = info.PlantedWith.GrowthTime * info.PlantedWith.NumbersInLifeCycle;

            LandPlantedSuccessGameEvent success = new LandPlantedSuccessGameEvent(1);
            EventManager.Instance.TriggerEvent(success);

            jsonManager.SaveUser(CurrentUser);
        }
        else
        {
            LandPlantedFailedGameEvent failed = new LandPlantedFailedGameEvent("No available land to plant.");
            EventManager.Instance.TriggerEvent(failed);
        }
    }
}
