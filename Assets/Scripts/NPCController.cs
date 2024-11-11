using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCController : MonoBehaviour
{
    [SerializeField] private GameObject _target;
    private NavMeshAgent _agent;
    private Animator _animator;
    //private bool IsJumping = false;
    private bool _jumping = false;

    private void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _animator = GetComponent<Animator>();
        _agent.SetDestination(_target.transform.position);

        //if (!IsJumping)
        if (_jumping)
        {
            _jumping = false;
            _animator.SetBool("IsJumping", _jumping);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _jumping = true;
            _animator.SetBool("IsJumping", _jumping);
        }
    }

    private void Update()
    {
        float speed = _agent.velocity.magnitude;
        _animator.SetFloat("Speed", speed);
        _jumping=true;
        //Find a way to set the magnitude up so it jumps
       // _animator.SetBool("IsJumping", isJumping);
        //if (_jumping = true) ;

      
    }
}
