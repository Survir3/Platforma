using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Saw : Obstacle
{
    [SerializeField] private List<Transform> _directionPoints;
    [SerializeField] private float _speedMove;

    private int _currentIndexDirectionPoint;

    private void Awake()
    {
        SetNeedComponents();

        _currentIndexDirectionPoint = 0;
    }

    private void Update()
    {
        Move();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.TryGetComponent<Player>(out var player))
        {
            StartCoroutine(EnableTriggerForTime());
            StartCoroutine(DisableControl(player));
            ApplyDamage(player);
            PushTarget(player);
            _audioSource.Play();
        }
    }

    private void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position,
                                                 _directionPoints[_currentIndexDirectionPoint].position,
                                                 _speedMove * Time.deltaTime);

        if (transform.position == _directionPoints[_currentIndexDirectionPoint].position)
        {
            _currentIndexDirectionPoint++;

            if (_currentIndexDirectionPoint == _directionPoints.Count)
            {
                _currentIndexDirectionPoint = 0;
            }
        }
    }
}