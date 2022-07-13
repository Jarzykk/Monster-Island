using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Monster))]
public class StateMachine : MonoBehaviour
{
    [SerializeField] private State _firstState;

    private State _current;

    public State CurrentState => _current;

    private void OnEnable()
    {
        Reset(_firstState);
    }

    private void Update()
    {
        if (_current == null)
            return;

        var nextState = _current.GetNextState();
        if (nextState != null)
            Transit(nextState);
    }

    private void Reset(State starttState)
    {
        _current = starttState;
        _current?.Enter();
    }

    public void DisableStateMachine()
    {
        _current.Exit();
        this.enabled = false;
    }

    private void Transit(State nextState)
    {
        _current?.Exit();
        _current = nextState;
        _current?.Enter();
    }
}
