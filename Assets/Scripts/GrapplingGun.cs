using UnityEngine;

public class GrapplingGun : MonoBehaviour
{

    private LineRenderer lr;
    private Vector3 grapplePoint;
    public LayerMask whatIsGrappleable;
#pragma warning disable CS0108 // Member hides inherited member; missing new keyword
    public Transform gunTip, camera, player;
#pragma warning restore CS0108 // Member hides inherited member; missing new keyword
    private float maxDistance = 20f;
    private SpringJoint joint;
    public AudioSource shoot;

    Animator anim;

    void Awake()
    {
        lr = GetComponent<LineRenderer>();
        anim = GetComponent<Animator>();
        shoot = GetComponent<AudioSource>();
        
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            StartGrapple();
            
        }
        else if (Input.GetMouseButtonUp(0))
        {
            StopGrapple();

        }
    }


    void LateUpdate()
    {
        DrawRope();
    }

  
    void StartGrapple()
    {
        RaycastHit hit;
        shootGrapple();
        if (Physics.Raycast(camera.position, camera.forward, out hit, maxDistance, whatIsGrappleable))
        {
            shoot.Play();
            grapplePoint = hit.point;
            joint = player.gameObject.AddComponent<SpringJoint>();
            joint.autoConfigureConnectedAnchor = false;
            joint.connectedAnchor = grapplePoint;

            float distanceFromPoint = Vector3.Distance(player.position, grapplePoint);

     
            joint.maxDistance = distanceFromPoint * 0.8f;
            joint.minDistance = distanceFromPoint * 0.25f;

           
            joint.spring = 8f;
            joint.damper = 20f;
            joint.massScale = 4.5f;

            lr.positionCount = 2;
            currentGrapplePosition = gunTip.position;
        }
    }
    void KnifeInspect()
    {
        if (Input.GetKey(KeyCode.Y))
        {
            anim.Play("spin");
        }
    }

    void KnifeSpin()
    {
        if (Input.GetKey(KeyCode.F))
        {
            anim.Play("knifespin");
        }
    }

    void shootGrapple()
    {
        //shoot.Play();
    }


    /// <summary>
    /// Call whenever we want to stop a grapple
    /// </summary>
    void StopGrapple()
    {
        lr.positionCount = 0;
        Destroy(joint);
    }

    private Vector3 currentGrapplePosition;

    void DrawRope()
    {
        //If not grappling, don't draw rope
        if (!joint) return;

        currentGrapplePosition = Vector3.Lerp(currentGrapplePosition, grapplePoint, Time.deltaTime * 8f);

        lr.SetPosition(0, gunTip.position);
        lr.SetPosition(1, currentGrapplePosition);
    }

    public bool IsGrappling()
    {
        return joint != null;
    }

    public Vector3 GetGrapplePoint()
    {
        return grapplePoint;
    }
}