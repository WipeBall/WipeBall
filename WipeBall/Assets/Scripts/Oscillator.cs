using UnityEngine;

public class Oscillator : MonoBehaviour
{
    public float speed = 2f;
    public float height = 3f; // Cuánto sube y baja
    private Vector3 startPos;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        // Mueve el objeto arriba y abajo suavemente (PingPong)
        float newY = Mathf.PingPong(Time.time * speed, height);
        transform.position = new Vector3(startPos.x, startPos.y + newY, startPos.z);
    }
}