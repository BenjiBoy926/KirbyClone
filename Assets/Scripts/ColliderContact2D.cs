using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

public class ColliderContact2D : MonoBehaviour
{
    public delegate void TouchingChanged(bool isTouching);

    [SerializeField]
    private Rigidbody2DIsSleepingEvents _rigidbodyEvents;
    [SerializeField]
    private Collider2D _collider;
    [SerializeField]
    private LayerMask _mask;
    [SerializeField]
    private float _areaOffsetFromColliderEdge = 0.001f;
    [SerializeField]
    private float _areaWidth = 0.001f;
    [SerializeField]
    private float _areaLengthReduction = 0.1f;

    [SerializeField, ReadOnly]
    private bool _isTouchingFloor;
    [SerializeField, ReadOnly]
    private bool _isTouchingCeiling;
    [SerializeField, ReadOnly]
    private bool _isTouchingLeftWall;
    [SerializeField, ReadOnly]
    private bool _isTouchingRightWall;

    public bool IsTouchingFloor => _isTouchingFloor;
    public bool IsTouchingCeiling => _isTouchingCeiling;
    public bool IsTouchingLeftWall => _isTouchingLeftWall;
    public bool IsTouchingRightWall => _isTouchingRightWall;

    public event TouchingChanged IsTouchingFloorChanged = delegate { };
    public event TouchingChanged IsTouchingCeilingChanged = delegate { };
    public event TouchingChanged IsTouchingLeftWallChanged = delegate { };
    public event TouchingChanged IsTouchingRightWallChanged = delegate { };

    private void Awake()
    {
        _rigidbodyEvents.IsSleepingChanged += RigidbodyEvents_IsSleepingChanged;
    }
    private void OnDestroy()
    {
        _rigidbodyEvents.IsSleepingChanged -= RigidbodyEvents_IsSleepingChanged;
    }
    private void Update()
    {
        OverlapAreaAndRaiseEvents(Vector2.up, ref _isTouchingCeiling, IsTouchingCeilingChanged);
        OverlapAreaAndRaiseEvents(Vector2.down, ref _isTouchingFloor, IsTouchingFloorChanged);
        OverlapAreaAndRaiseEvents(Vector2.left, ref _isTouchingLeftWall, IsTouchingLeftWallChanged);
        OverlapAreaAndRaiseEvents(Vector2.right, ref _isTouchingRightWall, IsTouchingRightWallChanged);
    }
    private void OnDrawGizmosSelected()
    {
        if (_collider == null)
        {
            return;
        }

        DrawAreaGizmo(Vector2.up);
        DrawAreaGizmo(Vector2.down);
        DrawAreaGizmo(Vector2.left);
        DrawAreaGizmo(Vector2.right);
    }

    private void OverlapAreaAndRaiseEvents(Vector2 direction, ref bool isTouching, TouchingChanged changeEvent)
    {
        bool previousIsTouching = isTouching;
        isTouching = OverlapArea(direction, out _, out _);
        if (previousIsTouching != isTouching)
        {
            changeEvent(isTouching);
        }
    }
    private bool OverlapArea(Vector2 direction, out Vector2 pointA, out Vector2 pointB)
    {
        GetArea(direction, out pointA, out pointB);
        return Physics2D.OverlapArea(pointA, pointB, _mask);
    }
    private void GetArea(Vector2 direction, out Vector2 pointA, out Vector2 pointB)
    {
        Bounds bounds = _collider.bounds;
        Vector2 min = bounds.min;
        Vector2 max = bounds.max;
        Vector2 size = bounds.size;
        Vector2 sizeAlongDirection = Multiply(size, direction);
        Vector2 directionAxisFlip = new Vector2(direction.y, direction.x);

        pointA = min + _areaOffsetFromColliderEdge * direction + _areaLengthReduction * Abs(directionAxisFlip);
        pointB = max + _areaOffsetFromColliderEdge * _areaWidth * direction - _areaLengthReduction * Abs(directionAxisFlip);

        if (direction.x > 0 || direction.y > 0)
        {
            pointA += sizeAlongDirection;
        }
        if (direction.x < 0 || direction.y < 0)
        {
            pointB += sizeAlongDirection;
        }
    }
    private void RigidbodyEvents_IsSleepingChanged(bool isSleeping)
    {
        enabled = !isSleeping;
    }
    private Vector2 Multiply(Vector2 a, Vector2 b)
    {
        return new Vector2(a.x * b.x, a.y * b.y);
    }
    private Vector2 Abs(Vector2 vector)
    {
        return new Vector2(Mathf.Abs(vector.x), Mathf.Abs(vector.y));
    }
    private void DrawAreaGizmo(Vector2 direction)
    {
        if (OverlapArea(direction, out Vector2 pointA, out Vector2 pointB))
        {
            Gizmos.color = Color.red;
        }
        else
        {
            Gizmos.color = Color.green;
        }
        Gizmos.DrawLine(pointA, pointB);
    }
}
