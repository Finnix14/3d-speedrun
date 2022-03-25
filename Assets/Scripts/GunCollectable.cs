
using UnityEngine;


public class GunCollectable : MonoBehaviour
{
    public Shotgun playerGun;
    public Rigidbody rb;
    public BoxCollider coll;
    public Transform player, gunContainer, fpsCam;

    public float pickUpRange;
    public float dropForwardForce, dropUpwardForce;

    public bool equipped;
    public static bool slotFull;

    void Start()
    {
        //gun setup if player does not start with gun.
        if (!equipped)
        {
            playerGun.enabled = false;
            rb.isKinematic = false;
            coll.isTrigger = false;
        }

        //gun setup if player does start with gun.
        if (equipped)
        {
            playerGun.enabled = true;
            rb.isKinematic = true;
            coll.isTrigger = true;
            slotFull = true;
        }
    }

    void Update()
    {
        //check if player is in range & if 'Q' is pressed.
        Vector3 distanceToPlayer = player.position - transform.position;

        if (Time.timeScale == 1)
        {
            if (!equipped && distanceToPlayer.magnitude <= pickUpRange && Input.GetMouseButtonDown(0))
                PickUp();

            if (equipped && Input.GetMouseButtonDown(1))
                Drop();
        }
    }

    void PickUp()
    {
        //make these true so player cant pick up anything else.
        equipped = true;
        slotFull = true;

        //make weapon a child of the camera and move it to default pos.
        transform.SetParent(gunContainer);
        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.Euler(Vector3.zero);
        transform.localScale = Vector3.one;

        //stop item from moving and set collider trigger to true.
        rb.isKinematic = true;
        coll.isTrigger = true;

        //enable gun script.
        playerGun.enabled = true;
    }

    void Drop()
    {
        if (!playerGun.reload)
        {
            //make these false so player can pick up gun.
            equipped = false;
            slotFull = false;

            //set parent to null.
            transform.SetParent(null);

            //reset rb and collider trigger.
            rb.isKinematic = false;
            coll.isTrigger = false;

            //gun carries force by player.
            rb.velocity = player.GetComponent<Rigidbody>().velocity;

            //apply force.
            rb.AddForce(fpsCam.forward * dropForwardForce, ForceMode.Impulse);
            rb.AddForce(fpsCam.up * dropUpwardForce, ForceMode.Impulse);

            //add random rotation when thrown. (Opt.)
            float r = Random.Range(-1f, 1f);
            rb.AddTorque(new Vector3(r, r, r) * 10);

            //disable script.
            playerGun.enabled = false;
        }
    }
}