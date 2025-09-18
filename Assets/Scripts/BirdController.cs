using UnityEngine;
using UnityEngine.InputSystem;

public class BirdMovement : MonoBehaviour
{
    [SerializeField]    private ObstacleHandler _obstacleSpawner;
    [SerializeField]    private GameHandler _gameHandler;
    [SerializeField]    private AudioHandler _audioHandler;
    [SerializeField]    private float jumpSpeed;
    [SerializeField]    private float movementSpeed;
    private Rigidbody rb;
    private Animation anim;
    private Vector3 movement;
    private bool allowJump;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animation>();
        anim.Play();

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
        
        _audioHandler.PlaySFX(_audioHandler.birdFlap);
    }

    void FixedUpdate()
    {
        rb.AddForce(movement * movementSpeed);
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Obstacle"))
        {
            _obstacleSpawner.enabled = false;
            enabled = false;
            allowJump = false;
        }

        else if (other.gameObject.CompareTag("Ground"))
        {
            _obstacleSpawner.enabled = false;
            enabled = false;
            rb.isKinematic = true;

            _audioHandler.PlaySFX(_audioHandler.gameOver);
            _gameHandler.EndGame();
        }
    }
}
