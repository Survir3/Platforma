using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider2D))]
public class TriggerHandlerFuit : MonoBehaviour
{
    public event UnityAction<Player> FruitСollected;

    private bool _fruitСollect=false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (_fruitСollect)
            return;

        if (collision.gameObject.TryGetComponent<Player>(out var player))
        {
            _fruitСollect=true;
            FruitСollected?.Invoke(player);
        }
    }
}
