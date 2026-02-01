using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private GameManager gameManager;

    void Start()
    {
        // Busca al GameManager automáticamente para no tener que arrastrarlo 20 veces
        gameManager = FindFirstObjectByType<GameManager>();
    }

    void OnTriggerEnter(Collider other)
    {
        // Si lo que entra es el Jugador
        if (other.CompareTag("Player"))
        {
            // Le decimos al Manager que ESTA (transform) es la nueva casa
            gameManager.UpdateSpawnPoint(transform);
            
            // Opcional: Desactivar este colisionador para no guardarlo 2 veces
            // GetComponent<Collider>().enabled = false; 
        }
    }
}