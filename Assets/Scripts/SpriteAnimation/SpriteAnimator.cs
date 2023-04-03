using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

public class SpriteAnimator : MonoBehaviour
{
    [SerializeField]
    private bool _playOnAwake = true;
    [SerializeField]
    private SpriteRenderer _renderer;
    [SerializeField]
    private SpriteAnimation _currentAnimation;
    [SerializeField, ReadOnly]
    private int _currentFrame = 0;
    [SerializeField, ReadOnly]
    private float _timeOfNextAnimation = 0;

    public SpriteAnimation CurrentAnimation => _currentAnimation;

    public event SpriteFrameDelegate OnFrameEntered;
    public event SpriteFrameDelegate OnFrameExited;
    public event System.Action OnAnimationEnded;

    private void Awake()
    {
        if (_playOnAwake)
        {
            SetAnimation(_currentAnimation, true);
        }
    }
    private void Update()
    {
        if (Time.time >= _timeOfNextAnimation)
        {
            EnterNextFrame();
        }
    }
    public void SetAnimation(SpriteAnimation animation, bool restartIfSameAnimation)
    {
        if (!restartIfSameAnimation && animation == _currentAnimation)
        {
            return;
        }
        ExitCurrentFrame();
        _currentAnimation = animation;
        if (_currentAnimation != null)
        {
            _currentFrame = 0;
            EnterCurrentFrame();
            RefreshEnabled();
        }
    }
    private void EnterNextFrame()
    {
        if (_currentAnimation == null)
        {
            return;
        }
        ExitCurrentFrame();
        IncrementCurrentFrame();
        EnterCurrentFrame();
        RefreshEnabled();
        if (!enabled)
        {
            OnAnimationEnded?.Invoke();
        }
    }
    private void EnterCurrentFrame()
    {
        if (_currentAnimation == null || _currentFrame < 0 || _currentFrame >= _currentAnimation.TotalFrames)
        {
            return;
        }
        SpriteFrame frame = _currentAnimation.GetFrame(_currentFrame);
        _renderer.sprite = frame.Sprite;
        _timeOfNextAnimation = Time.time + _currentAnimation.GetFrameTime(_currentFrame);
        OnFrameEntered?.Invoke(frame);
    }
    private void ExitCurrentFrame()
    {
        if (_currentAnimation == null)
        {
            return;
        }
        OnFrameExited?.Invoke(_currentAnimation.GetFrame(_currentFrame));
    }
    private void RefreshEnabled()
    {
        enabled = _currentAnimation != null && (_currentAnimation.IsLooping || _currentFrame < _currentAnimation.TotalFrames);
    }
    public void FlipSprite(int input)
    {
        if (input > 0)
        {
            _renderer.flipX = false;
        }
        if (input < 0)
        {
            _renderer.flipX = true;
        }
    }
    private void IncrementCurrentFrame()
    {
        _currentFrame++;
        if (_currentAnimation != null && _currentAnimation.IsLooping)
        {
            _currentFrame %= _currentAnimation.TotalFrames;
        }
    }
}
