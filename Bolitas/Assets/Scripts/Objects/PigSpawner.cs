using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PigSpawner : MonoBehaviour
{
    
    public GameObject Pig;
    [SerializeField] private float spawnRate = 2.0f;
    [SerializeField] private int spawnLimit = 5;
    private int enemiesSpawned = 0;
    [SerializeField] private bool isOn = false;

    private Coroutine spawnCoroutine;

    void Start()
    {
        if(isOn)
        {
            StartSpawnCoroutine();
        }
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

    public void setIsOn(bool state)
    {
        isOn = state;
        if(isOn)
        {
            StartSpawnCoroutine();
        }
        else 
        {
            StopSpawnCoroutine();
        }
    }

    private void StartSpawnCoroutine()
    {
        if (spawnCoroutine == null)
        {
            spawnCoroutine = StartCoroutine(SpawnPigs());
        }
    }


    private void StopSpawnCoroutine()
    {
        if (spawnCoroutine != null)
        {
            StopCoroutine(spawnCoroutine);
            spawnCoroutine =  null;
        }
    }
}
