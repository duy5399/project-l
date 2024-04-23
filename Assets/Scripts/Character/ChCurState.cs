using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChCurState : ChBase
{
    public enum CurrentState
    {
        OutCombat = 1,
        InCombat = 2,
        Gathering = 3,
        Channeling = 4,
    }

    [SerializeField] private bool _ridingMount;
    [SerializeField] private float _mountSpeed;
    [SerializeField] private float _characterSpeed;

    [SerializeField] private bool _inCombat = false;
    [SerializeField] private float _silenceTimeLeft = 0f;
    [SerializeField] private float _attackDisableTimeLeft = 0f;
    [SerializeField] private float _moveDisableTimeLeft = 0f;
    [SerializeField] private float _slowMoveTimeLeft = 0f;

    public float moveSpeed
    {
        get { return _ridingMount == true ? _mountSpeed : _characterSpeed; }
    }

    public bool ridingMount
    {
        get { return _ridingMount; }
    }

    protected override void Awake()
    {
        base.Awake();
        _ridingMount = false; _characterSpeed = 3;
    }
}
