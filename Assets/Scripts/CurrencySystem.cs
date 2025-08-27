using System.Collections.Generic;
using TMPro;
using UnityEngine;
public enum CurrencyType
{
    Coin,
    Crystals
}

public class CurrencySystem : MonoBehaviour
{
    private int totalCoins = 0;

    [SerializeField] private TextMeshProUGUI coinsText;

    private void Start()
    {
        UpdateUI();

        EventManager.Instance.AddListener<LoadDataGameEvent>(OnLoadCurrency);
        EventManager.Instance.AddListener<CurrencyChangeGameEvent>(OnCurrencyChange);
        EventManager.Instance.AddListener<NotEnoughCurrencyGameEvent>(OnNotEnough);
    }

    private void UpdateUI()
    {
        coinsText.text = totalCoins.ToString();
    }

    private void OnLoadCurrency(LoadDataGameEvent info)
    {
        totalCoins = info.User.Coins;
        UpdateUI();
    }

    private void OnCurrencyChange(CurrencyChangeGameEvent info)
    {
        //todo save the currency
        totalCoins += info.Amount;
        UpdateUI();
    }

    private void OnNotEnough(NotEnoughCurrencyGameEvent info)
    {
        Debug.Log($"You don't have enough of {info.Amount} {info.CurrencyType}");
    }
}
