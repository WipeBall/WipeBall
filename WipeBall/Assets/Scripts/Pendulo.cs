using UnityEngine;

public class Pendulo : MonoBehaviour
{
    public float velocidad = 2.0f;  // Qué tan rápido va
    public float anguloMaximo = 75.0f; // Qué tan alto llega (grados)
    public float desfase = 0.0f;    // Para que no vayan todos a la vez

    void Update()
    {
        // Matemáticas mágicas para el movimiento de vaivén
        float angulo = anguloMaximo * Mathf.Sin(Time.time * velocidad + desfase);
        
        // Aplicamos la rotación en el eje Z (para que se mueva de izq a derecha)
        transform.localRotation = Quaternion.Euler(0, 0, angulo);
    }
}