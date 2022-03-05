using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spinvertical : MonoBehaviour
{
    void Update()
    {
        transform.Rotate(new Vector3(100f * Time.deltaTime, 0f, 0f));
    }

}
