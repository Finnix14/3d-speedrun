using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class Enemy : MonoBehaviour
{
    [SerializeField] float health = 10;
    public GameObject ragdoll;

    public void TakeDamage(float dmgAmount)
    {
        health -= dmgAmount;
        if (health <= 0f)
        {
            Die();
        }
    }

    void Die()
    {

        ragdoll = Instantiate(ragdoll, transform.position, transform.rotation);

        Destroy(gameObject);
    }


}