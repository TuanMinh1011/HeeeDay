using System;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class LandController : PlaceableObject
{
    private Land land;

    public Action<Land> OnLandPlantedSelected;
    public Action<Land> OnLandSpaceSelected;
    public Action<Land> OnLandSwitchSelected;

    [Header("Sprite")]
    [SerializeField] private Sprite landSprite;
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
        //EventManager.Instance.AddListener<LandSpaceSuccessGameEvent>(OnLandSpaceSuccessChanged);
        //EventManager.Instance.AddListener<LandPlantedSuccessGameEvent>(OnLandPlantedSuccessChanged);
        //EventManager.Instance.AddListener<LandSwitchToLandSpaceSuccessGameEvent>(OnSwitchItToLandSpace);
        OnLandSwitchSelected += OnSwitchSelected;
        OnLandPlantedSelected += OnLandPlantedSuccessChanged;
        OnLandSpaceSelected += OnLandSpaceSuccessChanged;

        //tomatoSeedBtn.onClick.AddListener(() => { SetLandPlanted(PlantType.Tomato); });
        //blueberrySeedBtn.onClick.AddListener(() => { SetLandPlanted(PlantType.Blueberry); });
        //strawberrySeedBtn.onClick.AddListener(() => { SetLandPlanted(PlantType.Strawberry); });
        //cowSeedBtn.onClick.AddListener(() => { SetLandPlanted(PlantType.Cow); });
    }

    private void OnMouseDown()
    {
        if (land.IsPlanted)
        {
            Timer timer = gameObject.GetComponent<Timer>();
            if (timer == null)
            {
                timer = gameObject.AddComponent<Timer>();
                timer.Initialize(land.PlantedWith.Name, DateTime.Now, TimeSpan.FromSeconds(land.PlantedWith.GrowthTime), land.PlantedWith.NumbersInLifeCycle);
                timer.StartTimer();
                timer.TimerFinishEvent.AddListener(delegate
                {
                    LandSwitchToLandSpaceGameEvent landSwitchToLandSpaceGameEvent = new LandSwitchToLandSpaceGameEvent(land, OnLandSwitchSelected);
                    EventManager.Instance.TriggerEvent(landSwitchToLandSpaceGameEvent);

                    Destroy(timer);
                });
            }

            TimerTooltip.ShowTimer_Static(gameObject);
        }
        else
        {
            LandSelectedGameEvent landSelectedGameEvent = new LandSelectedGameEvent(land, OnLandPlantedSelected);
            EventManager.Instance.TriggerEvent(landSelectedGameEvent);
        }

        Debug.Log("IsPlanteddddddd: " + land.IsPlanted);

        //isPlanted = true;
        //spriteRenderer.sprite = tomatoSprite;
        //GameManager.Instance.SetLandPlated(1, PlantType.Tomato);
        //UIManager.Instance.ShowSeedUI(true, this);
    }

    //private void OnSwitchItToLandSpace(LandSwitchToLandSpaceSuccessGameEvent info)
    //{
    //    spriteRenderer.sprite = landSprite;

    //    land = info.Land;
    //}

    private void OnSwitchSelected(Land _land)
    {
        spriteRenderer.sprite = landSprite;

        land = _land;
    }

    private void OnLandSpaceSuccessChanged(Land _land)
    {
        land = _land;
    }

    private void OnLandPlantedSuccessChanged(Land _land)
    {
        land = _land;

        switch (land.PlantedWith.PlantType)
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
                spriteRenderer.sprite = landSprite;
                break;
        }
    }

    //private void OnLandPlantedSuccessChanged(LandPlantedSuccessGameEvent info)
    //{
    //    switch (info.Land.PlantedWith.PlantType)
    //    {
    //        case PlantType.Tomato:
    //            spriteRenderer.sprite = tomatoSprite;
    //            break;
    //        case PlantType.Blueberry:
    //            spriteRenderer.sprite = blueberrySprite;
    //            break;
    //        case PlantType.Strawberry:
    //            spriteRenderer.sprite = strawberrySprite;
    //            break;
    //        case PlantType.Cow:
    //            spriteRenderer.sprite = cowSprite;
    //            break;
    //        default:
    //            spriteRenderer.sprite = landSprite;
    //            break;
    //    }
    //}

    public override void Place()
    {
        base.Place();

        GameManager.Instance.SetLandSpace(1, OnLandSpaceSelected);
    }
}
