using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D),typeof(AudioSource))]
public abstract class Obstacle : MonoBehaviour
{
    [SerializeField, Range(0, 1)] protected float _powerPush;
    [SerializeField] private float _timeDisableControl;
    [SerializeField] private float _timeEnableTrigger;
    [SerializeField] private int _damage;

    protected Collider2D _collider;
    protected AudioSource _audioSource;

    protected void ApplyDamage(Player player)
    {
        player.TakeDamage(_damage);
    }

    protected virtual void PushTarget(Player target)
    {
        if (target.TryGetComponent<Rigidbody2D>(out var rigidbody2D))
        {
            Vector2 direction = (target.transform.position - transform.position).normalized + Vector3.up;
            rigidbody2D.AddForce(direction * _powerPush, ForceMode2D.Impulse);
        }
    }

    protected IEnumerator DisableControl(Player target)
    {
        target.GetInputPlayer().Disable();
        yield return new WaitForSeconds(_timeDisableControl);
        target.GetInputPlayer().Enable();
    }

    protected IEnumerator EnableTriggerForTime()
    {
        _collider.isTrigger = true;
        yield return new WaitForSeconds(_timeEnableTrigger);
        _collider.isTrigger = false;
    }

    protected virtual void SetNeedComponents()
    {
        _collider = GetComponent<CircleCollider2D>();
        _collider.isTrigger = false;

        _audioSource = GetComponent<AudioSource>();
        _audioSource.playOnAwake = false;
    }
}
