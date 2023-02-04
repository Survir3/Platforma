using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] private int _maxHealth;

    private int _currentHealth;
    private InputPlayer _playerInput;

    public int Points { get; private set; }

    public event UnityAction Died;

    private void Awake()
    {
        _playerInput=new InputPlayer();
        _playerInput.Enable();
    }

    private void Start()
    {
        _currentHealth = _maxHealth;
    }

    private void OnDisable()
    {
        _playerInput.Disable();
    }

    private void Die()
    {
        Destroy(gameObject);
        Died?.Invoke();
    }

    public void TakeDamage(int damage)
    {
        _currentHealth -= damage;

        if(_currentHealth<0)
        {
            Die();
        }
    }

    public InputPlayer GetInputPlayer()
    {
        return _playerInput;
    }

    public void AddPoint(int point)
    {
        Points += point;
    }
}
