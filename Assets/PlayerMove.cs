using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private Animator _animator;
    private bool _onGround;
    private bool _doubleJumpAvailable = true;

    void Update()
    {
        if (_onGround)
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
        }

        if ((_onGround || _doubleJumpAvailable) && Input.GetKeyDown(KeyCode.Space))
        {
            if (!_onGround)
            {
                _doubleJumpAvailable = false;
            }

            _rigidbody.velocity = new Vector3(_rigidbody.velocity.x, 0f, _rigidbody.velocity.z);
            _rigidbody.AddForce(Vector3.up * _jumpForce);
            _animator.SetTrigger("triggerJump");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "ground")
        {
            _onGround = true;
            _doubleJumpAvailable = true;
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