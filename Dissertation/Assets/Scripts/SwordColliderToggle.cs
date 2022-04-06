using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordColliderToggle : MonoBehaviour
{
    Animator PlayerAnim;
    Collider SwordCollider;

    void Start()
    {
        SwordCollider = GetComponent<Collider>();
        PlayerAnim = GetComponentInParent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(SwordCollider.enabled);
        if (PlayerAnim.GetCurrentAnimatorStateInfo(0).IsName("OutwardAttack") || PlayerAnim.GetCurrentAnimatorStateInfo(0).IsName("InwardAttack") || PlayerAnim.GetCurrentAnimatorStateInfo(0).IsName("SpinAttack"))
        {
            SwordCollider.enabled = true;
        }
        else
        {
            SwordCollider.enabled = false;
        }

    }
}
