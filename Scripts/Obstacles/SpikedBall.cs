using UnityEngine;

public class SpikedBall : Obstacle
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
}
