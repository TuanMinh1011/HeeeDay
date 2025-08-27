using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelSystem : MonoBehaviour
{
    private int level;

    [SerializeField] private TextMeshProUGUI lvlText;

    private void Start()
    {
        EventManager.Instance.AddListener<LoadDataGameEvent>(OnLoadLevel);
        EventManager.Instance.AddListener<LevelChangedGameEvent>(OnLevelChanged);

        UpdateUI();
    }

    private void UpdateUI()
    {
        lvlText.text = (level).ToString();
    }

    private void OnLevelChanged(LevelChangedGameEvent info)
    {
        level += info.newLvl;
        UpdateUI();
    }

    private void OnLoadLevel(LoadDataGameEvent info)
    {
        level = info.User.Level;
        UpdateUI();
    }
}
