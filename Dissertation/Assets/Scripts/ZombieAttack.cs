using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieAttack : MonoBehaviour
{
    GameObject player;
    PlayerHealth HealthScript;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void DamagePlayer(string message)
    {
        Debug.Log("Damage");
        if (message.Equals("DamagePlayer"))
        {
            bool check = false;

            Collider[] hitColliders = Physics.OverlapSphere(transform.position, 2f);
            foreach (Collider c in hitColliders)
            {
                if (c.CompareTag("Player"))
                {
                    player = c.gameObject;
                    check = true;
                    break;
                }
            }
            if (check == true)
            {
                HealthScript = player.GetComponent<PlayerHealth>();
                HealthScript.health -= 15;
                Debug.Log(HealthScript.health);

            }
        }
    }
}
