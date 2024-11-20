using UnityEngine;

public class Door : MonoBehaviour
{
    public float openSpeed = 2f; 
    public Vector3 openPosition; 
    public bool isOpen = false; 

    private Vector3 closedPosition; 

    private void Start()
    {
        closedPosition = transform.position; 
    }

    public void Open()
    {
        if (!isOpen) 
        {
            isOpen = true;
            openPosition = closedPosition + Vector3.up * 2f; 
        }
    }

    private void Update()
    {
        if (isOpen) 
        {
            transform.position = Vector3.Lerp(transform.position, openPosition, openSpeed * Time.deltaTime);
        }
        else
        {
            transform.position = Vector3.Lerp(transform.position, closedPosition, openSpeed * Time.deltaTime);
        }
    }
}
