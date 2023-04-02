using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Sprite Animation")]
public class SpriteAnimation : ScriptableObject
{
    [SerializeField]
    private SpriteFrame[] _frames;
    [SerializeField]
    private float _defaultFrameTime = 0.1f;
    [SerializeField]
    private bool _isLooping = false;

    public bool IsLooping => _isLooping;
    public int TotalFrames => _frames != null ? _frames.Length : 0;

    public SpriteFrame GetFrame(int i)
    {
        if (i < 0 || i >= _frames.Length)
        {
            return null;
        }
        return _frames[i];
    }
    public float GetFrameTime(int i)
    {
        SpriteFrame frame = GetFrame(i);
        if (frame == null)
        {
            return _defaultFrameTime;
        }
        if (frame.OverrideDefaultFrameTime)
        {
            return frame.FrameTime;
        }
        return _defaultFrameTime;
    }
}
