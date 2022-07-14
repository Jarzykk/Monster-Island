using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MinionsArmy : MonoBehaviour
{
    [SerializeField] private Transform _MinionsSpawnPosition;
    [SerializeField] private GameObject _startingMinionTemplate;

    private List<Minion> _minions = new List<Minion>();

    public event UnityAction<Minion> NewMinionAdded;
    public int MinionAmount => _minions.Count;

    private void Start()
    {
        if (_startingMinionTemplate.TryGetComponent<Minion>(out Minion startingMinion))
            AddMinionToArmy(startingMinion);
    }

    public void AddMinionToArmy(Minion minion)
    {
        Minion spawnedMinion = SpawnMinion(minion);
        _minions.Add(spawnedMinion);
        NewMinionAdded?.Invoke(spawnedMinion);
    }

    public Minion GetRandomMinion()
    {
        int randomMinionInderx = Random.Range(0, _minions.Count);
        return _minions[randomMinionInderx];
    }

    private Minion SpawnMinion(Minion minion)
    {
        return Instantiate(minion, _MinionsSpawnPosition.position, Quaternion.identity);
    }
}
