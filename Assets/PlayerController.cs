using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{

    private float movementX, movementY; 

    [SerializeField] private float speed = 5.0f; 
    [SerializeField] private float jumpForce = 200f;
    private Rigidbody2D rb; 
    private bool isGrounded; 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>(); 
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // float translateX = movementX * speed * Time.deltaTime; 
        // float translateY = movementY * speed * Time.deltaTime; 

        // transform.Translate(new Vector2(translateX, translateY));

        rb.linearVelocity = new Vector2(movementX * speed, rb.linearVelocity.y);

        if(movementY > 0 && isGrounded)
        {
            rb.AddForce(new Vector2(0, jumpForce));   
        }
    }

    void OnMove(InputValue value)
    {
        Vector2 v = value.Get<Vector2>(); 

        movementX = v.x;
        movementY = v.y; 

        Debug.Log($"MovementX: {movementX}, MovementY: {movementY}");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;            
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false; 
        }
    }
}
