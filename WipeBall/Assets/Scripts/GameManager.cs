using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Transform spawnPoint; // Aquí guardaremos SIEMPRE el último checkpoint
    public GameObject player;

    void Update()
    {
        // Si caemos al vacío
        if (player.transform.position.y < -10)
        {
            Respawn();
        }
    }

    public void Respawn()
    {
        // 1. Teletransportar al último punto guardado
        player.transform.position = spawnPoint.position;
        player.transform.rotation = spawnPoint.rotation; // Importante: Mirar hacia donde mira el checkpoint

        // 2. Resetear físicas (para que no salga disparado)
        Rigidbody rb = player.GetComponent<Rigidbody>();
        rb.linearVelocity = Vector3.zero; // En Unity 6 se llama linearVelocity (antes velocity)
        rb.angularVelocity = Vector3.zero;
    }

    // ESTA ES LA FUNCIÓN NUEVA
    public void UpdateSpawnPoint(Transform newSpawn)
    {
        spawnPoint = newSpawn;
        Debug.Log("Checkpoint guardado: " + newSpawn.name); // Para ver en consola que funciona
    }
}