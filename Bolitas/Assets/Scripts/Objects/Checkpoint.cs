using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Checkpoint : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.name);
        // if (collision.CompareTag("Player"))
        // {
        //     collision.GetComponent<PlayerRespawn>().ReachedCheckpoint(SceneManager.GetActiveScene().name, collision.transform.position.x, collision.transform.position.y);
        //     //GetComponent<Animator>().Play("Flagout");
        // }
    }
}
