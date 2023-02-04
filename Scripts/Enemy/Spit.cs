using UnityEngine;

public class Spit : Ammunition
{
    [SerializeField] private int _damage;

    private Vector3 _destroyPosition;

    private void Update()
    {
        Move();
        TryDestroy();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<Player>(out var player))
        {
            player.TakeDamage(_damage);
        }
    }

    public void Init(Vector3 direction, float distanceLiveSpit)
    {
        base.Init(direction);
        SetConditionsDestroySpit(direction, distanceLiveSpit);
    }

    private void SetConditionsDestroySpit(Vector3 direction, float distanceLiveSpit)
    {

        if (direction==Vector3.left)
        {
            _destroyPosition = new Vector3(transform.position.x - distanceLiveSpit, transform.position.y, transform.position.z);
        }
        else if (direction == Vector3.right)
        {
            _destroyPosition = new Vector3(transform.position.x + distanceLiveSpit, transform.position.y, transform.position.z);
        }
    }

    private void TryDestroy()
    {
        if (_direction == Vector3.left)
        {
            if(transform.position.x <= _destroyPosition.x)
            {
                Destroy(gameObject);
            }
        }
        else if (_direction == Vector3.right)
        {
            if (transform.position.x >= _destroyPosition.x)
            {
                Destroy(gameObject);
            }
        }
    }
}
