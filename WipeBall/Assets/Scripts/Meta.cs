using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class Meta : MonoBehaviour
{
    [Header("Configuración Visual")]
    public GameObject efectoConfeti;
    public GameObject panelVictoria;
    public TextMeshProUGUI textoTiempoFinal;

    [Header("Referencias")]
    public HUD scriptHUD;
    public OrbitCamera scriptCamara; 
    
    public SistemaPausa scriptPausa; 

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GanarNivel();
        }
    }

    void GanarNivel()
    {        
        if (efectoConfeti != null) efectoConfeti.SetActive(true);

        float tiempoFinal = 0f;
        if (scriptHUD != null)
        {
            scriptHUD.PararCronometro(); 
            tiempoFinal = scriptHUD.tiempoActual;
            if (textoTiempoFinal != null) textoTiempoFinal.text = "Tiempo: " + scriptHUD.textoTiempo.text;
        }

        GestionarRecords(tiempoFinal);

        if (panelVictoria != null) panelVictoria.SetActive(true);


        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        if (scriptCamara != null) scriptCamara.enabled = false;

        if (scriptPausa != null) 
        {
            scriptPausa.enabled = false; 
        }
    }

    public void ReintentarNivel() { SceneManager.LoadScene(SceneManager.GetActiveScene().name); }
    public void IrAlMenu() { SceneManager.LoadScene("Menu"); }
    void GestionarRecords(float tiempoNuevo) { /* ... */ }
}