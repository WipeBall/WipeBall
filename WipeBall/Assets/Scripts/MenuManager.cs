using UnityEngine;
using UnityEngine.SceneManagement; // IMPORTANTE: Necesario para cambiar de escena

public class MenuManager : MonoBehaviour
{
    // Función para el botón Jugar
    public void CargarNivel()
    {
        // "SampleScene" es el nombre por defecto de tu nivel. 
        // Si le cambiaste el nombre, ponlo aquí exacto entre comillas.
        SceneManager.LoadScene("SampleScene"); 
    }

    // Función para el botón Salir
    public void SalirDelJuego()
    {
        Debug.Log("Saliendo del juego..."); // Esto solo se ve en Unity
        Application.Quit(); // Esto cierra el juego de verdad (en .exe)
    }

    // Función nueva para volver al Menú Principal
    public void VolverAlMenu()
    {
        Time.timeScale = 1f; // Importante: Por si el juego estaba pausado
        SceneManager.LoadScene("Menu"); // Asegúrate de que tu escena se llama "Menu"
    }
}