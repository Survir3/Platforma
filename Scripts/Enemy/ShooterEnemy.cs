using UnityEngine;
using UnityEngine.Events;

public class ShooterEnemy : Shooter
{
    [SerializeField] private Spit _spit;
    [SerializeField] private float _distanceSearchTarget;
    [SerializeField] private LayerMask _layerMask;
    [SerializeField] private float _distanceShoot;
    [SerializeField] ShooterInAnimation _shooterInAnimation;

    private bool _isTarget = false;

    public event UnityAction<bool, float> TargetSeting;

    private void OnEnable()
    {
        _shooterInAnimation.AnimationPlaying += Shoot;
    }

    private void OnDisable()
    {
        _shooterInAnimation.AnimationPlaying -= Shoot;
    }

    private void Update()
    {
        SetDirectionTarget();
    }

    protected override void Shoot()
    {
        var newSpit = Instantiate(_spit, _shootPoint.position, Quaternion.identity);
        newSpit.Init(_directionShoot, _distanceShoot);
    }

    protected override void SetDirectionTarget()
    {
        RaycastHit2D hit = Physics2D.Raycast(_shootPoint.position, Vector2.left, _distanceSearchTarget, _layerMask);

        if (hit)
        {
            _directionShoot = Vector2.left;
        }
        else
        {
            hit = Physics2D.Raycast(_shootPoint.position, Vector2.right, _distanceSearchTarget, _layerMask);

            if (hit)
            {
                _directionShoot = Vector2.right;

            }
        }

        if (hit)
        {
            _isTarget = hit.collider.gameObject.TryGetComponent<Player>(out var player);
        }
        else
        {
            _isTarget = false;
        }

        TargetSeting?.Invoke(_isTarget, _directionShoot.x);
    }
}