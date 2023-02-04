using UnityEngine;

public class AnimationEnemy : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private ShooterEnemy _shooterEnemy;

    private const string _isTarget = "isTarget";

    private void OnEnable()
    {
        _shooterEnemy.TargetSeting += OnTargetSetting;
    }

    private void OnDisable()
    {
        _shooterEnemy.TargetSeting -= OnTargetSetting;
    }

    private void OnTargetSetting(bool isTarget, float direction)
    {
        SetAttackAnimation(isTarget);
        TryFlipRender(direction);
    }
    private void TryFlipRender(float direction)
    {
        _spriteRenderer.flipX = direction > 0;
    }

    private void SetAttackAnimation(bool isTarget)
    {
        _animator.SetBool(_isTarget, isTarget);
    }
}
