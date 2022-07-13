using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Monster))]
public class AttackState : State
{
    [SerializeField] private float _attackCooldawn;

    private Health _target;
    private Monster _monster;
    private float _timeCount;

    public event UnityAction Attacked;

    private void OnEnable()
    {
        _monster = GetComponent<Monster>();
        _target = _monster.CurrentTarget.GetHealth();
        _timeCount = 0;
    }

    private void Update()
    {
        if(_target != null)
        {
            if (_timeCount <= 0)
            {
                Attack();
                _timeCount = _attackCooldawn;
            }

            _timeCount -= Time.deltaTime;
        }        
    }

    private void Attack()
    {
        _monster.DealDamage(_target);
        Attacked?.Invoke();
    }
}
