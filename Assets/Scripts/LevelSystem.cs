using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelSystem : MonoBehaviour
{
    //private int xpNow;
    //private int level;
    //private int xpToNext;

    //[SerializeField] private GameObject levelPanel;
    //[SerializeField] private GameObject lvlWindowPrefab;

    //private Slider slider;
    //private TextMeshProUGUI xpText;
    [SerializeField] private TextMeshProUGUI lvlText;
    //private Image starImage;

    private static bool initialized = false;
    //private static Dictionary<int, int> xpToNextLevel = new Dictionary<int, int>();
    //private static Dictionary<int, int[]> levelReward = new Dictionary<int, int[]>();

    private void Awake()
    {
        //slider = levelPanel.GetComponent<Slider>();
        //xpText = levelPanel.transform.Find("XP text").GetComponent<TextMeshProUGUI>();
        //starImage = levelPanel.transform.Find("Star").GetComponent<Image>();
        //lvlText = levelPanel.transform.GetChild(0).GetComponent<TextMeshProUGUI>();

        if (!initialized)
        {
            Initialize();
        }

        //xpToNextLevel.TryGetValue(level, out xpToNext);
    }

    private void Start()
    {
        //EventManager.Instance.AddListener<XPAddedGameEvent>(OnXPAdded);
        EventManager.Instance.AddListener<LevelChangedGameEvent>(OnLevelChanged);

        UpdateUI();
    }

    private static void Initialize()
    {
        try
        {
            //string path = "levelsXP";

            //TextAsset textAsset = Resources.Load<TextAsset>(path);
            //string[] lines = textAsset.text.Split('\n');

            ////xpToNextLevel = new Dictionary<int, int>(lines.Length - 1);

            //for (int i = 1; i < lines.Length - 1; i++)
            //{
            //    string[] columns = lines[i].Split(',');

            //    int lvl = -1;
            //    int xp = -1;
            //    int curr1 = -1;
            //    int curr2 = -1;

            //    int.TryParse(columns[0], out lvl);
            //    int.TryParse(columns[1], out xp);
            //    int.TryParse(columns[2], out curr1);
            //    int.TryParse(columns[3], out curr2);

            //    if (lvl >= 0 && xp > 0)
            //    {
            //        //if (!xpToNextLevel.ContainsKey(lvl))
            //        //{
            //        //    xpToNextLevel.Add(lvl, xp);
            //        //    levelReward.Add(lvl, new[] {curr1, curr2});
            //        //}
            //    }
            //}

            //levelReward.Add(0, new[] { 0, 1 });
        }
        catch (Exception ex)
        {
            Debug.Log(ex.Message);
        }

        initialized = true;
    }

    private void UpdateUI()
    {
        //float fill = (float)xpNow / xpToNext;
        //slider.value = fill;
        //xpText.text = xpNow + "/" + xpToNext;
    }

    //private void OnXPAdded(XPAddedGameEvent info)
    //{
    //    xpNow += info.Amount;

    //    UpdateUI();

    //    if (xpNow >= xpToNext)
    //    {
    //        level++;
    //        LevelChangedGameEvent levelChange = new LevelChangedGameEvent(level);
    //        EventManager.Instance.QueueEvent(levelChange);
    //    }
    //}

    private void OnLevelChanged(LevelChangedGameEvent info)
    {
        //xpNow -= xpToNext;
        //xpToNext = xpToNextLevel[info.newLvl];
        info.newLvl = info.newLvl + 1;
        lvlText.text = (info.newLvl).ToString();

        UpdateUI();

        //GameObject window = Instantiate(lvlWindowPrefab, GameManager.current.canvas.transform);

        ////initialize texts and images here 

        //window.transform.GetChild(1).GetComponent<Button>().onClick.AddListener(delegate
        //{
        //    Destroy(window);
        //});

        //CurrencyChangeGameEvent 
        //currentInfo = new CurrencyChangeGameEvent(lvl, CurrencyType.Coin);
        //EventManager.Instance.QueueEvent(currentInfo);

        //LevelChangedGameEvent lvlinfo = new LevelChangedGameEvent(lvl);
        //EventManager.Instance.QueueEvent(info);

        Debug.Log("Whaatttttttt theeee heeelllellelelel");


        //currentInfo = new CurrencyChangeGameEvent(1, CurrencyType.Coin);
        //EventManager.Instance.QueueEvent(currentInfo);
    }
}
