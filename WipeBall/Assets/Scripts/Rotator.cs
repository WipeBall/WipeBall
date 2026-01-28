using UnityEngine;

public class Rotator : MonoBehaviour
{
    public float rotationSpeed = 100f;

    void Update()
    {
        // Rota en el eje Y (como un helicóptero o barrera)
        transform.Rotate(new Vector3(0, rotationSpeed, 0) * Time.deltaTime);
    }
}