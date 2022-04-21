using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickToTruck : MonoBehaviour
{
    public bool onPlatform;
    GameObject otherGameObject;

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Truck")
        {
            otherGameObject = other.transform.parent.gameObject;
            onPlatform = true;
        }
    }
    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Truck")
        {
            onPlatform = false;
        }
    }
    void Update()
    {
        if (onPlatform)
        {
            transform.position += otherGameObject.transform.forward * Time.deltaTime * otherGameObject.GetComponent<TruckMovement>().movementSpeed;
        }
    }
}
