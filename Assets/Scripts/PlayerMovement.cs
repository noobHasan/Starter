using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float speed;
    public Joystick josytick;
    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    public void Movement()
    {
        float horizontalInput = josytick.Horizontal;
        float verticalInput = josytick.Vertical;

        transform.position = new Vector3(transform.position.x + horizontalInput * speed * Time.deltaTime, 
            transform.position.y, transform.position.z + verticalInput * speed * Time.deltaTime);


    }
}
