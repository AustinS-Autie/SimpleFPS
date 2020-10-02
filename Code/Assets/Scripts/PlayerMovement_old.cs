using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement_old : MonoBehaviour
{
    [SerializeField]
    float moveSpeed = 5;
    [SerializeField]
    float jumpSpeed = 10;
    [SerializeField]
    int jumpTimes = 1;
    [SerializeField]
    float floatiness = 1f;

    [SerializeField]
    int jump = 1;

    float gravity;

    float colDist = 0.5f;

    int ammo = 50;
    int health = 100;

    float jumpStartY;

    Transform changePos;


    
    // Start is called before the first frame update
    void Start()
    {
        changePos = GetComponent<Transform>();
        gravity = jumpSpeed;
        jumpStartY = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Ray r = new Ray(transform.position, Vector3.down * colDist);

        Debug.DrawLine(r.origin, r.origin + (Vector3.down * colDist) );

        RaycastHit hit;
        
        float hAxis = Input.GetAxis("Horizontal");
        float vAxis = Input.GetAxis("Vertical");

        changePos.position = new Vector3(changePos.position.x+(hAxis*moveSpeed*Time.deltaTime), changePos.position.y, changePos.position.z+(vAxis*moveSpeed*Time.deltaTime) );
        //rBody.velocity = new Vector3(hAx  is * moveSpeed, rBody.velocity.y, vAxis * moveSpeed);

        if(Input.GetButtonDown("Jump") && jump<jumpTimes && gravity==0)
        { 
            jump += 1;
            jumpStartY = transform.position.y;
        }



        if (Physics.Raycast(r, out hit, colDist))
        {

            if (hit.transform.GetComponent<GroundInfo>() != null && gravity>jumpSpeed)
            {
                changePos.position = new Vector3(changePos.position.x, changePos.position.y + 0.05f, changePos.position.z); ;
                jump = 0;
                gravity = 0;
                jumpStartY = 0;
                


            }


        }

        if (jump >= jumpTimes)
        {
            Jump();
        }
    }

void Jump()
    {
        changePos.position = new Vector3(changePos.position.x, changePos.position.y + ((jumpSpeed - gravity) * Time.deltaTime), changePos.position.z);
        gravity += floatiness;
    }

}
