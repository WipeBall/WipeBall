using UnityEngine;

public class Rotator : MonoBehaviour
{
    // Variable pública para controlar la velocidad desde el Inspector
    public float speedY = 100f;

    void Update()
    {
        // Girar sobre el eje Y (Arriba/Abajo)
        transform.Rotate(0, speedY * Time.deltaTime, 0);
    }
}