using UnityEngine;

public abstract class Ammunition : MonoBehaviour
{
    [SerializeField] protected float _speed;

    protected Vector3 _direction;

    public virtual void Init(Vector3 direction)
    {
        _direction = direction;
    }    

    public void Move()
    {
        transform.position += _direction * _speed * Time.deltaTime;
    }
}
