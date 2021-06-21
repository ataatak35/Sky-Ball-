using System;
using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using UnityEngine;

public class PlayerController : MonoBehaviour{
    public static float velocity;
    public static Rigidbody rb;
    private int desiredLane = 1; //0 left, 1 middle, 2 right
    public float laneDistance = 3.5f;
    private float jumpForce;

    [SerializeField]private bool isGrounded;
    private bool isJumping;
    private bool isMovingRight;
    private bool isMovingLeft;

    private Vector3 firstPos;
    
    void Start()
    {

        rb = GetComponent<Rigidbody>();
        jumpForce = 5f;
        isJumping = false;
        isGrounded = true;
        isMovingRight = false;
        isMovingLeft = false;

    }

    
    void Update()
    {
        
        
        if (Physics.Raycast(transform.position - new Vector3(0, transform.localScale.y / 2 + 0.05f, 0), Vector3.down, 0.1f))
        {
            isGrounded = true;
        }
        else
        {
            Debug.Log("sıkıntı");
            isGrounded = false;
        }
        
        
        Debug.DrawRay(transform.position - new Vector3(0, transform.localScale.y / 2, 0),Vector3.down, Color.green,0.1f);
        
        if (Input.GetKeyDown(KeyCode.UpArrow) && isGrounded)
        {
            isJumping = true;
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            firstPos = transform.position;
            
            desiredLane++;
            if (desiredLane > 2)
                desiredLane = 2;
            
            isMovingRight = true;
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            firstPos = transform.position;
            
            desiredLane--;
            if (desiredLane < 0)
                desiredLane = 0;
            
            isMovingLeft = true;
        }

        if (desiredLane == 1)
        {
           //SAĞ YOLDAN ORTA YOLA GİDİYORSA
           if (transform.position.z - firstPos.z > 0)
           {
               if (transform.position.z > 0)
               {
                   
                   transform.position = new Vector3(transform.position.x, transform.position.y, 0);
                   rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, 0);
                   
               }
                   
           }
           //SOL YOLDAN ORTA YOLA GİDİYORSA
           if (transform.position.z - firstPos.z < 0)
           {
               if (transform.position.z < 0)
               {
                   
                   transform.position = new Vector3(transform.position.x, transform.position.y, 0);
                   rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, 0);

               } 
                   
           }
           
        }
       
    }

    private void FixedUpdate()
    {
        //rb.velocity = new Vector3(velocity,rb.velocity.y,rb.velocity.z);

        if (isJumping)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isJumping = false;
        }

        if (isMovingRight)
        {
            
            //sağa ve yukarı kuvvet uygulanacak yani hem zıplayacak hem sağa gidecek ve sağdaki kalasın tam ortasında duracak z pozisyonu
            
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            rb.AddForce(Vector3.back * jumpForce * 1.5f, ForceMode.Impulse);

            isMovingRight = false;
        }

        if (isMovingLeft)
        {

            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            rb.AddForce(Vector3.forward * jumpForce * 1.5f, ForceMode.Impulse);
            
            isMovingLeft = false;
        }
        
    }
}