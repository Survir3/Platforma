using System.Security.Cryptography;
using UnityEngine;

[RequireComponent (typeof(Enemy))]
public class EnemyStateMachine : MonoBehaviour
{
    [SerializeField] private State _startState;

    private State _currentState;
    [SerializeField] private Player _player;

    private void Awake()
    {
        _currentState= _startState;
    }

    private void Start()
    {
        _currentState.Enter(_player);
    }

    private void Update()
    {
        var nexState = _currentState.GetNextState();
        TryTransitNextState(nexState);
    }

    private void TryTransitNextState(State nextState)
    {
        if (nextState != null)
        {
            _currentState.Exit();
            _currentState= nextState;
            _currentState.Enter(_player);
        }
    }
}
