using UnityEngine;
using UnityEngine.SceneManagement;  
public class MenuManager : MonoBehaviour
{
    public void CargarNivel()
    {
        SceneManager.LoadScene("SampleScene"); 
    }
    public void SalirDelJuego()
    {
        Debug.Log("Saliendo del juego...");  
        Application.Quit();  
    }
    public void VolverAlMenu()
    {
        Time.timeScale = 1f;  
        SceneManager.LoadScene("Menu");  
    }
}