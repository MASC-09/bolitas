using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    public float speed;
    public float jumpAmount;
    float inputMovement;

    Rigidbody2D rb;

    bool isOnGround;
    public Transform groundCheck;
    public LayerMask groundMask;

    public float radius;
    // Start is called before the first frame update
    void Start()
    {
        rb.GetComponent<Rigidbody2D>();   
    }

    private void FixedUpdate() 
    {
        isOnGround = Physics2D.OverlapCircle(groundCheck.position, radius, groundMask);

        inputMovement = Input.GetAxis("Horizontal"); //arrow key and "A" and "D"
        rb.velocity = new Vector2(inputMovement * speed, rb.velocity.y);

    }
    // Update is called once per frame
    void Update()
    {
        if (isOnGround && Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = Vector2.up * jumpAmount;
        }
    }
}
