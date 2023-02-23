using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public GameObject poweredBulletPrefab;
    public bool isPoweredUp = false;
    [SerializeField] private float timeToWearOff = 2f;
    // void Start()
    // {

    // }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetButtonDown("Fire1"))
        {
            if (isPoweredUp)
            {
                ShootPoweredUp();
                StartCoroutine(WearOffPowerUp());
            }
            else
            {
                Shoot();
            }
        }
    }

    void Shoot()
    {
        Instantiate(bulletPrefab, firePoint.position , firePoint.rotation);
    }

    void ShootPoweredUp()
    {
        Instantiate(poweredBulletPrefab, firePoint.position, firePoint.rotation);
    }

    public void setIsPoweredUp(bool state)
    {
        isPoweredUp = state;
    }

    IEnumerator WearOffPowerUp()
    {    
        while (true)
        {
            yield return new WaitForSeconds(timeToWearOff);
            setIsPoweredUp(false);
        }
    }
}
