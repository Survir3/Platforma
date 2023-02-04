using UnityEngine;

public class AnimationPlayer : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private Animator _animator;
    [SerializeField] private MoverPlayer _moverPlayer;
    [SerializeField] private ShooterPlayer _shooterPlayer;

    private const string Run = "isRun";
    private const string Jump = "inAir";

    private void OnEnable()
    {
        _moverPlayer.DirectionChanged += OnDirectionChanged;
        _shooterPlayer.Shooting += OnShooting;
    }

    private void OnDisable()
    {
        _moverPlayer.DirectionChanged -= OnDirectionChanged;
        _shooterPlayer.Shooting -= OnShooting;
    }
    private void Update()
    {
        SetJumpAnimation(_moverPlayer.CanJump);
    }

    private void OnDirectionChanged(float direction)
    {
        TryFlipRender(direction);
        SetRunAnimation(direction);
    }

    private void OnShooting(float direction)
    {
        TryFlipRender(direction);
    }

    private void TryFlipRender(float direction)
    {
        _spriteRenderer.flipX = direction < 0;
    }

    private void SetRunAnimation(float direction)
    {
        _animator.SetBool(Run, direction != 0);        
    }

    private void SetJumpAnimation(bool canJump)
    {
        _animator.SetBool(Jump, !canJump);
    }
}
