using UnityEngine;

public class DataManager : MonoBehaviour
{
    public User CurrentUser;
    private JsonManager jsonManager;

    private void Awake()
    {
        jsonManager = GetComponent<JsonManager>();
    }

    private void Start()
    {
        EventManager.Instance.AddListener<CurrencyChangeGameEvent>(OnCurrencyChange);
        EventManager.Instance.AddListener<LevelChangedGameEvent>(OnLevelChanged);
    }

    public void LoadDataUser()
    {
        CurrentUser = jsonManager.LoadUser();
        LoadDataGameEvent info = new LoadDataGameEvent(CurrentUser);
        EventManager.Instance.QueueEvent(info);
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
}
