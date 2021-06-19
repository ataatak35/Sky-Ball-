using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour{
    public float movementSpeed = 10f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update(){
        float hMovement = Input.GetAxis("Horizontal") * movementSpeed/2;
        float vMovement = Input.GetAxis("Vertical") * movementSpeed;
        transform.Translate(new Vector3(vMovement,0,-hMovement)*Time.deltaTime);
    }
}
