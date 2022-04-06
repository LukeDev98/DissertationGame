using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerAttack : MonoBehaviour
{

    public int RegularAttack = 0;          //There are 3 attacks, so attack can be any number between and including 1 and 3
    public int SpecialAttack;
    CharacterController controller;
    Animator anim;
    GameObject character;
    int rot = 0;
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
        character = GetComponent<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        if ((!anim.GetCurrentAnimatorStateInfo(0).IsName("InwardAttack") && RegularAttack == 0) && (!anim.GetCurrentAnimatorStateInfo(0).IsName("OutwardAttack") && RegularAttack == 0) && (!anim.GetCurrentAnimatorStateInfo(0).IsName("SpinAttack") && RegularAttack == 0))
        {
            anim.SetBool("CanMove", true);
        }
        else
        {
            anim.SetBool("CanMove", false);
        }
        if (Input.GetMouseButtonDown(0))
        {
            
            
            if (anim.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
            {
                RegularAttack = 1;
                anim.SetBool("CanMove", false);
                anim.SetInteger("Attack1", RegularAttack);
                int newint;
                newint = anim.GetInteger("Attack1");
                
            }
            else if (anim.GetCurrentAnimatorStateInfo(0).IsName("InwardAttack"))
            {
                RegularAttack = 2;
                anim.SetInteger("Attack1", RegularAttack);
            }
            else if (anim.GetCurrentAnimatorStateInfo(0).IsName("OutwardAttack"))
            {
                RegularAttack = 3;
                anim.SetInteger("Attack1", RegularAttack);
            }
            if (anim.GetCurrentAnimatorStateInfo(0).IsName("SpinAttack"))
            {
                rot++;
                if (rot == 360)
                {
                    rot = 0;
                }
                character.transform.rotation = Quaternion.Euler(0, rot, 0);
            }

        }

        if (Input.GetMouseButtonDown(1))
        {

        }


    }
    public void EndOfAttack(string message)
    {
        if (message.Equals("EndOfAttack"))
        {
            RegularAttack = 0;
            anim.SetInteger("Attack1", RegularAttack);
        }
    }


    public void AttackMessage(string message)
    {
        if (message.Equals("Damage"))
        {
            AttackMoment();
        }
        
    }

    public void AttackMoment()
    {

    }

}
