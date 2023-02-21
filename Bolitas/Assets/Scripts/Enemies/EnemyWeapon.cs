using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeapon : MonoBehaviour
{
    [SerializeField] private Transform bee_firePoint;
    [SerializeField] private GameObject bee_sting;
    [SerializeField] private Animator anim;
    [SerializeField] private float shotInterval = 2f;

    
    void Start()
    {
        StartCoroutine(ShootAtInterval());
        anim = GetComponent<Animator>();
    }

    // // Update is called once per frame
    // void Update()
    // {
        
    //     Shoot();
    // }

    IEnumerator ShootAtInterval()
    {    
        {
            while (true)
            {
                yield return new WaitForSeconds(shotInterval);
                anim.SetTrigger("shootSting");
                Instantiate(bee_sting, bee_firePoint.position, bee_firePoint.rotation);
            }
        }
    }
}
