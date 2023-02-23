using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        Weapon weapon = null;
        if (collision.name == "GroundCheck")
        {
            weapon = collision.GetComponentInParent<Weapon>();
        }
        else 
        {
            weapon = collision.GetComponent<Weapon>();
        }
        weapon.setIsPoweredUp(true);
        Destroy(gameObject);
    }
}
