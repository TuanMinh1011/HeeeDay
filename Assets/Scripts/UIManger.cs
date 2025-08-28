using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class UIManger : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI idle;
    [SerializeField] private TextMeshProUGUI working;
    //[SerializeField] private TextMeshProUGUI tomato;
    //[SerializeField] private TextMeshProUGUI cow;
    [SerializeField] private List<TextMeshProUGUI> seedsTextList;
    [SerializeField] private TextMeshProUGUI landSpace;
    [SerializeField] private TextMeshProUGUI landPlanted;
    //[SerializeField] private TextMeshProUGUI tomatoFruit;
    //[SerializeField] private TextMeshProUGUI milkFruit;
    [SerializeField] private List<TextMeshProUGUI> fruitsTextList;


    private int idleAmount = 0;
    private int workingAmount = 0;
    //private int tomatoAmount = 0;
    //private int cowAmount = 0;
    private int landSpaceAmount = 0;
    private int landPlantedAmount = 0;
    //private int tomatoFruitAmount = 0;
    //private int milkFruitAmount = 0;

    private Dictionary<SeedType, TextMeshProUGUI> seedsText = new Dictionary<SeedType, TextMeshProUGUI>();
    private Dictionary<SeedType, int> seedsAmount = new Dictionary<SeedType, int>();

    private Dictionary<FruitType, TextMeshProUGUI> fruitsText = new Dictionary<FruitType, TextMeshProUGUI>();
    private Dictionary<FruitType, int> fruitsAmount = new Dictionary<FruitType, int>();

    private void Start()
    {
        UpdateUI();

        EventManager.Instance.AddListener<LoadDataGameEvent>(OnLoadData);
        EventManager.Instance.AddListener<EmployeeChangedGameEvent>(OnEmployeeChanged);
        EventManager.Instance.AddListener<SeedChangedGameEvent>(OnSeedChanged);
        EventManager.Instance.AddListener<FruitChangedGameEvent>(OnFruitChanged);
        EventManager.Instance.AddListener<LandSpaceChangedGameEvent>(OnLandSpaceChanged);
        EventManager.Instance.AddListener<LandPlatedChangedGameEvent>(OnLandPlantedChanged);

        for (int i = 0; i < seedsTextList.Count; i++)
        {
            seedsText.Add((SeedType)i, seedsTextList[i]);
            seedsAmount[(SeedType)i] = 0;
        }

        for (int i = 0; i < fruitsTextList.Count; i++)
        {
            fruitsText.Add((FruitType)i, fruitsTextList[i]);
            fruitsAmount[(FruitType)i] = 0;
        }
    }

    private void OnLoadData(LoadDataGameEvent info)
    {
        idleAmount = info.User.EmployeesIdle;
        workingAmount = info.User.EmployeesWorking;
        landPlantedAmount = info.User.Lands.Count(x => x.IsPlanted);
        landSpaceAmount = info.User.Lands.Count(x => !x.IsPlanted);
        seedsAmount = info.User.SeedUnused.ToDictionary(x => x.SeedType, x => x.Amount);
        fruitsAmount = info.User.FruitHarvest.ToDictionary(x => x.FruitType, x => x.Amount);

        UpdateUI();
    }

    private void UpdateUI()
    {
        idle.text = idleAmount.ToString();
        working.text = workingAmount.ToString();
        //tomato.text = tomatoAmount.ToString();
        //cow.text = cowAmount.ToString();
        for (int i = 0; i < seedsText.Count; i++)
        {
            seedsText[(SeedType)i].text = seedsAmount[(SeedType)i].ToString();
        }
        landSpace.text = landSpaceAmount.ToString();
        landPlanted.text = landPlantedAmount.ToString();
        //tomatoFruit.text = tomatoFruitAmount.ToString();
        //milkFruit.text = milkFruitAmount.ToString();
        for (int i = 0; i < fruitsText.Count; i++)
        {
            fruitsText[(FruitType)i].text = fruitsAmount[(FruitType)i].ToString();
        }
    }

    private void OnEmployeeChanged(EmployeeChangedGameEvent info)
    {
        idleAmount += info.idle;
        workingAmount += info.working;

        UpdateUI();
    }

    private void OnSeedChanged(SeedChangedGameEvent info)
    {
        seedsAmount[info.SeedType] += info.Amount;

        UpdateUI();
    }

    private void OnFruitChanged(FruitChangedGameEvent info)
    {
        fruitsAmount[info.FruitType] += info.Amount;

        UpdateUI();
    }

    private void OnLandSpaceChanged(LandSpaceChangedGameEvent info)
    {
        landSpaceAmount += info.Amount;

        UpdateUI();
    }

    private void OnLandPlantedChanged(LandPlatedChangedGameEvent info)
    {
        landPlantedAmount += info.Amount;

        UpdateUI();
    }
}
