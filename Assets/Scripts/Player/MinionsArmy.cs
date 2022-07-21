using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MinionsArmy : MonoBehaviour
{
    [SerializeField] private Transform _MinionsSpawnPosition;
    [SerializeField] private Minion _startingMinionTemplate;
    [SerializeField] private Player _player;

    private List<Minion> _minions = new List<Minion>();

    public event UnityAction<Minion> NewMinionAdded;
    public int MinionAmount => _minions.Count;

    private void Start()
    {
        AddMinionToArmy(_startingMinionTemplate);
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
        Minion spawnedMinion = Instantiate(minion, _MinionsSpawnPosition.position, Quaternion.identity);
        spawnedMinion.Init(_player);
        return spawnedMinion;
    }
}
