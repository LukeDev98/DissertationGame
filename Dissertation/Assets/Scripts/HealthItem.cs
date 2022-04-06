using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthItem : MonoBehaviour
{
    int angle = 0;
    Vector3 target1;
    Vector3 target2;
    public float speed = 0.5f;
    GameObject self;
    string direction = "up";
    // Start is called before the first frame update
    void Start()
    {
        target1 = transform.position;
        target2 = transform.position + new Vector3(0, 0.5f, 0);
    }

    // Update is called once per frame
    void Update()
    {
        angle++;
        transform.rotation = Quaternion.Euler(270, angle, 0);
        float step = speed * Time.deltaTime;
        if (direction.Equals("up"))
        {
            if (transform.position != target2)
            {

                transform.position = Vector3.MoveTowards(transform.position, target2, step);
            }
            else
            {
                direction = "down";
            }
        }
        else if (direction.Equals("down"))
        {
            if (transform.position != target1)
            {
                transform.position = Vector3.MoveTowards(transform.position, target1, step);
            }
            else
            {
                direction = "up";
            }
        }
    }

    void OnTriggerEnter(Collider hit)
    {
        if (hit.tag.Equals("Player"))
        {
            Destroy(gameObject);
        }
    }
    
}
