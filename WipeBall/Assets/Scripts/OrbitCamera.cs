using UnityEngine;

public class OrbitCamera : MonoBehaviour
{
    public Transform target;       // La bola (Player)
    public float distance = 10.0f; // Distancia de la cámara
    public float xSpeed = 120.0f;  // Velocidad giro horizontal
    public float ySpeed = 120.0f;  // Velocidad giro vertical

    public float yMinLimit = -20f; // Tope para no bajar mucho
    public float yMaxLimit = 80f;  // Tope para no subir mucho

    private float x = 0.0f;
    private float y = 0.0f;

    void Start()
    {
        Vector3 angles = transform.eulerAngles;
        x = angles.y;
        y = angles.x;

        // Ocultar y bloquear el cursor en el centro de la pantalla
        Cursor.lockState = CursorLockMode.Locked;
    }

    void LateUpdate()
    {
        if (target)
        {
            // Leer movimiento del ratón
            x += Input.GetAxis("Mouse X") * xSpeed * 0.02f;
            y -= Input.GetAxis("Mouse Y") * ySpeed * 0.02f;

            // Limitar el ángulo vertical
            y = ClampAngle(y, yMinLimit, yMaxLimit);

            // Calcular rotación y posición
            Quaternion rotation = Quaternion.Euler(y, x, 0);
            Vector3 position = rotation * new Vector3(0.0f, 0.0f, -distance) + target.position;

            // Aplicar cambios
            transform.rotation = rotation;
            transform.position = position;
        }
    }

    // Función auxiliar para limitar ángulos correctamente
    static float ClampAngle(float angle, float min, float max)
    {
        if (angle < -360F) angle += 360F;
        if (angle > 360F) angle -= 360F;
        return Mathf.Clamp(angle, min, max);
    }
}