using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using NaughtyAttributes;

public abstract class MainActorState : MonoBehaviour
{
    [SerializeField, ReadOnly]
    protected float _startTime;
    [SerializeField, ReadOnly]
    protected MainActorState _intendedNextState;
    [SerializeField, FormerlySerializedAs("_kirby")]
    protected MainActor _actor;

    private List<MainActorStateFunction> _functions = new List<MainActorStateFunction>();

    public MainActor Actor => _actor;
    public float TimeSpentInState => Time.time - _startTime;

    protected virtual void OnEnable()
    {
        _startTime = Time.time;
        for (int i = 0; i < _functions.Count; i++)
        {
            _functions[i].OnEnable();
        }
    }
    protected virtual void OnDisable()
    {
        for (int i = 0; i < _functions.Count; i++)
        {
            _functions[i].OnDisable();
        }
    }
    protected virtual void Update()
    {
        for (int i = 0; i < _functions.Count; i++)
        {
            _functions[i].Update();
        }
    }
    protected virtual void LateUpdate()
    {
        if (_intendedNextState != null)
        {
            _actor.SetState(_intendedNextState);
            _intendedNextState = null;
        }
    }
    public virtual void NotifyActionTriggered(MainActorAction action)
    {
        for (int i = 0; i < _functions.Count; i++)
        {
            _functions[i].NotifyActionTriggered(action);
        }
    }
    public void AddFunction(MainActorStateFunction function)
    {
        _functions.Add(function);
    }
    public void SetIntendedNextState(MainActorState state)
    {
        _intendedNextState = state;
    }
}
