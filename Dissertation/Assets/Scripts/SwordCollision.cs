using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordCollision : MonoBehaviour
{
    int CollisionCounter = 0;
    //GameObject zombie;
    Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (CollisionCounter >= 7 && anim.GetCurrentAnimatorStateInfo(0).IsName("Death") == false)
        {
            anim.SetBool("Hit", false);
            anim.SetBool("Death", true);

        }




    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Sword"))
        {
            CollisionCounter++;
            Debug.Log("Hit - " + CollisionCounter);

            if (anim.GetCurrentAnimatorStateInfo(0).IsName("Hit") == false && anim.GetCurrentAnimatorStateInfo(0).IsName("Death") == false)
            {
                anim.SetBool("Hit", true);
            }
            
        }

    }

    private void OnTriggerExit(Collider other)
    {
        anim.SetBool("Hit", false);
    }

    void Die(string message)
    {
        if (message.Equals("Die"))
        {
            Destroy(gameObject, 5f);
        }
    }
}
