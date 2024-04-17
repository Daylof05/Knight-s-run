using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float horizontalSpeed = 10.0f;
    public float jumpForce = 700.0f;
    public float turnSpeed = 100.0f; // Vitesse de rotation
    public float maxRotationAngle = 20.0f; // Angle maximal de rotation
    private Rigidbody rb;
    private Animator animator;
    private bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // Gestion du saut
        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
            animator.SetBool("IsJumping", true);
        }

        // Tourner le personnage avec un angle limité
        if (isGrounded)
        {
            float horizontalInput = Input.GetAxis("Horizontal");
            if (horizontalInput != 0)
            {
                // Calculer l'angle de rotation cible basé sur l'input
                float targetAngle = Mathf.Clamp(horizontalInput * maxRotationAngle, -maxRotationAngle, maxRotationAngle);
                Quaternion targetRotation = Quaternion.Euler(0, targetAngle, 0);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, turnSpeed * Time.deltaTime);
            }
        }
    }

    void FixedUpdate()
    {
        // Mouvement horizontal
        float h = Input.GetAxis("Horizontal") * horizontalSpeed;
        rb.velocity = new Vector3(h, rb.velocity.y, 0);

        // Restreindre le mouvement horizontal entre -5 et 5 sur l'axe X
        float clampedX = Mathf.Clamp(rb.position.x, -5f, 5f);
        rb.position = new Vector3(clampedX, rb.position.y, rb.position.z);
    }

    void OnCollisionEnter(Collision collision)
    {
        // Vérifier que le joueur est en collision avec le sol
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            animator.SetBool("IsJumping", false);
        }
    }
}