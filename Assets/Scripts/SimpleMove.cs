using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleMove : MonoBehaviour
{
    [SerializeField] private Vector3 movePerSec = new Vector3 (1,0,0);
    private void Awake()
    {
        Transform transform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += movePerSec * Time.deltaTime;
    }
}
