using System;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class LandController : PlaceableObject
{
    public Land Land;

    public Action<Land> OnLandPlantedSelected;
    public Action<Land> OnLandSpaceSelected;
    public Action<Land> OnLandSwitchSelected;
    //public Action<int> OnLandUpdateLifeCircleSelected;

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
        //OnLandUpdateLifeCircleSelected += OnLandUpdateLifeCircle;

        //tomatoSeedBtn.onClick.AddListener(() => { SetLandPlanted(PlantType.Tomato); });
        //blueberrySeedBtn.onClick.AddListener(() => { SetLandPlanted(PlantType.Blueberry); });
        //strawberrySeedBtn.onClick.AddListener(() => { SetLandPlanted(PlantType.Strawberry); });
        //cowSeedBtn.onClick.AddListener(() => { SetLandPlanted(PlantType.Cow); });
    }

    private void OnMouseDown()
    {
        if (Land.IsPlanted)
        {
            TimerTooltip.ShowTimer_Static(gameObject);
        }
        else
        {
            LandSelectedGameEvent landSelectedGameEvent = new LandSelectedGameEvent(Land, OnLandPlantedSelected);
            EventManager.Instance.TriggerEvent(landSelectedGameEvent);
        }

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

        Land = _land;
    }

    private void OnLandSpaceSuccessChanged(Land _land)
    {
        spriteRenderer.sprite = landSprite;

        Land = _land;
    }

    private void OnLandPlantedSuccessChanged(Land _land)
    {
        Land = _land;

        switch (Land.PlantedWith.PlantType)
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

        Timer timer = gameObject.GetComponent<Timer>();

        if (timer == null)
        {
            timer = gameObject.AddComponent<Timer>();
        }

        timer.Initialize(Land.PlantedWith.Name, DateTime.Now, TimeSpan.FromSeconds(Land.PlantedWith.GrowthTime), Land.PlantedWith.NumbersInLifeCycle);
        timer.StartTimer();
        timer.TimerFinishEvent.AddListener(delegate
        {
            LandSwitchToLandSpaceGameEvent landSwitchToLandSpaceGameEvent = new LandSwitchToLandSpaceGameEvent(Land, OnLandSwitchSelected);
            EventManager.Instance.TriggerEvent(landSwitchToLandSpaceGameEvent);

            Destroy(timer);
        });
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

    public override void Place(bool isLoadData = false)
    {
        base.Place();

        if (isLoadData)
        {
            if (!Land.IsPlanted) return;

            Timer timer = gameObject.GetComponent<Timer>();
            if (timer == null)
            {
                timer = gameObject.AddComponent<Timer>();
            }

            double elapsed = GameManager.Instance.GetCurrentTimestamp() - Land.StartTime;
            double time = Land.PlantedWith.GrowthTime - elapsed;
            Debug.Log(TimeSpan.FromSeconds(time));
            timer.InitializeForLoadData(Land.PlantedWith.Name, DateTime.Now, TimeSpan.FromSeconds(time), Land.PlantedWith.CurrentCycle);
            timer.StartTimer();
            timer.TimerFinishEvent.AddListener(delegate
            {
                LandSwitchToLandSpaceGameEvent landSwitchToLandSpaceGameEvent = new LandSwitchToLandSpaceGameEvent(Land, OnLandSwitchSelected);
                EventManager.Instance.TriggerEvent(landSwitchToLandSpaceGameEvent);

                Destroy(timer);
            });
        }
        else
        {
            GameManager.Instance.SetLandSpace(1, OnLandSpaceSelected, transform.position);
        }
    }

    public void LoadDataLand(Land _land)
    {
        Land = _land;

        if (Land.IsPlanted)
        {
            OnLandPlantedSuccessChanged(Land);
        }
        else
        {
            OnLandSpaceSuccessChanged(Land);
        }

        Place(true);
    }

    private void OnLandUpdateLifeCircle(int lifeCircle)
    {
        EventManager.Instance.TriggerEvent(new LandUpdateLifeCircleGameEvent(Land, lifeCircle));
    }
}
