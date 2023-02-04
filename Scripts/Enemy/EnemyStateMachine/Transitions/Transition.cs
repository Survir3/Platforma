using UnityEngine;

[RequireComponent(typeof(EnemyStateMachine))]

public abstract class Transition : MonoBehaviour
{
    [SerializeField] private State _nextState;

    protected Player _player;
    public bool NeedTransit { get; protected set; }
    public State NextState => _nextState;

    private void Awake()
    {
        enabled = false;
    }
    private void OnEnable()
    {
        NeedTransit = false;
    }

    public virtual void Init(Player player)
    {
        _player = player;
    }

    public virtual void Reset(Player player)
    {

    }
    public virtual void Reset(Vector3 newPosision)
    {

    }
    public virtual void Reset()
    {

    }
}
