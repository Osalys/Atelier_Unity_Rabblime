using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    Rigidbody rb;



    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody>();

    }

    void Update ()
    {
        if (transform.position.magnitude > 1000.0f)
        {
            Destroy(gameObject);
        }
    }

   

    void OnCollisionEnter(Collision other)
    {
        Destroy(gameObject);
    }

}
