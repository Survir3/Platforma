using UnityEngine;
using UnityEngine.UI;

public class ViewerPointsPlayer : MonoBehaviour
{
    [SerializeField] private Text _text;
    [SerializeField] private Player _player;

    private void OnEnable()
    {
        _player.PointsChanged += OnPointsChanged;
    }

    private void OnDisable()
    {
        _player.PointsChanged -= OnPointsChanged;

    }

    protected void OnPointsChanged(int points)
    {
        _text.text = points.ToString();
    }
}
