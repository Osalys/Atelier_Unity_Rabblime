using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeManager : MonoBehaviour
{

    public Transform slimePrefab;
    public float zoneSize = 20;
    public int nbSlimeCreate = 10;


    // Start is called before the first frame update
    void Start()
    {
        Transform SlimePrev = null;
        for (int i = 0; i < nbSlimeCreate; i++)
        {
            //creation du slime
            Transform slime = GameObject.Instantiate<Transform>(slimePrefab);
            slime.parent = transform; //rangement dans la hierachie
            slime.position = Random.insideUnitSphere * zoneSize; // on les place aleatoirement
            slime.position = new Vector3(slime.localPosition.x, 0, slime.localPosition.y);

            slime.GetComponent<SlimeScript>().vitesseMax *= Random.Range(0.5f, 2.0f);
            slime.GetComponent<SlimeScript>().acceleration *= Random.Range(0.5f, 2.0f);

            if (Random.Range(0.0f, 1.0f) < 0.5)
            {
                slime.GetComponent<SlimeScript>().target = SlimePrev;
            }

            SlimePrev = slime;
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
}
