using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LevelSystem : MonoBehaviour
{
    [SerializeField] private int _startingLevel;
    [SerializeField] private int _experienceForNextLevel;
    [SerializeField] private int _experienceForNextLevelMultiplier;
    [SerializeField] private Monster _monster;
    [SerializeField] private MonsterTargetSystem _targetSystem;

    private int _currentExperience;
    private int _currentLevel;
    private int _experienceForKillingTarget = 0;
    public int CurrentLevel => _currentLevel;

    public event UnityAction LevelIncreased;

    private void OnEnable()
    {
        _targetSystem.TargetWasSet += OnTargetSet;
        _targetSystem.TargetDied += OnTargetKilled;
    }

    private void OnDisable()
    {
        _targetSystem.TargetWasSet -= OnTargetSet;
        _targetSystem.TargetDied -= OnTargetKilled;
    }

    private void Start()
    {
        _currentLevel = _startingLevel;
        _currentExperience = 0;
    }

    private void OnTargetSet()
    {
        _experienceForKillingTarget = _targetSystem.Target.ExperienceForKilling;
    }

    private void OnTargetKilled()
    {
        _currentExperience += _experienceForKillingTarget;
        _experienceForKillingTarget = 0;

        if (_currentExperience >= _experienceForNextLevel)
            LevelUp();
    }

    private void LevelUp()
    {
        _currentLevel++;
        _experienceForNextLevel *= _experienceForNextLevelMultiplier;
        LevelIncreased?.Invoke();
    }
}
