using UnityEngine;
public class GameManager : MonoBehaviour
{
    public Transform spawnPoint;  
    public GameObject player;
    void Update()
    {
        if (player.transform.position.y < -10)
        {
            Respawn();
        }
    }
    public void Respawn()
    {
        player.transform.position = spawnPoint.position;
        player.transform.rotation = spawnPoint.rotation;  
        Rigidbody rb = player.GetComponent<Rigidbody>();
        rb.linearVelocity = Vector3.zero;  
        rb.angularVelocity = Vector3.zero;
    }
    public void UpdateSpawnPoint(Transform newSpawn)
    {
        spawnPoint = newSpawn;
        Debug.Log("Checkpoint guardado: " + newSpawn.name);  
    }
}