using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectPlayer : MonoBehaviour
{
    bool detected;
    GameObject target;

    public Transform enemy;
    public Transform shootPoint;
    public GameObject bullet;

    public float shootSpeed = 10f;
    public float timeToShoot = 1.3f;
    float originalTime;
    void Start()
    {
        originalTime = timeToShoot;
    }


    void Update()
    {
        if (detected)
        {
            enemy.LookAt(target.transform);
        }
    }
    private void FixedUpdate()
    {
        if (detected)
        {
            timeToShoot -= Time.deltaTime;
            if (timeToShoot < 0)
            {
                ShootPlayer();
                timeToShoot = originalTime;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            detected = true;
            target = other.gameObject;
      
        }
    }

    private void ShootPlayer()
    {
        GameObject currentBullet = Instantiate(bullet, shootPoint.position, shootPoint.rotation);
        Rigidbody rig = currentBullet.GetComponent<Rigidbody>();

        rig.AddForce(transform.forward * shootSpeed, ForceMode.VelocityChange);
    }
}
