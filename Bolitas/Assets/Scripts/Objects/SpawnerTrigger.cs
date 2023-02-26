using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerTrigger : MonoBehaviour
{
    public GameObject[] Spawns;

    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            foreach (GameObject spawn in Spawns)
            {   
                PigSpawner pSpawn = spawn.GetComponent<PigSpawner>();
                pSpawn.setIsOn(true);
                Debug.Log("Pig Spawnner Activated!");
            }
            Destroy(gameObject);
        }
    }
}
