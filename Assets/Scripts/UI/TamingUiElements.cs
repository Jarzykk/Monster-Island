using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TamingUiElements : MonoBehaviour
{
    [SerializeField] private FillingHeart _fillingHeart;
    [SerializeField] private TamingPanel _tamingElements;

    private Minion _minionTemplateToTame;

    public event UnityAction SpawnButtonPressed;

    private void OnEnable()
    {
        _fillingHeart.HeartFilled += OnHeartFilled;
    }

    private void OnDisable()
    {
        _fillingHeart.HeartFilled -= OnHeartFilled;
    }

    public void StartTamingUi(Minion minionToTameTemplate)
    {
        _minionTemplateToTame = minionToTameTemplate;
        _fillingHeart.FillHeart();
    }

    public void OnSpawnButtonPressed()
    {
        _tamingElements.gameObject.SetActive(false);
        SpawnButtonPressed?.Invoke();
    }

    private void OnHeartFilled()
    {
        _tamingElements.gameObject.SetActive(true);
        _tamingElements.StartElements(_minionTemplateToTame);
    }
}
