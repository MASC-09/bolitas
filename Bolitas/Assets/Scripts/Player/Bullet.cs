using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float bulletSpeed = 20f;
    [SerializeField]  private int bulletDamage = 40;

    [SerializeField] private GameObject impactEffect; //Add effect when the bullet hits something.
    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * bulletSpeed; 
    }

    void OnTriggerEnter2D (Collider2D hitInfo)
    {
        Enemy enemy = hitInfo.GetComponent<Enemy>();
        if (enemy != null)
        {
            Debug.Log(hitInfo.name);
            enemy.TakeDamage(bulletDamage);
            // Instantiate(impactEffect, transform.position, transform.rotation);
            Destroy(gameObject);
        }


    }

    
}
