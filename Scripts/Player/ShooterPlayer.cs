using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class ShooterPlayer : Shooter
{
    [SerializeField] private Bullet _bullet;
    [SerializeField] private int _maxCountExistingBullet;
    [SerializeField] private Player _player;

    private InputPlayer _inputPlayer;
    private int _currentCountExistingBullet=0;

    public event UnityAction<float> Shooting;
    
    private void Start()
    {
        _inputPlayer=_player.GetInputPlayer();
        _inputPlayer.Player.Shoot.performed += ctx => OnShoot();
    }

    private void OnShoot()
    {
        SetDirectionTarget();
        Shoot();
    }

    private void OnBulletDestroyed(Bullet bullet)
    {
        bullet.BulletDestroyed -= OnBulletDestroyed;

        if(_currentCountExistingBullet>0)
        {
            _currentCountExistingBullet--;
        }
    }

    protected override void Shoot()
    {
        if (_currentCountExistingBullet < _maxCountExistingBullet)
        {
            _currentCountExistingBullet++;
            Bullet newBullet = Instantiate(_bullet, _shootPoint.position, Quaternion.identity);
            newBullet.Init(_directionShoot);
            newBullet.BulletDestroyed += OnBulletDestroyed;
            Shooting?.Invoke(_directionShoot.x);
        }
    }

    protected override void SetDirectionTarget()
    {
        Vector2 mousePosition = Mouse.current.position.ReadValue();
        Vector2 worldPosition = Camera.main.ScreenToWorldPoint(mousePosition);

        if (worldPosition.x - transform.position.x<0)
        {
            _directionShoot = Vector3.left;
        }
        else
        {
            _directionShoot = Vector3.right;
        }        
    }
}