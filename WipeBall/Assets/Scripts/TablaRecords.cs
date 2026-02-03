using UnityEngine;
using TMPro;
public class TablaRecords : MonoBehaviour
{
    public TextMeshProUGUI[] filasTexto; 
    void Start()
    {
        for (int i = 0; i < 5; i++)
        {
            float tiempo = PlayerPrefs.GetFloat("Record_" + i, 0);
            if (tiempo == 0 || tiempo == 99999f)  
            {
                filasTexto[i].text = (i + 1) + ". --:--";
            }
            else
            {
                int min = Mathf.FloorToInt(tiempo / 60F);
                int sec = Mathf.FloorToInt(tiempo % 60F);
                int mil = Mathf.FloorToInt((tiempo * 100F) % 100F);
                filasTexto[i].text = string.Format("{0}. {1:00}:{2:00}:{3:00}", (i + 1), min, sec, mil);
            }
        }
    }
    [ContextMenu("Borrar Records")]
    public void BorrarTodo()
    {
        PlayerPrefs.DeleteAll();
        Debug.Log("Records Borrados");
    }
}