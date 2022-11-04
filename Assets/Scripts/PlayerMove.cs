using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerMove : MonoBehaviour
{
    public CharacterController charController;

    public float gravity,speed,jumpHeight;
    public Transform groundCheck; 
    public LayerMask groundMask; 
    Vector3 velocity;
    public bool grounded; 

    private void Update()
    {
        grounded = Physics.CheckSphere(groundCheck.position, 0.05f, groundMask);

        Vector3 move = transform.right * Input.GetAxis("Horizontal") + transform.forward * Input.GetAxis("Vertical"); 

        charController.Move(move * speed * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && grounded) 
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity); 
        }

        velocity.y += gravity * Time.deltaTime;

        charController.Move(velocity * Time.deltaTime); 
    }
    
    
}