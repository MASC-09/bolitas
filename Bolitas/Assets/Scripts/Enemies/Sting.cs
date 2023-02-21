using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sting : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float stingSpeed = 10f;
    // [SerializeField] private int stingDamange =40;
    [SerializeField] private GameObject brokenSting;
    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = new Vector2(0, -transform.position.y * stingSpeed);
    }

    void OnTriggerEnter2D(Collider2D collision) 
    {
        if (collision.CompareTag("Player"))
        {
            PlayerLife player = collision.GetComponent<PlayerLife>();
            player.Die();
        }
            // Debug.Log(collision.name);
        Destroy(gameObject);
    }


}
