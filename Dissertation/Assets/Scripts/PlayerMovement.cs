using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speedForward = 5f;
    public float speedBackward = 3f;
    public float speedHorizontal = 3.5f;
    public float rotSpeed = 80f;
    public float gravity = 8f;
    public float rot = 0f;
    public float valueX = 0f;
    public float valueY = 0f;
    public float valueZ = 0f;

    Vector3 moveDir = Vector3.zero;

    CharacterController controller;
    Animator anim;
    GameObject character;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
        character = GetComponent<GameObject>();
    }
    void Update()
    {
        if(controller.isGrounded)       //If on the ground
        {
            int newint;
            newint = anim.GetInteger("Attack1");

            if (!anim.GetCurrentAnimatorStateInfo(0).IsName("InwardAttack") && !anim.GetCurrentAnimatorStateInfo(0).IsName("OutwardAttack") && !anim.GetCurrentAnimatorStateInfo(0).IsName("SpinAttack"))
            {
                anim.SetBool("CanMove", true);
            }
                if (anim.GetBool("CanMove") == true)
            {

            
                if (Input.GetKeyDown(KeyCode.W))           //Forwards motion
                {

                    valueZ = 1;
                    anim.SetInteger("Condition Forward", 1);
                    moveDir = new Vector3(valueX, valueY, valueZ);
                    moveDir *= speedForward;
                    moveDir = transform.TransformDirection(moveDir);
                }
                if(Input.GetKeyUp(KeyCode.W))
                {
                    valueZ = 0;
                    anim.SetInteger("Condition Forward", 0);
                    moveDir = new Vector3(valueX, valueY, valueZ);
                }


                if (Input.GetKeyDown(KeyCode.S))                //Backwards motion
                {
                    valueZ = -1;
                    anim.SetInteger("Condition Backward", 1);
                    moveDir = new Vector3(valueX, valueY, valueZ);
                    moveDir *= speedBackward;
                    moveDir = transform.TransformDirection(moveDir);
                }
                if (Input.GetKeyUp(KeyCode.S))
                {
                    valueZ = 0;
                    anim.SetInteger("Condition Backward", 0);
                    moveDir = new Vector3(valueX, valueY, valueZ);
                }


                if (Input.GetKeyDown(KeyCode.A))            //Left motion
                {
                    valueX = -1f;
                    anim.SetInteger("Condition Left", 1);
                    moveDir = new Vector3(valueX, valueY, valueZ);
                    moveDir *= speedHorizontal;
                    moveDir = transform.TransformDirection(moveDir);
                }
                if (Input.GetKeyUp(KeyCode.A))
                {
                    valueX = 0;
                    anim.SetInteger("Condition Left", 0);
                    moveDir = new Vector3(valueX, valueY, valueZ);

                }


                if (Input.GetKeyDown(KeyCode.D))            //Right motion
                {
                    valueX = 1f;
                    anim.SetInteger("Condition Right", 1);
                    moveDir = new Vector3(valueX, valueY, valueZ);
                    moveDir *= speedHorizontal;
                    moveDir = transform.TransformDirection(moveDir);
                }
                if (Input.GetKeyUp(KeyCode.D))
                {
                    valueX = 0;
                    anim.SetInteger("Condition Right", 0);
                    moveDir = new Vector3(valueX, valueY, valueZ);

                }
            }


        }
        //rot += Input.GetAxis("Mouse X") * rotSpeed * Time.deltaTime;
        //transform.eulerAngles = new Vector3(0, rot, 0);

        moveDir.y -= gravity * Time.deltaTime;
        controller.Move(moveDir * Time.deltaTime);
        //character.transform.position = moveDir * Time.deltaTime;
    }
}
