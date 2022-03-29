using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class Enemy : MonoBehaviour
{
    [SerializeField] float health = 10;
    [SerializeField] Rigidbody enemyrig;
    public float launchForce;

    public Animator enemyAnim;

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
        enemyAnim.SetTrigger("Dying");
        //enemyrig.AddForce(Camera.main.transform.forward * launchForce, ForceMode.VelocityChange);
        yield return new WaitForSeconds(3f);
        Destroy(gameObject);
    }
}