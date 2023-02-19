using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public GameObject powerUp;
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
        if (collision.gameObject.CompareTag("PowerUp"))
        {
            Damage damage = GetComponent<Damage>();
            Destroy(collision.gameObject);
            //Lack of damage increase, I need help here
        }
    }
}
