using UnityEngine;

public class DoorController : MonoBehaviour
{
    [Header("Door Movement Settings")]
    public float openHeight = 3f;
    public float openSpeed = 2f;

    private Vector3 closedPosition;
    private Vector3 openPosition;
    private bool isOpening = false;
    private bool isClosing = false;

    private void Start()
    {
        closedPosition = transform.position;
        openPosition = closedPosition + Vector3.up * openHeight;
    }

    private void Update()
    {
        if (isOpening)
        {
            transform.position = Vector3.MoveTowards(
                transform.position,
                openPosition,
                openSpeed * Time.deltaTime
            );

            if (transform.position == openPosition)
            {
                isOpening = false;
            }
        }
        else if (isClosing)
        {
            transform.position = Vector3.MoveTowards(
                transform.position,
                closedPosition,
                openSpeed * Time.deltaTime
            );

            if (transform.position == closedPosition)
            {
                isClosing = false;
            }
        }
    }

    public void OpenDoor()
    {
        isOpening = true;
        isClosing = false;
    }

    public void CloseDoor()
    {
        isOpening = false;
        isClosing = true;
    }
}