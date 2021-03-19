using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    public bool isGrounded = true;  
    private bool jumpKeyWasPressed;
    private float horizontalInput;
    private Rigidbody rigidBodyComponent;

    void Start()
    {
        rigidBodyComponent = GetComponent<Rigidbody>(); 
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))   
            jumpKeyWasPressed = true;

        horizontalInput = Input.GetAxis("Horizontal");    
    }

    private void FixedUpdate(){
        if(!isGrounded)
        {
            return;
        }

        if (jumpKeyWasPressed)
        {
           
            rigidBodyComponent.AddForce(Vector3.up * 5, ForceMode.VelocityChange);
            jumpKeyWasPressed = false;

        }

       rigidBodyComponent.velocity = new Vector3(horizontalInput, rigidBodyComponent.velocity.y, 0);
    }
    private void OnCollisionEnter(Collision collision) {
        isGrounded = true;
    }
    private void OnCollisionExit(Collision collision) {
        isGrounded = false;    
    }
}
