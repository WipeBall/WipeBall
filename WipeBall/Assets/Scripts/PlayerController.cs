using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 20f;
    public float jumpForce = 7f; // Fuerza del salto
    
    private Rigidbody rb;
    private Transform cameraTransform;
    private bool isGrounded; // ¿Estamos tocando el suelo?

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        cameraTransform = Camera.main.transform;
    }

    void Update()
    {
        // DETECTAR SALTO (Solo si pulsas Espacio Y estás en el suelo)
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false; // Ya no estamos en el suelo
        }
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 forward = cameraTransform.forward;
        Vector3 right = cameraTransform.right;

        forward.y = 0f;
        right.y = 0f;
        forward.Normalize();
        right.Normalize();

        Vector3 movement = (forward * moveVertical + right * moveHorizontal).normalized;
        rb.AddForce(movement * speed);
    }

    // CUANDO CHOCAMOS CON ALGO (DETECTAR SUELO)
    void OnCollisionEnter(Collision collision)
    {
        // Si chocamos contra algo que tenga el Tag "Suelo"
        if (collision.gameObject.CompareTag("Suelo"))
        {
            isGrounded = true;
        }
    }
}