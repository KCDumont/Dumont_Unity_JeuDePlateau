using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCController : MonoBehaviour
{
    [SerializeField] private GameObject _target;
    private NavMeshAgent _agent;
    private Animator _animator;
    private bool _jumping = false;
    public float jumpForce = 2.0f;
    private Rigidbody _rigidbody; 

    private void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _animator = GetComponent<Animator>();
        _agent.SetDestination(_target.transform.position);
        _rigidbody = GetComponent<Rigidbody>();
        StartCoroutine(JumpRoutine());

        //Anciennes Techniques
            //if (!IsJumping)
            //if (_jumping)
            //{
            //    _jumping = false;
            //    _animator.SetBool("IsJumping", _jumping);
            //}
            //if (Input.GetKeyDown(KeyCode.Space))
             // {
            //    _jumping = true;
             //   _animator.SetBool("IsJumping", _jumping);
            //}
    }
    private IEnumerator JumpRoutine()
    {
        while (true)
        {
            _jumping = true;
            float jumpDuration = 1.0f;
            _animator.SetBool("IsJumping", _jumping);
            _rigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            yield return new WaitForSeconds(jumpDuration);

            _jumping = false;
            _animator.SetBool("IsJumping", _jumping);
            yield return new WaitForSeconds(jumpDuration);
        }
    }

    private void Update()
    {
        float speed = _agent.velocity.magnitude;
        _animator.SetFloat("Speed", speed);
        _jumping=true;
           
        //Anciennes techniques
            // _animator.SetBool("IsJumping", isJumping);
            //if (_jumping = true) ;

      
    }
}
