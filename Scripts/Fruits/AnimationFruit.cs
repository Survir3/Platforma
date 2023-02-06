using UnityEngine;

public class AnimationFruit : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private TriggerHandlerFuit _triggerHandlerFruit;

    private const string _isCollect= "isCollect";

    private void OnEnable()
    {
        _triggerHandlerFruit.FruitСollected += OnFruitСollected;
    }

    private void OnDisable()
    {
        _triggerHandlerFruit.FruitСollected -= OnFruitСollected;
    }

    private void OnFruitСollected(Player player)
    {
        _animator.SetTrigger(_isCollect);
    }
}

