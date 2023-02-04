using UnityEngine;

public class Spikes : Obstacle
{
    private void Awake()
    {
        SetNeedComponents();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<Player>(out var player))
        {
            StartCoroutine(EnableTriggerForTime());
            StartCoroutine(DisableControl(player));
            ApplyDamage(player);
            PushTarget(player);
            _audioSource.Play();
        }
    }

    protected override void PushTarget(Player target)
    {
        if (target.TryGetComponent<Rigidbody2D>(out var rigidbody2D))
        {
            Vector2 direction = (target.transform.position - transform.position).normalized + Vector3.up;
            rigidbody2D.AddForce(direction * _powerPush, ForceMode2D.Impulse);
        }
    }
}
