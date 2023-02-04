using UnityEngine;

public abstract class Shooter : MonoBehaviour
{
    [SerializeField] protected Transform _shootPoint;

    protected Vector3 _directionShoot;

    protected abstract void Shoot();
    protected abstract void SetDirectionTarget();
}
