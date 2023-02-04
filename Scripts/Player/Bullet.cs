using UnityEngine;
using UnityEngine.Events;

public class Bullet : Ammunition
{
    public event UnityAction<Bullet> BulletDestroyed;

    private void Update()
    {
        Move();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<Enemy>(out var enemy))
        {
            BulletDestroyed?.Invoke(this);
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
