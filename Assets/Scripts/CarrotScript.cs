using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarrotScript : MonoBehaviour
{

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.collider.tag == "Player")
        {

            GetComponent<AudioSource>().Play();
            GetComponent<MeshRenderer>().enabled = false;
            GetComponent<BoxCollider>().enabled = false;
            Destroy(transform.gameObject, 0.15f);

        }

    }


}
