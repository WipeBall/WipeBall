using UnityEngine;
public class Golpeador : MonoBehaviour
{
    public float fuerzaGolpe = 40f;  
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Rigidbody rbJugador = other.attachedRigidbody;  
            if (rbJugador != null)
            {
                Vector3 direccionGolpe = (other.transform.position - transform.position).normalized;
                direccionGolpe += Vector3.up * 0.5f;
                rbJugador.linearVelocity = Vector3.zero; 
                rbJugador.AddForce(direccionGolpe * fuerzaGolpe, ForceMode.Impulse);
            }
        }
    }
}