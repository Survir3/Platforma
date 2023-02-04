using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider2D))]
public class ColliderHandlerEnemy : MonoBehaviour
{
    public event UnityAction<Player> TargetReached;
    public event UnityAction ZoneReached;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<Player>(out var player))
        {
            TargetReached?.Invoke(player);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<ZoneAttackTarget>(out var zone))
        {
            ZoneReached?.Invoke();
        }        
    }
}