using UnityEngine;
using IJunior.TypedScenes;
using UnityEditor.Animations;

public class SetterCharacterPlayer : MonoBehaviour, ISceneLoadHandler<AnimatorController>
{
    [SerializeField] private Animator _animatorPlayer;

    public void OnSceneLoaded(AnimatorController argument)
    {
        _animatorPlayer.runtimeAnimatorController= argument;
    }
}
