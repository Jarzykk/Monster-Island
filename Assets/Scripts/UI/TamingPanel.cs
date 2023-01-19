using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TamingPanel : MonoBehaviour
{
    [SerializeField] private ParticleSystem _particleEffect;
    [SerializeField] private Transform _minionUiPosition;
    [SerializeField] private Vector3 _minionUiScale;
    [SerializeField] private string _uiLayerName;
    [SerializeField] private TMP_Text _minionsName;

    private Minion _minionToTame;
    private MonsterAnimations _animations;

    private void OnEnable()
    {
        if (_minionToTame != null)
            Destroy(_minionToTame);
        _minionToTame = null;
    }

    private void OnDisable()
    {
        Destroy(_minionToTame.gameObject);
    }

    public void StartElements(Minion miniomToTame)
    {
        CreateUiMinion(miniomToTame);
        SetMinionsName(_minionToTame.MinionsTypeName);
        _animations.Roar();
        _particleEffect.Play();
    }

    private void CreateUiMinion(Minion minion)
    {
        _minionToTame = Instantiate(minion, _minionUiPosition);
        _minionToTame.DisableComponentsForUI();
        SetMinionsLayersToUi(_minionToTame, _uiLayerName);
        _minionToTame.transform.localScale = _minionUiScale;
        _animations = minion.GetComponent<MonsterAnimations>();
    }

    private void SetMinionsName(string name)
    {
        _minionsName.text = name;
    }

    private void SetMinionsLayersToUi(Minion minion, string layername)
    {
        foreach (Transform childObject in minion.GetComponentsInChildren<Transform>(true))
        {
            childObject.gameObject.layer = LayerMask.NameToLayer(layername);
        }
    }
}
