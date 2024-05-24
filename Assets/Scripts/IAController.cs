using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public enum IAState
{
    None,
    Idle,
    Patrol,
    PlayerSeen,
    PlayerNear,
    Win,
}



public class IAController : MonoBehaviour
{
    private IAState _state = IAState.None;
    [SerializeField] Animator _animator;
    public bool PlayerNear = false;

    [SerializeField] private NavMeshAgent _agent;
    [SerializeField] private GameObject _waypoint;

    private void Update()
    {
        CheckTransition();
        Behaviour();
    }
    private void Behaviour()
    {
        switch (_state)
        {
            case IAState.None:
                break;
            case IAState.Idle:
                break;
            case IAState.Patrol:
                _agent.SetDestination(_waypoint.transform.position);
                break;
            case IAState.PlayerSeen:
                break;
            case IAState.PlayerNear:
                break;
            case IAState.Win:
                break;
        }
    }
    private void CheckTransition()
    {
        switch (_state)
        {
            case IAState.None:
                break;
            case IAState.Idle:
                break;
            case IAState.Patrol:
                break;
            case IAState.PlayerSeen:
                if (PlayerNear)
                {
                    _state = IAState.PlayerNear;
                    _animator.SetBool("IsClose", true);
                }
                break;
            case IAState.PlayerNear:
                if (!PlayerNear)
                {
                    _state = IAState.PlayerSeen;
                    _animator.SetBool("IsClose", false);
                }
                break;
            case IAState.Win:
                break;
        }
    }
}