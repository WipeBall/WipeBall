using UnityEngine;
using TMPro;

public class HUD : MonoBehaviour
{
    public TextMeshProUGUI textoTiempo;
    public float tiempoActual = 0f; // Variable para guardar los segundos
    private bool cronometroAndando = true;

    void Update()
    {
        if (cronometroAndando)
        {
            // Sumamos el tiempo que pasa en cada fotograma
            // Si el juego está en Pausa, deltaTime es 0, así que no suma.
            tiempoActual += Time.deltaTime; 
        }

        // Calculamos minutos y segundos para que quede bonito (00:00)
        int minutos = Mathf.FloorToInt(tiempoActual / 60F);
        int segundos = Mathf.FloorToInt(tiempoActual % 60F);
        int milisegundos = Mathf.FloorToInt((tiempoActual * 100F) % 100F);

        textoTiempo.text = string.Format("{0:00}:{1:00}:{2:00}", minutos, segundos, milisegundos);
    }

    // Función para parar el tiempo cuando ganas
    public void PararCronometro()
    {
        cronometroAndando = false;
    }
}