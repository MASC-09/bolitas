using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float bulletSpeed = 20f;
    [SerializeField]  private int bulletDamage = 40;
    [SerializeField] private float knockBackPower = 5f;
    [SerializeField] private GameObject impactEffect; //Add effect when the bullet hits something.
    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * bulletSpeed; 
    }

    void OnTriggerEnter2D (Collider2D hitInfo)
    {
        Enemy enemy = hitInfo.GetComponent<Enemy>();
        Rigidbody2D enemyRb = hitInfo.GetComponent<Rigidbody2D>();

        if (enemy != null)
        {
            Debug.Log(hitInfo.name);
            enemy.TakeDamage(bulletDamage);
            knockBack(enemyRb);
            // Instantiate(impactEffect, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }

    private void knockBack(Rigidbody2D enemyRb)
    {
         // Calculate the direction of the knockback based on the position of the enemy relative to the attack point
            Vector3 knockbackDirection = enemyRb.transform.position - transform.position;
            knockbackDirection.y = 0; // Ignore the y-axis to avoid launching enemies into the air

            // Apply the knockback force to the enemy's rigidbody
            enemyRb.AddForce(knockbackDirection.normalized * knockBackPower, ForceMode2D.Impulse);

    }
    
}
