using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zipline : MonoBehaviour
{
    public float Go = 100f;
    public float range = 3f;

    public GameObject zipline;
    public bool isMoving = false;

    public Camera fpsCam;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("e"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);

            Target target = hit.transform.GetComponent<Target>();
            if (target != null)
            {
                StartCoroutine(ZiplineGo());
            }
        }
    }

    IEnumerator ZiplineGo()
    {
        isMoving = true;
        zipline.GetComponent<Animator>().Play("Zipline");
        yield return new WaitForSeconds(0.05f);
        yield return new WaitForSeconds(10f);
        zipline.GetComponent<Animator>().Play("New State");
        isMoving = false;
    }
}