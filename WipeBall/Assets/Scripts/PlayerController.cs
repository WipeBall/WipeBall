using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 10f;
    public float jumpForce = 5f;
    private Rigidbody rb;
    private bool isGrounded;
    private Transform cameraTransform; // Referencia a la cámara

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        // Busca la cámara principal automáticamente
        cameraTransform = Camera.main.transform;
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        // 1. Obtenemos la dirección hacia donde mira la cámara
        Vector3 forward = cameraTransform.forward;
        Vector3 right = cameraTransform.right;

        // 2. Aplanamos la dirección (para que no intente volar o hundirse en el suelo)
        forward.y = 0f;
        right.y = 0f;
        forward.Normalize();
        right.Normalize();

        // 3. Calculamos la dirección de movimiento relativa a la cámara
        Vector3 movement = (forward * moveVertical + right * moveHorizontal).normalized;

        // 4. Aplicamos la fuerza
        rb.AddForce(movement * speed);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Suelo"))
        {
            isGrounded = true;
        }
    }
}