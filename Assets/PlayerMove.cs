using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private Animator _animator;
    [SerializeField] private float _rotationSpeed = 10f; 

    private bool _onGround;
    private bool _doubleJumpAvailable = true;
    private Camera mainCamera;

    void Start()
    {
        mainCamera = Camera.main;
    }

    void Update()
    {
        Vector3 cameraForward = mainCamera.transform.forward;
        Vector3 cameraRight = mainCamera.transform.right;

        cameraForward.y = 0;
        cameraRight.y = 0;
        cameraForward.Normalize();
        cameraRight.Normalize();

        if (_onGround)
        {
            if (Input.GetKey(KeyCode.D))
            {
                transform.rotation = Quaternion.Slerp(
                    transform.rotation,
                    Quaternion.LookRotation(cameraRight),
                    _rotationSpeed * Time.deltaTime
                );
                _animator.SetTrigger("triggerMove2");
            }

            if (Input.GetKey(KeyCode.A))
            {
                transform.rotation = Quaternion.Slerp(
                    transform.rotation,
                    Quaternion.LookRotation(-cameraRight),
                    _rotationSpeed * Time.deltaTime
                );
                _animator.SetTrigger("triggerMove2");
            }

            if (Input.GetKey(KeyCode.W))
            {
                _rigidbody.AddForce(cameraForward * _speed);
                _animator.SetTrigger("triggerMove");
            }

            if (Input.GetKey(KeyCode.S))
            {
                _rigidbody.AddForce(-cameraForward * _speed);
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