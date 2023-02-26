using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int health = 100;
    [SerializeField] private Animator anim;
    // [SerializeField] private deathEffect;

    void Start()
    {
        anim = GetComponent<Animator>();
    }
    public void TakeDamage(int damage)
    {
        health -= damage;
        anim.SetTrigger("hit");
        if (health <= 0)
        {
            Die();
            if (SceneManager.GetActiveScene().name == "Level_2")
            {
                FindObjectOfType<Counter>().AddEnemy();
            }
        }
    }

    void Die()
    {
        //Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
