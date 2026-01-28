using UnityEngine;
using UnityEngine.SceneManagement; // Necesario para reiniciar

public class GameManager : MonoBehaviour
{
    public Transform spawnPoint; // Dónde reaparece el jugador
    public GameObject player;

    void Update()
    {
        // Si el jugador cae muy abajo (por seguridad) o toca el agua
        if (player.transform.position.y < -10)
        {
            Respawn();
        }
    }

    public void Respawn()
    {
        // Resetear posición y física
        player.transform.position = spawnPoint.position;
        player.GetComponent<Rigidbody>().linearVelocity = Vector3.zero;
        player.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
    }
}