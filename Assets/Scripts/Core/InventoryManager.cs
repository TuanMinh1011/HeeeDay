using System.Linq;
using TMPro;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI landSpaceText;
    [SerializeField] private TextMeshProUGUI landPlantedText;

    private int landSpaceAmount = 0;
    private int landPlantedAmount = 0;

    private void OnEnable()
    {
        EventManager.Instance.AddListener<LoadDataGameEvent>(OnLoadData);
        EventManager.Instance.AddListener<LandSpaceChangedGameEvent>(OnLandSpanceChanged);
        EventManager.Instance.AddListener<LandPlantedSuccessGameEvent>(OnLandPlantedSuccessChanged);
        EventManager.Instance.AddListener<LandPlantedFailedGameEvent>(OnLandPlantedFaliedChanged);
    }

    //private void OnDisable()
    //{
    //    EventManager.Instance.RemoveListener<LoadDataGameEvent>(OnLoadData);
    //    EventManager.Instance.RemoveListener<LandSpaceChangedGameEvent>(OnLandSpanceChanged);
    //    EventManager.Instance.RemoveListener<LandPlantedSuccessGameEvent>(OnLandPlantedSuccessChanged);
    //    EventManager.Instance.RemoveListener<LandPlantedFailedGameEvent>(OnLandPlantedFaliedChanged);
    //}

    private void Start()
    {
        UpdateUI();
    }

    private void UpdateUI()
    {
        landSpaceText.text = landSpaceAmount.ToString();
        landPlantedText.text = landPlantedAmount.ToString();
    }

    private void OnLoadData(LoadDataGameEvent info)
    {
        landSpaceAmount = info.User.Lands.Count(x => !x.IsPlanted);
        landPlantedAmount = info.User.Lands.Count(x => x.IsPlanted);
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

    private void OnLandPlantedFaliedChanged(LandPlantedFailedGameEvent info)
    {
        Debug.LogError("Failed to plant land: " + info.Reason);
    }
}
