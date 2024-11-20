using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Test : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private float _speed;
    [SerializeField] private float _JumpForce;
    [SerializeField] private Animator _animator;
    private bool _onGround;


    void Start()
    {
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            _rigidbody.AddForce(Vector3.right * _speed);
            _animator.SetTrigger("triggerMove2");
        }
        if (Input.GetKey(KeyCode.A))
        {
            _rigidbody.AddForce(Vector3.left * _speed);
            _animator.SetTrigger("triggerMove2");
        }
        if (Input.GetKey(KeyCode.S))
        {
            _rigidbody.AddForce(Vector3.back * _speed);
            _animator.SetTrigger("triggerMove");
        }
        if (Input.GetKey(KeyCode.W))
        {
            _rigidbody.AddForce(Vector3.forward * _speed);
            _animator.SetTrigger("triggerMove");
        }

        if (_onGround && Input.GetKeyDown(KeyCode.Space))
        {
            _rigidbody.AddForce(Vector3.up * _JumpForce);
            _animator.SetTrigger("triggerJump");
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "ground")
        {
            _onGround = true;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.transform.tag == "ground")
        {
            _onGround = false;
        }

    }
}