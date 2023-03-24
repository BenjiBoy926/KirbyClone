using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

public abstract class KirbyState : MonoBehaviour
{
    [SerializeField, ReadOnly]
    protected float _startTime;
    [SerializeField, ReadOnly]
    protected KirbyState _intendedNextState;
    [SerializeField]
    protected Kirby _kirby;

    private List<KirbyStateFunction> _functions = new List<KirbyStateFunction>();

    public Kirby Kirby => _kirby;
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
            _kirby.SetState(_intendedNextState);
            _intendedNextState = null;
        }
    }
    public virtual void NotifyHeadingSet()
    {
        for (int i = 0; i < _functions.Count; i++)
        {
            _functions[i].NotifyHeadingSet();
        }
    }
    public virtual void NotifyActionTriggered(KirbyAction action)
    {
        for (int i = 0; i < _functions.Count; i++)
        {
            _functions[i].NotifyActionTriggered(action);
        }
    }
    public void AddFunction(KirbyStateFunction function)
    {
        _functions.Add(function);
    }
    public void SetIntendedNextState(KirbyState state)
    {
        _intendedNextState = state;
    }
}
