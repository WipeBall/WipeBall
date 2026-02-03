using UnityEngine;
using TMPro;
public class HUD : MonoBehaviour
{
    public TextMeshProUGUI textoTiempo;
    public float tiempoActual = 0f;  
    private bool cronometroAndando = true;
    void Update()
    {
        if (cronometroAndando)
        {
            tiempoActual += Time.deltaTime; 
        }
        int minutos = Mathf.FloorToInt(tiempoActual / 60F);
        int segundos = Mathf.FloorToInt(tiempoActual % 60F);
        int milisegundos = Mathf.FloorToInt((tiempoActual * 100F) % 100F);
        textoTiempo.text = string.Format("{0:00}:{1:00}:{2:00}", minutos, segundos, milisegundos);
    }
    public void PararCronometro()
    {
        cronometroAndando = false;
    }
}