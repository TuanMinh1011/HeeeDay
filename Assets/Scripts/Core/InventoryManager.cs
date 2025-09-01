using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI landSpaceText;
    [SerializeField] private TextMeshProUGUI landPlantedText;
    [SerializeField] private TextMeshProUGUI coinsText;
    [SerializeField] private List<TextMeshProUGUI> seedsTextList;

    private int landSpaceAmount = 0;
    private int landPlantedAmount = 0;
    private int coinsAmount = 0;
    private Dictionary<SeedType, TextMeshProUGUI> seedsText = new Dictionary<SeedType, TextMeshProUGUI>();
    private Dictionary<SeedType, int> seedsAmount = new Dictionary<SeedType, int>();

    private void OnEnable()
    {
        EventManager.Instance.AddListener<LoadDataGameEvent>(OnLoadData);
        EventManager.Instance.AddListener<LandSpaceChangedGameEvent>(OnLandSpanceChanged);
        EventManager.Instance.AddListener<LandPlantedSuccessGameEvent>(OnLandPlantedSuccessChanged);
        EventManager.Instance.AddListener<LandPlantedFailedGameEvent>(OnLandPlantedFaliedChanged);
        EventManager.Instance.AddListener<SeedChangedGameEvent>(OnSeedChanged);
    }

    //private void OnDisable()
    //{
    //    EventManager.Instance.RemoveListener<LoadDataGameEvent>(OnLoadData);
    //    EventManager.Instance.RemoveListener<LandSpaceChangedGameEvent>(OnLandSpanceChanged);
    //    EventManager.Instance.RemoveListener<LandPlantedSuccessGameEvent>(OnLandPlantedSuccessChanged);
    //    EventManager.Instance.RemoveListener<LandPlantedFailedGameEvent>(OnLandPlantedFaliedChanged);
    //}

    private void Awake()
    {
        for (int i = 0; i < seedsTextList.Count; i++)
        {
            seedsText.Add((SeedType)i, seedsTextList[i]);
            seedsAmount[(SeedType)i] = 0;
        }
    }

    private void UpdateUI()
    {
        landSpaceText.text = landSpaceAmount.ToString();
        landPlantedText.text = landPlantedAmount.ToString();
        coinsText.text = coinsAmount.ToString();

        for (int i = 0; i < seedsTextList.Count; i++)
        {
            seedsText[(SeedType)i].text = seedsAmount[(SeedType)i].ToString();
        }
    }

    private void OnLoadData(LoadDataGameEvent info)
    {
        landSpaceAmount = info.User.Lands.Count(x => !x.IsPlanted);
        landPlantedAmount = info.User.Lands.Count(x => x.IsPlanted);
        coinsAmount = info.User.Coins;
        seedsAmount = info.User.SeedUnused.ToDictionary(x => x.SeedType, x => x.Amount);

        UpdateUI();
    }

    private void OnLandSpanceChanged(LandSpaceChangedGameEvent info)
    {
        landSpaceAmount += info.Amount;

        landSpaceText.text = landSpaceAmount.ToString();
    }

    private void OnLandPlantedSuccessChanged(LandPlantedSuccessGameEvent info)
    {
        landPlantedAmount += info.Amount;
        landSpaceAmount -= info.Amount;

        landPlantedText.text = landPlantedAmount.ToString();
        landSpaceText.text = landSpaceAmount.ToString();
    }

    private void OnSeedChanged(SeedChangedGameEvent info)
    {
        seedsAmount[info.SeedType] += info.Amount;

        seedsText[info.SeedType].text = seedsAmount[info.SeedType].ToString();
    }

    private void OnLandPlantedFaliedChanged(LandPlantedFailedGameEvent info)
    {
        Debug.LogError("Failed to plant land: " + info.Reason);
    }
}
