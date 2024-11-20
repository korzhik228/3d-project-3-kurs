using UnityEngine;

public class ButtonColliderRemover : MonoBehaviour
{
    [Range(0.1f, 10f)]
    public float colliderDisableDuration = 2f;

    private Collider playerCollider;
    private bool isButtonPressed = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !isButtonPressed)
        {
            playerCollider = other;
            if (playerCollider != null)
            {
                DisablePlayerCollider();
            }
        }
    }

    private void DisablePlayerCollider()
    {
        playerCollider.enabled = false;
        isButtonPressed = true;
        Debug.Log("Player collider disabled");
        StartCoroutine(ReenableColliderAfterDelay());
    }

    private System.Collections.IEnumerator ReenableColliderAfterDelay()
    {
        yield return new WaitForSeconds(colliderDisableDuration);

        if (playerCollider != null)
        {
            playerCollider.enabled = true;
            isButtonPressed = false;

            Debug.Log("Player collider re-enabled");
        }
    }
    public void ResetButton()
    {
        if (playerCollider != null)
        {
            playerCollider.enabled = true;
            isButtonPressed = false;
        }
    }
}