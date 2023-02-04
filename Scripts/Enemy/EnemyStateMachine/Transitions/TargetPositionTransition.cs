using UnityEngine;

public class TargetPositionTransition : Transition
{
    [SerializeField] private float _minDirectionToTarget;

    private Vector3 _targetPosition;

    private void Update()
    {
        var directionToTarget = Mathf.Abs(_targetPosition.x- transform.position.x);

        if (directionToTarget <= _minDirectionToTarget)
        {
            NeedTransit = true;
        }
    }

    public override void Init(Player player)
    {
        base.Init(player);
        _targetPosition= player.transform.position;
    }
}
