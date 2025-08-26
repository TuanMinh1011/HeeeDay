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
    private static Dictionary<CurrencyType, int> currencyAmounts = new Dictionary<CurrencyType, int>();

    [SerializeField] private List<GameObject> texts;

    private Dictionary<CurrencyType, TextMeshProUGUI> currencyText = new Dictionary<CurrencyType, TextMeshProUGUI>();

    private void Awake()
    {
        for (int i = 0; i < texts.Count; i++)
        {
            currencyAmounts.Add((CurrencyType)i, 0);
            currencyText.Add((CurrencyType)i, texts[i].transform.GetComponent<TextMeshProUGUI>());
        }        
    }

    private void Start()
    {
        EventManager.Instance.AddListener<CurrencyChangeGameEvent>(OnCurrencyChange);
        EventManager.Instance.AddListener<NotEnoughCurrencyGameEvent>(OnNotEnough);
    }

    private void OnCurrencyChange(CurrencyChangeGameEvent info)
    {
        //todo save the currency
        currencyAmounts[info.CurrencyType] += info.Amount;
        currencyText[info.CurrencyType].text = currencyAmounts[info.CurrencyType].ToString();

        Debug.Log("Whaatttttttt");
    }

    private void OnNotEnough(NotEnoughCurrencyGameEvent info)
    {
        Debug.Log($"You don't have enough of {info.Amount} {info.CurrencyType}");
    }
}
