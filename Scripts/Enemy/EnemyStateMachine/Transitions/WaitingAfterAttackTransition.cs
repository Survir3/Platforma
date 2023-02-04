using System.Collections;
using UnityEngine;

public class WaitingAfterAttackTransition : Transition
{
    [SerializeField] private float _duration;

    private void OnEnable()
    {
        NeedTransit = false;
        StartCoroutine(Timer(_duration));
    }

    private IEnumerator Timer(float duration)
    {
        yield return new WaitForSeconds(duration);
        NeedTransit=true;
    }
}
