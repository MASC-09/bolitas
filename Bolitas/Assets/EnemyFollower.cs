using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollower : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;

    private enum MovementState {idle, running};
    private MovementState currentState = MovementState.idle;
    private Animator anim;
    private SpriteRenderer sprite;
    private Rigidbody2D rb;
    private Transform target;
    private GameObject player;
    // private CharacterController _controller;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        player = GameObject.FindWithTag("Player");
        target = player.transform;
    }


    // Update is called once per frame
    void Update()
    {
        //move towards the player
        Vector3 direction = target.position - transform.position;

        // direction = direction.normalized;
        // Vector3 velocity = direction * moveSpeed;

        transform.position = Vector3.MoveTowards(transform.position, target.position, moveSpeed* Time.deltaTime);
        // _controller.Move(velocity * Time.deltaTime);

        UpdateAnimationState();
    }

    private void UpdateAnimationState()
    {
        Vector2 direction = transform.position;
        float dirX = direction.x;

        if (dirX > 0f)
        {
            // Debug.Log(rb.velocity.x);
            currentState = MovementState.running;
            sprite.flipX = true;
        }
        else if (dirX < 0f)
        {
            // Debug.Log(rb.velocity.x);
            currentState = MovementState.running;
            sprite.flipX = false;
        }
        else
        {
            currentState = MovementState.idle;
        }
        anim.SetInteger("state", (int)currentState);
    }
}
