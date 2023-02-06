using UnityEngine;

[RequireComponent(typeof(ColliderHandler))]
public class ZonePositionTransition : Transition
{
    [SerializeField] private ColliderHandler _collisionHandler;

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
