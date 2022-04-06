using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieMove : MonoBehaviour
{
    public Transform player;
    public int speed = 10;
    public int MaxDis = 5;
    public int MinDis = 1;
    public GameObject PlayerObject;
    Rigidbody rb;
    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
        //Debug.Log(Vector3.Distance(transform.position, player.position));
        if (PlayerObject.GetComponent<PlayerHealth>().health <= 0)
        {
            anim.SetBool("Walking", false);
            anim.SetBool("Attack", false);
            anim.SetBool("Idle", true);
        }
        else
        {
            if (Vector3.Distance(transform.position, player.position) > MinDis && Vector3.Distance(transform.position, player.position) <= MaxDis)
            {
                anim.SetBool("Walking", true);
                anim.SetBool("Attack", false);
                if (anim.GetCurrentAnimatorStateInfo(0).IsName("ZombieDeath") == false)
                {
                    transform.LookAt(player);
                    transform.position += transform.forward * speed * Time.deltaTime;
                }
                
                

                //rb.MovePosition(transform.position + player.position * Time.deltaTime);
                //rb.AddRelativeForce(Vector3.forward * speed, ForceMode.Force);
            }
            else
            {
                anim.SetBool("Walking", false);
            }
            //else if (Vector3.Distance(transform.position, player.position) <= MaxDis)
            //{
            //    anim.SetBool("Walking", true);
            //    anim.SetBool("Attack", false);
            //}
            if (Vector3.Distance(transform.position, player.position) <= MinDis)
            {

                transform.LookAt(player);
                anim.SetBool("Walking", false);
                anim.SetBool("Attack", true);
                Attack();
            }
        }


        
    }

    void Attack()
    {

    }
}
