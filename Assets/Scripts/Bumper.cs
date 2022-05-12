using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bumper : MonoBehaviour
{
    [SerializeField] string playerTag;
    [SerializeField] string truck;
    [SerializeField] float bounceForce;

    public Animator anim;
    public ParticleSystem bounceclouds;

    void Start()
    {
        anim = GetComponent<Animator>();  
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.tag == playerTag || collision.transform.tag == truck)
        {
            anim.SetTrigger("doesCollide");
            bounceclouds.Play();
            Rigidbody otherRB = collision.rigidbody;

            otherRB.AddExplosionForce(bounceForce, collision.contacts[0].point, 5);
        }
    }
}
