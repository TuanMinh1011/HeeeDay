using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LandController : MonoBehaviour
{
    private Land land;

    [Header("Sprite")]
    [SerializeField] private Sprite tomatoSprite;
    [SerializeField] private Sprite blueberrySprite;
    [SerializeField] private Sprite strawberrySprite;
    [SerializeField] private Sprite cowSprite;

    //[Header("ButtonSeed")]
    //[SerializeField] private Button tomatoSeedBtn;
    //[SerializeField] private Button blueberrySeedBtn;
    //[SerializeField] private Button strawberrySeedBtn;
    //[SerializeField] private Button cowSeedBtn;

    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    private void Start()
    {
        EventManager.Instance.AddListener<LandSpaceSuccessGameEvent>(OnLandSpaceSuccessChanged);
        EventManager.Instance.AddListener<LandPlantedSuccessGameEvent>(OnLandPlantedSuccessChanged);

        //tomatoSeedBtn.onClick.AddListener(() => { SetLandPlanted(PlantType.Tomato); });
        //blueberrySeedBtn.onClick.AddListener(() => { SetLandPlanted(PlantType.Blueberry); });
        //strawberrySeedBtn.onClick.AddListener(() => { SetLandPlanted(PlantType.Strawberry); });
        //cowSeedBtn.onClick.AddListener(() => { SetLandPlanted(PlantType.Cow); });
    }

    private void OnMouseDown()
    {
        if (land.IsPlanted) return;

        //isPlanted = true;
        //spriteRenderer.sprite = tomatoSprite;
        //GameManager.Instance.SetLandPlated(1, PlantType.Tomato);
        //UIManager.Instance.ShowSeedUI(true, this);

        LandSelectedGameEvent landSelectedGameEvent = new LandSelectedGameEvent(land);
        EventManager.Instance.TriggerEvent(landSelectedGameEvent);
    }

    private void OnLandSpaceSuccessChanged(LandSpaceSuccessGameEvent info)
    {
        land = info.Land;
    }

    private void OnLandPlantedSuccessChanged(LandPlantedSuccessGameEvent info)
    {
        switch (info.Land.PlantedWith.PlantType)
        {
            case PlantType.Tomato:
                spriteRenderer.sprite = tomatoSprite;
                break;
            case PlantType.Blueberry:
                spriteRenderer.sprite = blueberrySprite;
                break;
            case PlantType.Strawberry:
                spriteRenderer.sprite = strawberrySprite;
                break;
            case PlantType.Cow:
                spriteRenderer.sprite = cowSprite;
                break;
            default:
                break;
        }
    }
}
