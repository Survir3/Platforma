using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EnemyStateMachine))]

public abstract class State : MonoBehaviour
{
    [SerializeField] protected List<Transition> _transitions;

    protected Player Player;

    private void Awake()
    {
        enabled = false;
    }

    public virtual void Enter(Player player)
    {
        enabled = true;
        Player= player;

        foreach (var transition in _transitions)
        {
            transition.enabled = true;
            transition.Init(player);
        }
    }

    public virtual void Exit() 
    { 
        foreach (var transition in _transitions) 
        {
            transition.enabled = false;        
        }

        enabled= false;
    }

    public State GetNextState()
    {
        foreach (var transition in _transitions)
        {
            if (transition.NeedTransit == true)
            {
                return transition.NextState;
            }
        }

        return null;
    }
}
