using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class BirdMovement : MonoBehaviour
{
    public float jumpSpeed;
    public float movementSpeed;
    private Rigidbody rb;
    private Vector3 movement;
    public ObstacleSpawner obstacleSpawner;
    public GameHandler gameHandler;
    private bool allowJump;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        allowJump = true;
    }


    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();
        movement.x = movementVector.x;
    }

    void OnJump()
    {
        if (Time.timeScale == 0 || !allowJump) return;
        rb.AddForce(Vector3.up * jumpSpeed, ForceMode.Impulse);
    }

    void FixedUpdate()
    {
        rb.AddForce(movement * movementSpeed);
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Obstacle"))
        {
            obstacleSpawner.enabled = false;
            enabled = false;
            allowJump = false;
        }

        else if (other.gameObject.CompareTag("Ground"))
        {
            obstacleSpawner.enabled = false;
            enabled = false;
            rb.isKinematic = true;
            gameHandler.Reset();
        }
    }
}
