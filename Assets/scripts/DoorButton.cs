using UnityEngine;

public class DoorButton : MonoBehaviour
{
    public int buttonID; 
    public DoorController associatedDoor; 
    public Material pressedMaterial;
    public Material defaultMaterial;
    private Renderer buttonRenderer;

    private bool isPressed = false;

    private void Start()
    {
        buttonRenderer = GetComponent<Renderer>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") || other.CompareTag("Box"))
        {
            if (!isPressed)
            {
                isPressed = true;
                if (buttonRenderer != null && pressedMaterial != null)
                {
                    buttonRenderer.material = pressedMaterial;
                }

                if (associatedDoor != null)
                {
                    associatedDoor.OpenDoor();
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") || other.CompareTag("Box"))
        {
            if (!IsObjectOnButton())
            {
                isPressed = false;
                if (buttonRenderer != null && defaultMaterial != null)
                {
                    buttonRenderer.material = defaultMaterial;
                }

                if (associatedDoor != null)
                {
                    associatedDoor.CloseDoor();
                }
            }
        }
    }

    private bool IsObjectOnButton()
    {
        Collider[] colliders = Physics.OverlapBox(
            transform.position,
            transform.localScale / 2,
            transform.rotation
        );

        foreach (Collider col in colliders)
        {
            if (col.CompareTag("Player") || col.CompareTag("Box"))
            {
                return true;
            }
        }
        return false;
    }
}

