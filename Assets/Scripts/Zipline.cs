using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zipline : MonoBehaviour
{
    [SerializeField] private Zipline targetZip;
    [SerializeField] private float ZipSpeed = 5f;
    [SerializeField] private float ZipScale = 0.2f;
    
    [SerializeField] private float arrivalThreshold = 0.4f;
    [SerializeField] private LineRenderer cable;
    
    public Transform ZipTransform;

    private bool zipping = false;
    private GameObject localzip;

    private void Awake()
    {
        cable.SetPosition(0, ZipTransform.position);
        cable.SetPosition(1, ZipTransform.position);
    }

   
   
    private void Update()
    {
        if ((!zipping || localzip == null)) return;

        localzip.GetComponent<Rigidbody>().AddForce((targetZip.ZipTransform.position - ZipTransform.position).normalized * ZipSpeed * Time.deltaTime, ForceMode.Acceleration);

        if (Vector3.Distance(localzip.transform.position, targetZip.transform.position) <= arrivalThreshold)
        {
            ResetZipline();
        }
    }
    
    public void StartZipline(GameObject player)
    {
        if (zipping) return;

        localzip = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        localzip.transform.position = ZipTransform.position;
        localzip.transform.localScale = new Vector3(ZipScale, ZipScale, ZipScale);
        localzip.AddComponent<Rigidbody>().useGravity = false ;
        localzip.AddComponent<SphereCollider>().isTrigger = true ;

        player.GetComponent<Rigidbody>().useGravity = false;
        player.GetComponent<Rigidbody>().isKinematic = true;
        player.GetComponent<Rigidbody>().velocity = Vector3.zero;
        player.GetComponent<PlayerMovement>().enabled = false;
        player.GetComponent<PlayerMovement>().enabled = false;
        player.transform.parent = localzip.transform;
        zipping = true;
    }

    private void ResetZipline()
    {
        if (!zipping) return;
        
        GameObject player = localzip.transform.GetChild(0).gameObject;

        player.GetComponent<Rigidbody>().useGravity = false;
        player.GetComponent<Rigidbody>().isKinematic = true;
        player.GetComponent<Rigidbody>().velocity = Vector3.zero;
        player.GetComponent<PlayerMovement>().enabled = true;
        player.GetComponent<PlayerMovement>().enabled = true;
        player.transform.parent = null;
        Destroy(localzip);
        zipping = false;
        localzip = null;
        Debug.Log("Zipline Reset");

       
    }
}
