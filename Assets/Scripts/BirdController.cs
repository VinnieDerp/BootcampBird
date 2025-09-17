using UnityEngine;
using UnityEngine.InputSystem;

public class BirdMovement : MonoBehaviour
{
    [SerializeField]
    private ObstacleHandler obstacleSpawner;
    [SerializeField]
    private GameHandler gameHandler;
    [SerializeField]
    private float jumpSpeed;
    [SerializeField]
    private float movementSpeed;
    private Rigidbody rb;
    private Vector3 movement;
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
