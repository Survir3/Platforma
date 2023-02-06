using UnityEngine;
using UnityEngine.UI;

public class ViewerHealthPlayer : MonoBehaviour
{
    [SerializeField] private Slider _healthSlider;
    [SerializeField] private Player _player;

    private void OnEnable()
    {
        _player.HealthChanged += OnHealthChanged;
    }

    private void OnDisable()
    {
        _player.HealthChanged -= OnHealthChanged;
    }

    protected  void OnHealthChanged(float normalizeHealth)
    {
        _healthSlider.value = normalizeHealth;
    }
}
