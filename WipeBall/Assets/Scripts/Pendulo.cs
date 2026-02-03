using UnityEngine;
public class Pendulo : MonoBehaviour
{
    public float velocidad = 2.0f;   
    public float anguloMaximo = 75.0f;  
    public float desfase = 0.0f;     
    void Update()
    {
        float angulo = anguloMaximo * Mathf.Sin(Time.time * velocidad + desfase);
        transform.localRotation = Quaternion.Euler(0, 0, angulo);
    }
}