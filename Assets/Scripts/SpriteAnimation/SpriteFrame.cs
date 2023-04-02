using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

[System.Serializable]
public class SpriteFrame
{
    [SerializeField]
    private Sprite _sprite;
    [SerializeField]
    private bool _isActionFrame = false;
    [SerializeField]
    private bool _overrideDefaultFrameTime = false;
    [SerializeField, EnableIf(nameof(_overrideDefaultFrameTime)), AllowNesting]
    private float _frameTime = 0.3f;

    public Sprite Sprite => _sprite;
    public bool IsActionFrame => _isActionFrame;
    public bool OverrideDefaultFrameTime => _overrideDefaultFrameTime;
    public float FrameTime => _frameTime;
}
