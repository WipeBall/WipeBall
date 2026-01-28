using UnityEngine;
public class WaterTrigger : MonoBehaviour {
    public GameManager gameManager;
    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            gameManager.Respawn();
        }
    }
}