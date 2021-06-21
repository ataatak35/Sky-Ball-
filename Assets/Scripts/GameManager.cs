using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Must;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.GameCenter;
using UnityEngine.UIElements;

public class GameManager : Singleton<GameManager>
{
    protected GameManager(){}
    
    private GameObject player;
    private Vector3 startingPos;
    private Vector3 instantPos;

    public bool gameCanStart;
    
    void Start()
    {
        gameCanStart = false;
        PlayerController.velocity = 0f;
        
        ScoreManager.score = 0;
        player = GameObject.Find("Player");
        startingPos = player.transform.position;
    }

    void Update()
    {
        instantPos = player.transform.position;

        Vector3 distance = instantPos - startingPos;

        ScoreManager.score = (int) distance.x;

        if (gameCanStart)
        {
            PlayerController.velocity = 15f;
            gameCanStart = false;
        }
        
    }

    public void Pause()
    {

        Time.timeScale = 0;

    }

    public void Continue()
    {
        Time.timeScale = 1;
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1;
    }
}
