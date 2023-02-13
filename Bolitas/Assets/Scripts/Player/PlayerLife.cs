using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    private Animator anim;
    private Rigidbody2D rb;

    private void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }
    
    private void OnCollisionEnter2D(Collision2D collision) 
    {
        if (collision.gameObject.CompareTag("Trap"))
        {
            Die();
        }
        
    }

    private void Die() //add player Death Animation
    {
        rb.bodyType = RigidbodyType2D.Static;
        anim.SetTrigger("death");
        //Level reset could be handled here, adding a delay and then runing RestartLevel().
        //However It  it handled running the medthod, after the death animation ends.
    }

    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
