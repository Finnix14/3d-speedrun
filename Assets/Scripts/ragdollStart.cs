using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ragdollStart : MonoBehaviour
{
    public AudioSource dieNoise;
    public float launchForce = 10f;

    public Rigidbody rb;
    void Start()
    {
        dieNoise = GetComponent<AudioSource>();
        die();
        rb = GetComponentInChildren<Rigidbody>();
        launched();

    }
        
    void die()
    {
        dieNoise.Play();
    }

    void launched()
    {
        rb.AddForce(Camera.main.transform.forward * launchForce);
    }
}
