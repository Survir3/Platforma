using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(TriggerHandlerFruit))]
public class Fruit : MonoBehaviour
{
    [SerializeField] private int _points;
    [SerializeField] private TriggerHandlerFruit _collisionHandlerFruit;

    private void OnEnable()
    {
        _collisionHandlerFruit.FruitСollected += OnFruitСollected;
    }

    private void OnDisable()
    {
        _collisionHandlerFruit.FruitСollected -= OnFruitСollected;
    }

    private void OnFruitСollected(Player player)
    {
        player.AddPoint(_points);
    }
}
