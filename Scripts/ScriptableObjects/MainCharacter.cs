using UnityEditor.Animations;
using UnityEngine;

[CreateAssetMenu (menuName = "Create MainCharacter", fileName = "MainCharacter")]
public class MainCharacter : ScriptableObject
{
    [SerializeField] private string _name;
    [SerializeField] private Sprite _sprite;
    [SerializeField] private AnimatorController _animatorController;

    public string Name => _name;
    public Sprite Sprite => _sprite;

    public AnimatorController AnimatorController => _animatorController;
}
