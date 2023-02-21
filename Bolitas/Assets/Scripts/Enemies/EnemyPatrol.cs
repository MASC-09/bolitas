using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    public Transform[] patrolPoints; // An array to hold the enemy's patrol points
    public float moveSpeed = 2f; // The speed at which the enemy moves
    private int currentPointIndex = 0; // The index of the current patrol point

    private enum MovementState {idle, running};
    private MovementState currentState = MovementState.idle;
    private Animator anim;
    private SpriteRenderer sprite;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = patrolPoints[currentPointIndex].position; // Set the enemy's initial position to the first patrol point
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // Move towards the current patrol point
        transform.position = Vector2.MoveTowards(transform.position, patrolPoints[currentPointIndex].position, moveSpeed * Time.deltaTime);

            // If the enemy has reached the current patrol point, move to the next one
            if (Vector2.Distance(transform.position, patrolPoints[currentPointIndex].position) < 0.1f)
             {
                currentPointIndex++;
                // If the enemy has reached the end of the patrol points array, loop back to the beginning
                if (currentPointIndex >= patrolPoints.Length)
                {
                    currentPointIndex = 0;
                }
            }
        UpdateAnimationState();
    }

    private void UpdateAnimationState()
    {
        Vector2 direction = patrolPoints[currentPointIndex].position - transform.position;
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
