using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public abstract class Lazy<TValue> where TValue : Object
{
    [SerializeField]
    private TValue _value;

    public TValue Value
    {
        get
        {
            if (_value == null)
            {
                _value = LoadValue();

                if (_value == null)
                {
                    Debug.LogWarning($"Failed to lazy load a value of type '{typeof(TValue)}'");
                }
            }
            return _value;
        }
    }

    protected abstract TValue LoadValue(); 
}
