using UnityEngine;
using UnityEngine.Events;

public class ShooterInAnimation : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    public event UnityAction AnimationPlaying;

    public void Shoot()
    {
        AnimationPlaying?.Invoke();
    }
}
