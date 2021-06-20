using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other){
        if (other.name == "FallTrigger"){
            Debug.Log("Tetiklendi");
        }
    }
}
