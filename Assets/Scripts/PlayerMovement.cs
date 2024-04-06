using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5.0f;
    public float jumpForce = 5;
    private bool isOnGround = true;
    private int jumpCount = 0;
    private float horizontalInput;
    private float forwardInput;
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // Get input
        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");

        // Player movement
        transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);
        transform.Translate(Vector3.right * Time.deltaTime * speed * horizontalInput);

        // Jumping 
        if (Input.GetKeyDown(KeyCode.Space) && (isOnGround || jumpCount < 2))
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            jumpCount++;
            isOnGround = false;
        }
    }

    // Check if player is grounded
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
            jumpCount = 0;
        }
    }
}
