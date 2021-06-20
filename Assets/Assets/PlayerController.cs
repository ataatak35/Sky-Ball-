using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour{
    [SerializeField]public float movementSpeed = 10f;
    private int desiredLane = 1; //0 left, 1 middle, 2 right
    public float laneDistance = 3.5f;
    void Start(){
        
    }

    
    void Update(){
        transform.Translate(new Vector3(0.1f,0,0));

        if (Input.GetKeyDown(KeyCode.RightArrow)){
            desiredLane++;
            if (desiredLane > 2)
                desiredLane = 2;
        }
        
        if (Input.GetKeyDown(KeyCode.LeftArrow)){
            desiredLane--;
            if (desiredLane < 0)
                desiredLane = 0;
        }

        Vector3 targetPosition = transform.position.x * transform.right + transform.position.y * transform.up;

        if (desiredLane == 0){
            targetPosition += Vector3.forward * laneDistance;
        }
        
        else if (desiredLane == 2){
            targetPosition += Vector3.back * laneDistance;
        }

        transform.position = Vector3.Lerp(transform.position,targetPosition,80*Time.deltaTime);
    }

    
}
