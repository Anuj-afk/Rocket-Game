using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    [SerializeField] float Thrust;
    [SerializeField] float Rotation; 
    Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        processInput();
    }

    void processInput()
    {
        float Rotationspeed = Rotation * Time.deltaTime;
        if (Input.GetKey(KeyCode.Space))
        {
            Vector3 Force = Vector3.up + new Vector3(0, Thrust, 0) * Time.deltaTime;
            rb.AddRelativeForce(Force);
        }
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            rb.freezeRotation = true;
            transform.Rotate(0, 0, Rotationspeed);
        }
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            rb.freezeRotation = true;   
            transform.Rotate(0, 0, -Rotationspeed);
        }
        else
        {
            rb.freezeRotation = false;
        }
    }
}