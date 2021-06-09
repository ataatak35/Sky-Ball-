using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{

    public GameObject player;
    private Vector3 offset;
    
    
    void Start()
    {
        offset = new Vector3(-8, 3, 0);
    }

    
    void Update()
    {
        
    }

    private void LateUpdate()
    {
        transform.position = player.transform.position + offset;
        
    }
}
