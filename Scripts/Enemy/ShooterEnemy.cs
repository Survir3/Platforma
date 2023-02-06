using System.Collections.Generic;
using System.Linq;
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
        var foundPlayer = SearchPlayerInDirection(Vector2.left);

        if (foundPlayer)
        {
            _directionShoot = Vector2.left;
            _isTarget = foundPlayer;
        }
        else
        {
            foundPlayer = SearchPlayerInDirection(Vector2.right);

            if (foundPlayer)
            {
                _directionShoot = Vector2.right;
                _isTarget = foundPlayer;
            }
            else
            {
                _isTarget = foundPlayer;
            }
        }

        TargetSeting?.Invoke(_isTarget, _directionShoot.x);
    }

    private bool SearchPlayerInDirection(Vector2 direction)
    {
        int minCountHits = 1;
        int firstHit = 0;
        Player player;
        Ground ground;

        List<RaycastHit2D> hits = Physics2D.RaycastAll(_shootPoint.position, direction, _distanceSearchTarget, _layerMask).ToList();

        var filteredHits = hits.Where(hit => hit.collider.TryGetComponent(out player)
                                  || hit.collider.TryGetComponent(out ground)).ToList();


        if (filteredHits.Count >= minCountHits)
        {
            return filteredHits[firstHit].collider.TryGetComponent(out player);
        }

        return false;
    }

}