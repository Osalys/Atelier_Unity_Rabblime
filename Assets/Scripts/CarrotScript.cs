using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarrotScript : MonoBehaviour
{
    Rigidbody rigidbody;

    void Start ()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    

    private void OnTriggerEnter(Collider other)
    {
        HenryController controller = other.GetComponent<HenryController>();

        if (controller != null)
        {
            controller.ChangeCarrot(3);
            GetComponent<AudioSource>().Play();
            GetComponent<MeshRenderer>().enabled = false;
            GetComponent<BoxCollider>().enabled = false;
            Destroy(transform.gameObject, 0.13f);
        }


    }



}
