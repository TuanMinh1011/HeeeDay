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
        //EventManager.Instance.AddListener<LandSelectedGameEvent>(LandSelectedChanged);
    }

    private void OnDisable()
    {
        //EventManager.Instance.RemoveListener<LandSelectedGameEvent>(LandSelectedChanged);
    }

    //private void LandSelectedChanged(LandSelectedGameEvent info)
    //{
    //    _land = info.Land;
    //    seedPanel.SetActive(true);

    //    tomatoSeedBtn.onClick.AddListener(() => { SetLandPlanted(PlantType.Tomato); });
    //    blueberrySeedBtn.onClick.AddListener(() => { SetLandPlanted(PlantType.Blueberry); });
    //    strawberrySeedBtn.onClick.AddListener(() => { SetLandPlanted(PlantType.Strawberry); });
    //    cowSeedBtn.onClick.AddListener(() => { SetLandPlanted(PlantType.Cow); });
    //}

    //private void SetLandPlanted(PlantType plantType)
    //{
    //    GameManager.Instance.SetLandPlated(_land, plantType);

    //    tomatoSeedBtn.onClick.RemoveAllListeners();
    //    blueberrySeedBtn.onClick.RemoveAllListeners();
    //    strawberrySeedBtn.onClick.RemoveAllListeners();
    //    cowSeedBtn.onClick.RemoveAllListeners();

    //    seedPanel.SetActive(false);
    //}
}
