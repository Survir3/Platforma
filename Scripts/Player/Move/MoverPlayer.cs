using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody2D))]
public class MoverPlayer : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _powerJump;
    [SerializeField] private Player _player;

    private Rigidbody2D _rigidbody;
    private float _direction;
    private bool _canJump;
    private InputPlayer _inputPlayer;

    public bool CanJump => _canJump;

    public event UnityAction<float> DirectionChanged;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        _inputPlayer = _player.GetInputPlayer();
        _inputPlayer.Player.Jump.performed += ctx => OnJump();
    }

    private void OnDisable()
    {
        _inputPlayer.Player.Jump.performed -= ctx => OnJump();
    }

    private void Update()
    {
        _direction = _inputPlayer.Player.Move.ReadValue<float>();
        Move(_direction);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        _canJump=collision.gameObject.TryGetComponent<Ground>(out var ground);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<Ground>(out var ground))
        {
            _canJump = false;
        }
    }

    private void Move(float direction)
    {
        var direct = new Vector3(direction * _moveSpeed * Time.deltaTime, 0, 0);
        transform.position += direct;

        DirectionChanged?.Invoke(direction);
    }

    private void OnJump()
    {
        if (_canJump)
        {
            var Jump = new Vector3(0, _powerJump, 0);
            _rigidbody.AddForce(Jump);
        }
    }
}