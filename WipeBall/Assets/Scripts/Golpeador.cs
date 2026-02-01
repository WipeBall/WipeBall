using UnityEngine;

public class Golpeador : MonoBehaviour
{
    public float fuerzaGolpe = 40f; // Sube la fuerza (al ser Trigger necesitamos más chicha)

    // OJO: Ahora usamos OnTriggerEnter (Entrar en zona)
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Rigidbody rbJugador = other.attachedRigidbody; // Forma más segura de pillar el RB

            if (rbJugador != null)
            {
                // Calculamos la dirección del golpe
                Vector3 direccionGolpe = (other.transform.position - transform.position).normalized;
                
                // Añadimos fuerza hacia arriba y hacia afuera
                direccionGolpe += Vector3.up * 0.5f;

                // Paramos la bola en seco antes de golpearla (para que no siga traspasando)
                rbJugador.linearVelocity = Vector3.zero; 

                // ¡PUM!
                rbJugador.AddForce(direccionGolpe * fuerzaGolpe, ForceMode.Impulse);
            }
        }
    }
}