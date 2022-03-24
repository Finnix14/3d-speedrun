using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class Enemy : MonoBehaviour
{
    [SerializeField] float health = 10;
    [SerializeField] Rigidbody enemyrig;
    public float launchForce;

    public AudioSource hitnoise;
    public void TakeDamage(float dmgAmount)
    {
        health -= dmgAmount;
        if (health <= 0f)
        {
            StartCoroutine("EnemyDie");
                return;
        }
    }



    public IEnumerator EnemyDie()
    {
        hitnoise.Play();
        enemyrig.AddForce(Camera.main.transform.forward * launchForce, ForceMode.VelocityChange);
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }
}