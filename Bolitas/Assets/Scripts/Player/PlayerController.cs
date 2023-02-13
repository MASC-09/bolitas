using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float jumpSpeed;

    private enum MovementState { idle, running, jumping, falling}; //create you own data stype
    bool isGrounded;

    Rigidbody2D rb;
    // Start is called before the first frame update
    private Animator anim;
    private SpriteRenderer sprite;
    private float dirX = 0;

    private void Start()
    {
        // Debug.Log("Hello World");
        rb = GetComponent<Rigidbody2D>();   
        anim = GetComponent<Animator>(); 
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    private void Update()
    {
        dirX = Input.GetAxisRaw("Horizontal"); //raw get the player movement to 0 inmediatly after the key is no longer pressed 
        rb.velocity = new Vector2(dirX * speed, rb.velocity.y);
        
        // if(rb.velocity.x < 0 )
        // {
        //     transform.Rotate(0f, 180f,0f);
        // }

        if (Input.GetButtonDown("Jump") && CheckGround.isGrounded) 
        {
            //salto sencillo
            rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);
        }

        UpdateAnimationState();
    }

    private void UpdateAnimationState()
    {
        MovementState state;
        if (dirX > 0f)
        {
            state = MovementState.running;
            sprite.flipX = false;
        }
        else if (dirX < 0f)
        {
            state = MovementState.running;
            sprite.flipX = true;
        }
        else 
        {
            state = MovementState.idle;
        }

        if (rb.velocity.y > .1f)
        {
            state = MovementState.jumping;
        }
        else  if (rb.velocity.y < -.1f)
        {
            state = MovementState.falling;
        }

        anim.SetInteger("state",(int)state);
    }
}
