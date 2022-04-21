using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TruckMovement : MonoBehaviour
{
    public float movementSpeed;
    void Start()
    {
        movementSpeed = Random.Range(movementSpeed, movementSpeed + 20);
        this.transform.GetChild(0).gameObject.GetComponent<Rigidbody>().drag = Random.Range(.1f, 1f);
    }

   
    void Update()
    {
        transform.position += this.transform.forward * Time.deltaTime * movementSpeed;
    }
}
