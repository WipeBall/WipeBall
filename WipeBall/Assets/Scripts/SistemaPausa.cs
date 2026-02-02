using UnityEngine;
using UnityEngine.SceneManagement;
public class SistemaPausa : MonoBehaviour
{
    public GameObject elPanel;
    public OrbitCamera scriptDeMovimiento; 
    public bool estaPausado = false;
    
   void Start()
    {
        // 1. CORRECCIÓN: Obligamos al panel a esconderse al arrancar
        if (elPanel != null) elPanel.SetActive(false);
        
        // 2. Aseguramos que el tiempo corre
        Time.timeScale = 1f;
        estaPausado = false;

        // 3. Bloqueamos el ratón
        Cursor.lockState = CursorLockMode.Locked; 
        Cursor.visible = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (estaPausado) ReanudarJuego();
            else PausarJuego();
        }
    }

    public void PausarJuego()
    {
        elPanel.SetActive(true);
        Time.timeScale = 0f;
        estaPausado = true;

        // 1. Apagamos el movimiento de cámara para que no gire
        if(scriptDeMovimiento != null) scriptDeMovimiento.enabled = false;

        // 2. Liberamos el ratón para poder hacer clic
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void ReanudarJuego()
    {
        elPanel.SetActive(false);
        Time.timeScale = 1f;
        estaPausado = false;

        // 1. Encendemos la cámara otra vez
        if(scriptDeMovimiento != null) scriptDeMovimiento.enabled = true;

        // 2. Ocultamos el ratón para seguir jugando
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void IrAlMenuPrincipal()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }
}