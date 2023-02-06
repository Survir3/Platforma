using System.Collections;
using UnityEngine;

[RequireComponent(typeof(ColliderHandler))]
public class AttackState : State
{
    [SerializeField] private int _damage;
    [SerializeField] private int _speed;
    [SerializeField, Range(0,1)] private float _powerPush;
    [SerializeField] private float _timeDisableControl;
    [SerializeField] private ColliderHandler _collisionHandler;

    private Vector3 _pointTarget;

    private void OnEnable()
    {
        _collisionHandler.TargetReached += OnTargetReached;
    }
    private void OnDisable()
    {
        _collisionHandler.TargetReached -= OnTargetReached;
    }
    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, _pointTarget, _speed*Time.deltaTime);
    }

    private void OnTargetReached(Player player)
    {
        StartCoroutine(DisableControl(player));
        player.TakeDamage(_damage);
        PushTarget(player);
    }

    private void PushTarget(Player target)
    {
        if (target.TryGetComponent<Rigidbody2D>(out var rigidbody2D))
        {
            Vector2 direction = (target.transform.position-transform.position).normalized+Vector3.up;
            rigidbody2D.AddForce(direction * _powerPush, ForceMode2D.Impulse);
        }
    }

    private IEnumerator DisableControl(Player target)
    {
        target.GetInputPlayer().Disable();
        yield return new WaitForSeconds(_timeDisableControl);
        target.GetInputPlayer().Enable();
    }

    public override void Enter(Player player)
    {
        base.Enter(player);
        _pointTarget = new Vector3(player.transform.position.x, transform.position.y,0);
    }
}
