using UnityEngine;

public class PortalTeleport : MonoBehaviour
{

    public Transform teleportDestination;
    public bool resetVelocity = true;
    public Vector3 teleportOffset = Vector3.zero;
    public float teleportCooldown = 1f;
    private float lastTeleportTime;

    private void OnTriggerEnter(Collider other)
    {
  
        if (other.CompareTag("Player"))
        {
         
            if (Time.time >= lastTeleportTime + teleportCooldown)
            {
                TeleportPlayer(other.transform);
            }
        }
    }
    private void TeleportPlayer(Transform playerTransform)
    {
 
        if (teleportDestination == null)
        {
            Debug.LogWarning("Teleport destination is not set!");
            return;
        }

        Vector3 teleportPosition = teleportDestination.position + teleportOffset;

        playerTransform.position = teleportPosition;
        if (resetVelocity)
        {
            Rigidbody playerRigidbody = playerTransform.GetComponent<Rigidbody>();
            if (playerRigidbody != null)
            {
                playerRigidbody.velocity = Vector3.zero;
            }
        }
        lastTeleportTime = Time.time;
        Debug.Log("Player teleported to: " + teleportPosition);
    }
}