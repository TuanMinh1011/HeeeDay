using System;
using UnityEngine;
using UnityEngine.UI;

public class SeedUIManager : MonoBehaviour
{
    private Land _land;

    [SerializeField] private GameObject seedPanel;

    [Header("ButtonSeed")]
    [SerializeField] private Button tomatoSeedBtn;
    [SerializeField] private Button blueberrySeedBtn;
    [SerializeField] private Button strawberrySeedBtn;
    [SerializeField] private Button cowSeedBtn;

    private void Start()
    {
        seedPanel.SetActive(false);
    }

    private void OnEnable()
    {
        EventManager.Instance.AddListener<LandSelectedGameEvent>(LandSelectedChanged);
    }

    //private void OnDisable()
    //{
    //    EventManager.Instance.RemoveListener<LandSelectedGameEvent>(LandSelectedChanged);
    //}

    private void LandSelectedChanged(LandSelectedGameEvent info)
    {
        _land = info.Land;

        seedPanel.SetActive(true);

        tomatoSeedBtn.onClick.RemoveAllListeners();
        blueberrySeedBtn.onClick.RemoveAllListeners();
        strawberrySeedBtn.onClick.RemoveAllListeners();
        cowSeedBtn.onClick.RemoveAllListeners();

        tomatoSeedBtn.onClick.AddListener(() => { SetLandPlanted(PlantType.Tomato, info.OnLandSelected);});
        blueberrySeedBtn.onClick.AddListener(() => { SetLandPlanted(PlantType.Blueberry, info.OnLandSelected);});
        strawberrySeedBtn.onClick.AddListener(() => { SetLandPlanted(PlantType.Strawberry, info.OnLandSelected);});
        cowSeedBtn.onClick.AddListener(() => { SetLandPlanted(PlantType.Cow, info.OnLandSelected);});
    }

    private void SetLandPlanted(PlantType plantType, Action<Land> onLandSelected)
    {
        GameManager.Instance.SetLandPlated(_land, plantType, onLandSelected);

        seedPanel.SetActive(false);
    }
}
