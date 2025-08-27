using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class GameManager : MonoBehaviour
{
    public static GameManager current;

    public GameObject canvas;

    private DataManager dataManager;

    private void Awake()
    {
        current = this;

        dataManager = GetComponentInChildren<DataManager>();
    }

    private void Start()
    {
        dataManager.LoadDataUser();
    }

    public void GetLevel(int amount)
    {
        LevelChangedGameEvent info = new LevelChangedGameEvent(amount);
        EventManager.Instance.QueueEvent(info);
    }

    public void GetCoins(int amount)
    {
        CurrencyChangeGameEvent info = new CurrencyChangeGameEvent(amount, CurrencyType.Coin);
        EventManager.Instance.QueueEvent(info);
    }
}
