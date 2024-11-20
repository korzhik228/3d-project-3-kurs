using UnityEngine;

public class PlayerCheckpoint : MonoBehaviour
{
    public Transform currentCheckpoint;

    public float respawnHeight = -20f;
    public float respawnForce = 5f;

    private Rigidbody playerRigidbody;
    private Vector3 initialSpawnPoint;

    void Start()
    {

        playerRigidbody = GetComponent<Rigidbody>();


        initialSpawnPoint = transform.position;
        currentCheckpoint = null;
    }

    void Update()
    {

        if (transform.position.y < respawnHeight)
        {
            RespawnAtCheckpoint();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("CheckPoint"))
        {
            currentCheckpoint = other.transform;
            Debug.Log("Checkpoint reached!");
        }

        if (other.CompareTag("DeathZone"))
        {
            RespawnAtCheckpoint();
        }
    }

    private void RespawnAtCheckpoint()
    {
        Vector3 spawnPosition = currentCheckpoint != null
            ? currentCheckpoint.position
            : initialSpawnPoint;

        transform.position = spawnPosition;

        if (playerRigidbody != null)
        {
            playerRigidbody.velocity = Vector3.zero;
        }

        Debug.Log("Respawned at checkpoint!");
    }
}