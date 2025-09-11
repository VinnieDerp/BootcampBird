using UnityEngine;
using UnityEngine.InputSystem;

public class BirdMovement : MonoBehaviour
{
    public float jumpSpeed;
    public float movementSpeed;
    public Rigidbody player;
    private Vector3 movement;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }


    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();
        movement.x = movementVector.x;
    }

    void OnJump()
    {
        player.AddForce(Vector3.up * jumpSpeed, ForceMode.Impulse);
    }

    void FixedUpdate()
    {
        player.AddForce(movement * movementSpeed);
    }
}
