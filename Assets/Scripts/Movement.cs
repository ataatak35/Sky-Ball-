using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    
    
    void Start()
    {
       
    }

    
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            transform.Translate(new Vector3(5,0,0));
        }
        
    }
}
