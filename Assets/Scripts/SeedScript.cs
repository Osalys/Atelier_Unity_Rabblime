using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeedScript : MonoBehaviour
{
    
    private void OnTriggerEnter (Collider other)
    {
        HenryController controller = other.GetComponent<HenryController>();
        
        if (controller != null)
        {
            if (controller.seed < controller.maxSeed)
            {
                controller.ChangeSeed(3);
                GameObject.Find("Plantations").GetComponent<PlantationScript>().CanPlant = true;
                GetComponent<AudioSource>().Play();
                GetComponent<MeshRenderer>().enabled = false;
                GetComponent<BoxCollider>().enabled = false;
                Destroy(transform.gameObject, 0.13f);
            }
            
        }
     

    }

   

}
