using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Health))]
public abstract class Monster : MonoBehaviour, IDamageble
{
    [SerializeField] private int _damage;
    [SerializeField] private MonsterTargetSystem _targetSystem;
    [SerializeField] private int _experienceForKilling;

    private Health _health;
    private int _currentLevel;

    public int ExperienceForKilling => _experienceForKilling;
    public Monster CurrentTarget => _targetSystem.Target;
    public int CurrentHealth => _health.CurrentHealth;

    public event UnityAction EnteredBattleState;
    public event UnityAction LeftBattleState;
    public event UnityAction Died;

    public int Damage => _damage;

    private void Awake()
    {
        _health = GetComponent<Health>();
    }

    private void OnEnable()
    {
        _health.MinValueReached += OnDeath;
        _targetSystem.TargetWasSet += OnTargetSet;
        _targetSystem.TargetDied += OnTargetDeath;
    }

    private void OnDisable()
    {
        _health.MinValueReached -= OnDeath;
    }

    public void DealDamage(Health opponent)
    {
        opponent.TakeDamage(_damage);
    }

    public Health GetHealth()
    {
        return _health;
    }

    private void OnTargetDeath()
    {
        LeftBattleState?.Invoke();
    }

    private void OnTargetSet()
    {
        EnteredBattleState?.Invoke();
    }

    private void OnDeath()
    {
        Died?.Invoke();
    }
}
