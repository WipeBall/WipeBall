using UnityEngine;
using UnityEngine.SceneManagement;
public class SistemaPausa : MonoBehaviour
{
    public GameObject elPanel;
    public OrbitCamera scriptDeMovimiento; 
    public bool estaPausado = false;
   void Start()
    {
        if (elPanel != null) elPanel.SetActive(false);
        Time.timeScale = 1f;
        estaPausado = false;
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
        if(scriptDeMovimiento != null) scriptDeMovimiento.enabled = false;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    public void ReanudarJuego()
    {
        elPanel.SetActive(false);
        Time.timeScale = 1f;
        estaPausado = false;
        if(scriptDeMovimiento != null) scriptDeMovimiento.enabled = true;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    public void IrAlMenuPrincipal()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }
}