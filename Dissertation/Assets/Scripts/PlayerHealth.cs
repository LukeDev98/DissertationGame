using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    Animator anim;
    public int health = 100;
    Rigidbody rb;
    Rigidbody sword;
    Collider swordCol;
    Camera gamecamera;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        sword = GetComponentInChildren<Rigidbody>();
        swordCol = GetComponentInChildren<Collider>();
        gamecamera = GetComponentInChildren<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            anim.SetBool("Death", true);
            anim.SetBool("CanMove", false);
            sword.Sleep();
            swordCol.enabled = false;
            anim.enabled = false;
            rb.Sleep();

            gamecamera.GetComponent<CameraMovement>().camerarotation = false;
        }
    }

    void OnTriggerEnter(Collider hit)
    {
        if (hit.tag.Equals("HealthItem"))
        {
            //Debug.Log(health.ToString());
            health += 35;
            //Debug.Log(health.ToString());
        }
    }

    
}
