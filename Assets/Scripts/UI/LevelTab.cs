using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LevelTab : MonoBehaviour
{
    [SerializeField] private TMP_Text _levelText;
    [SerializeField] private LevelSystem _levelSystem;

    private void OnEnable()
    {
        ResetTab();
        _levelSystem.LevelIncreased += OnLevelChanged;
    }

    private void OnDisable()
    {
        _levelSystem.LevelIncreased -= OnLevelChanged;
    }

    private void Start()
    {
        ResetTab();
    }

    private void OnLevelChanged()
    {
        ResetTab();
    }

    private void ResetTab()
    {
        _levelText.text = _levelSystem.CurrentLevel.ToString();
    }
}
