using UnityEngine;

[RequireComponent(typeof(ColliderHandlerEnemy))]
public class ZonePositionTransition : Transition
{
    [SerializeField] private ColliderHandlerEnemy _collisionHandler;

    private void OnEnable()
    {
        _collisionHandler.ZoneReached += OnZoneReached;
    }
    private void OnDisable()
    {
        _collisionHandler.ZoneReached -= OnZoneReached;
    }

    private void OnZoneReached()
    {
        NeedTransit = true;
    }
}
