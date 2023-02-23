using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PigSpawner : MonoBehaviour
{
    
    public GameObject Pig;
    [SerializeField] private float spawnRate = 2.0f;
    [SerializeField] private int spawnLimit = 5;
    private int enemiesSpawned = 0;


    void Start()
    {
        StartCoroutine(SpawnPigs());
    }

    IEnumerator SpawnPigs()
    {
        while (enemiesSpawned < spawnLimit)
        {
            yield return new WaitForSeconds(spawnRate);
            Instantiate(Pig, transform.position, transform.rotation);
            enemiesSpawned++;
        }
    }
}
