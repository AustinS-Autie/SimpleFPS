using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    float moveSpeed;
    [SerializeField]
    float jumpSpeed;
    [SerializeField]
    int jumpTimes = 1;  

    int jump = 0;

    float colDist;

    Vector3 hSpeed;
    Vector3 vSpeed;

    [SerializeField]
    Camera currentCam;

    Transform camRotation;

    Rigidbody rBody;
    // Start is called before the first frame update
    void Start()
    {
        rBody = GetComponent<Rigidbody>();
        camRotation = currentCam.GetComponent<Transform>();
        colDist = transform.localScale.y;
    }

    // Update is called once per frame
    void Update()
    {

        Ray r = new Ray(transform.position, Vector3.down * colDist);

        Debug.DrawLine(r.origin, r.origin + (Vector3.down * colDist) );

        RaycastHit hit;
        
        float hAxis = Input.GetAxis("Horizontal");
        float vAxis = Input.GetAxis("Vertical");

        hSpeed = rBody.transform.right * (float)(hAxis * moveSpeed / 150f);
        vSpeed = rBody.transform.forward * (float)(vAxis * moveSpeed / 150f * -1 );

        transform.rotation = new Quaternion(camRotation.rotation.x, 0, camRotation.rotation.z, 0);

        transform.position = new Vector3(transform.position.x,transform.position.y,transform.position.z)
        + hSpeed + vSpeed;
        
        //rBody.MovePosition(new Vector3(rBody.position.x + hSpeed, rBody.position.y, rBody.position.z + vSpeed));


        if (Input.GetButtonDown("Jump") && jump<jumpTimes)
        {
            jump += 1;
            Jump();
            
        }


        if (Physics.Raycast(r, out hit, colDist))
        {

            if (hit.transform.GetComponent<GroundInfo>() != null && rBody.velocity.y<0)
            {
                jump = 0;

            }
        }
    }
    
    void Jump()
    {
        rBody.velocity = new Vector3(rBody.velocity.x, jumpSpeed, rBody.velocity.z);
    }
}
