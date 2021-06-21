using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    private float maxZ = 3.5f;
    private float maxY = 1.6f;
    
    void Start()
    {
        
    }

    
    void Update()
    {

        if (transform.position.z >= maxZ)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, maxZ);
            PlayerController.rb.velocity =
                new Vector3(PlayerController.rb.velocity.x, PlayerController.rb.velocity.y, 0);
        }

        if (transform.position.z <= -maxZ)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -maxZ);
            PlayerController.rb.velocity =
                new Vector3(PlayerController.rb.velocity.x, PlayerController.rb.velocity.y, 0);
        }

        if (transform.position.y >= maxY)
        {
            transform.position = new Vector3(transform.position.x, maxY, transform.position.z);
            PlayerController.rb.velocity =
                new Vector3(PlayerController.rb.velocity.x, 0, PlayerController.rb.velocity.z);
        }
        
    }

    private void OnTriggerEnter(Collider other){
        if (other.name == "FallTrigger"){
            Debug.Log("Tetiklendi");
        }
    }
    
}
