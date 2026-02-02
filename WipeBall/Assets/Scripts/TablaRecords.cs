using UnityEngine;
using TMPro;

public class TablaRecords : MonoBehaviour
{
    // Una lista (array) donde arrastraremos tus 5 textos del Canvas
    public TextMeshProUGUI[] filasTexto; 

    void Start()
    {
        // Recorremos los 5 huecos
        for (int i = 0; i < 5; i++)
        {
            // Leemos el tiempo guardado. Si no existe, usamos 0.
            // Usamos "Record_" + i para guardar Record_0, Record_1, etc.
            float tiempo = PlayerPrefs.GetFloat("Record_" + i, 0);

            if (tiempo == 0 || tiempo == 99999f) // 99999 será nuestro código de "vacío"
            {
                filasTexto[i].text = (i + 1) + ". --:--";
            }
            else
            {
                // Formateamos el tiempo bonito
                int min = Mathf.FloorToInt(tiempo / 60F);
                int sec = Mathf.FloorToInt(tiempo % 60F);
                int mil = Mathf.FloorToInt((tiempo * 100F) % 100F);

                filasTexto[i].text = string.Format("{0}. {1:00}:{2:00}:{3:00}", (i + 1), min, sec, mil);
            }
        }
    }
    
    // Función extra para borrar todo (por si quieres reiniciar)
    [ContextMenu("Borrar Records")]
    public void BorrarTodo()
    {
        PlayerPrefs.DeleteAll();
        Debug.Log("Records Borrados");
    }
}