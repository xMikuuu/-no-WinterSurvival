using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float movementSpeed;
    private float speedX;
    private float speedY;
    Rigidbody2D rigidBody;

    private void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        speedX = Input.GetAxisRaw("Horizontal") * movementSpeed;
        speedY = Input.GetAxisRaw("Vertical") * movementSpeed;
    }

    private void FixedUpdate()
    {
        rigidBody.linearVelocity = new Vector2 (speedX, speedY).normalized*movementSpeed; // vector have to be normalized so character is not moving faster diagonally
    }
}
