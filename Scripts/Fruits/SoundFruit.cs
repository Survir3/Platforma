using UnityEngine;

public class SoundFruit : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private TriggerHandlerFuit _triggerHandlerFruit;


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
        _audioSource.Play();
    }
}
