using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class FillingHeart : MonoBehaviour
{
    [SerializeField] private Image _fillingImage;
    [SerializeField] private HeartUI _heartUiComponent;
    [SerializeField] private float _duration;
    [SerializeField] private float _startFillAmount;
    [SerializeField] private float _targetFillAmount;

    public event UnityAction HeartFilled;

    private void Start()
    {
        _heartUiComponent.gameObject.SetActive(false);
    }

    public void FillHeart()
    {
        _fillingImage.fillAmount = _startFillAmount;
        _heartUiComponent.gameObject.SetActive(true);
        StartCoroutine(Fill());
    }

    private IEnumerator Fill()
    {
        float timeCount = 0;

        while(_fillingImage.fillAmount < _targetFillAmount)
        {
            _fillingImage.fillAmount = Mathf.Lerp(_startFillAmount, _targetFillAmount, timeCount / _duration);
            timeCount += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }

        HeartFilled?.Invoke();
        _heartUiComponent.gameObject.SetActive(false);
    }
}
