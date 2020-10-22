using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeedScript : MonoBehaviour
{
    
    private void OnCollisionEnter(Collision collision)
    {
        
        if (collision.collider.tag=="Player")
        {
            GameObject.Find("Plantations").GetComponent<PlantationScript>().CanPlant = true;

            GetComponent<AudioSource>().Play();
            GetComponent<MeshRenderer>().enabled = false;
            GetComponent<BoxCollider>().enabled = false;
            Destroy(transform.gameObject, 0.15f);

            
        }

    }

   

}
