using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tir : MonoBehaviour
{
    public GameObject projectilePrefab;
    public int force = 30;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.E))
        {
            Launch();

        }
    }

    void Launch()
    {
        GameObject projectileObject = Instantiate(projectilePrefab, transform.position, Quaternion.identity) as GameObject;
        projectileObject.GetComponent<Rigidbody>().velocity = transform.TransformDirection(Vector3.forward * force);
      
    }
}
