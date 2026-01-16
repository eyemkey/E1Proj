using UnityEngine;

public class BouncyBall : MonoBehaviour
{

    private Rigidbody2D rb; 
    [SerializeField] private float jumpPower; 
    [SerializeField] private float jumpPowerThreshold=0.1f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        rb.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
        jumpPower /= 2; 
        if(jumpPower < jumpPowerThreshold)
        {
            jumpPower = 0;
        }
    }
}
