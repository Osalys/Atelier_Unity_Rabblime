using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantationScript : MonoBehaviour
{
    public GameObject carottePrefab;
    public bool CanPlant = false;

   
    // public bool Activation = false;


    private Transform plantationPosition;
    

    private void Awake()
    {
        plantationPosition = GameObject.FindGameObjectWithTag("Plantation").transform;
    }

    private void Start()
    {
       
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && CanPlant)
        {
            GameObject carotte = Instantiate<GameObject>(carottePrefab);
            carotte.transform.SetParent(plantationPosition);
            carotte.transform.localPosition = new Vector3(0, 1, 0);


            Debug.Log(other.name + " est a l'interieur du trigger");
        }

        CanPlant = false;
    }
}
