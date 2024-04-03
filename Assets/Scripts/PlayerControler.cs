using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float horizontalSpeed = 10.0f;
    public float forwardSpeed = 5.0f;
    public float jumpForce = 700.0f;
    private Rigidbody rb;
    private float timeSinceLastJump = 0.0f; // Timer pour le saut

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Incrémentation du timer
        timeSinceLastJump += Time.deltaTime;

        // Gestion du saut
        if (Input.GetButtonDown("Jump") && timeSinceLastJump >= 1.0f) // Si une seconde s'est écoulée
        {
            rb.AddForce(Vector3.up * jumpForce);
            timeSinceLastJump = 0.0f; // Réinitialisation du timer après le saut
        }
    }

    void FixedUpdate()
    {
        // Mouvement horizontal
        float h = Input.GetAxis("Horizontal") * horizontalSpeed;

        // Appliquer la vélocité horizontale et le mouvement automatique vers l'avant
        rb.velocity = new Vector3(h, rb.velocity.y, forwardSpeed);

        // Restreindre le mouvement horizontal entre -5 et 5 sur l'axe X
        float clampedX = Mathf.Clamp(rb.position.x, -5f, 6f);
        
        // Appliquer la position contrainte
        rb.position = new Vector3(clampedX, rb.position.y, rb.position.z);
    }
}
