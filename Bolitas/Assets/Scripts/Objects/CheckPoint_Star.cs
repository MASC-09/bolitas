using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CheckPoint_Star : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<PlayerRespawn>().ReachedCheckpoint(SceneManager.GetActiveScene().name, collision.transform.position.x, collision.transform.position.y);
            //GetComponent<Animator>().Play("Flagout");
        }
    }
}
