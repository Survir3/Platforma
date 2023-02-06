using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private int _maxHealth;

    private int _currentHealth;
    private InputPlayer _playerInput;

    public int Points { get; private set; }

    public event UnityAction Died;
    public event UnityAction<float> HealthChanged;
    public event UnityAction<int> PointsChanged;
    public event UnityAction TookDamage;


    private void Awake()
    {
        _playerInput=new InputPlayer();
        _playerInput.Enable();
    }

    private void Start()
    {
        _currentHealth = _maxHealth;
        HealthChanged?.Invoke((float)_currentHealth /_maxHealth);
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
        HealthChanged?.Invoke((float)_currentHealth/ _maxHealth);
        TookDamage?.Invoke();

        if (_currentHealth<0)
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
        PointsChanged?.Invoke(Points);
    }
}
