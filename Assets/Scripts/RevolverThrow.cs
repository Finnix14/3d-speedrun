using UnityEngine;

public class RevolverThrow : MonoBehaviour
{
    public Pistol playerGun;
    public Rigidbody rb;
    public BoxCollider coll;
    public Transform player, gunContainer, fpsCam;

    public float pickUpRange;
    public float dropForwardForce, dropUpwardForce;

    public bool equipped;
    public bool slotFull;
    public Animator anim;

    public GameObject weaponUI;
    void Start()
    {
        anim = GetComponent<Animator>();

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

            if (equipped && Input.GetMouseButtonDown(1))
                Drop();
        }
    }


    public void Drop()
    {

        weaponUI.SetActive(false);
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
        anim.GetComponent<Animator>().enabled = false;


    }
}