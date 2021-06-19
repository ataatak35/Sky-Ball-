using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.SocialPlatforms;
using Random = UnityEngine.Random;

public class LevelGenerator : MonoBehaviour{
    [SerializeField]private GameObject startingLevel; 
    [SerializeField]private GameObject [] levels;
    [SerializeField]private GameObject [] obstacleLevels;
    [SerializeField]private GameObject firstSkyscrapper;
    [SerializeField]private GameObject [] skyscrappers;
    

    private void Start(){
        GenerateLevel();
        GenerateSkycrapper();
    }

    public void GenerateLevel(){
        int levelAmount = 3;
        bool isCreate = true; 
        int levelIndex;
        List<GameObject> createdLevels = new List<GameObject> ();
        //Starting leveli listeye ekleme
        createdLevels.Add(startingLevel);
        Debug.Log("Starting Level Added");


        for (int i = 0; i < levelAmount; i++){
            levelIndex = Random.Range(0, 10);
            GameObject randomLevel = Instantiate(levels[levelIndex],
                new Vector3(createdLevels[createdLevels.Count - 1].transform.position.x + 175, 0),
                Quaternion.Euler(0, 180, 0));
            createdLevels.Add(randomLevel);
        }

    }

    public void GenerateSkycrapper(){
        bool isCreate = true;
        int amaountOfSkyscrapper = 10;
        int skyscrapperIndex;
        int rangeBetweenSkyscrappers;
        List<GameObject> createdSkyscrappers = new List<GameObject>();
        createdSkyscrappers.Add(firstSkyscrapper);

        while (isCreate){
            for (int i = 0; i < amaountOfSkyscrapper; i++){
                skyscrapperIndex = Random.Range(0,21);
                rangeBetweenSkyscrappers = Random.Range(10, 15);
                GameObject randomSkyscrapperL = Instantiate(skyscrappers[skyscrapperIndex], new Vector3(createdSkyscrappers[createdSkyscrappers.Count - 1].transform.position.x + rangeBetweenSkyscrappers,createdSkyscrappers[createdSkyscrappers.Count - 1].transform.position.y,createdSkyscrappers[createdSkyscrappers.Count - 1].transform.position.z ), Quaternion.identity);
                GameObject randomSkyscrapperR = Instantiate(skyscrappers[skyscrapperIndex], new Vector3(createdSkyscrappers[createdSkyscrappers.Count - 1].transform.position.x + rangeBetweenSkyscrappers,createdSkyscrappers[createdSkyscrappers.Count - 1].transform.position.y,createdSkyscrappers[createdSkyscrappers.Count - 1].transform.position.z - 26), Quaternion.identity);
                createdSkyscrappers.Add(randomSkyscrapperL);
                
            }
            isCreate = false;
        }
    }
}
    

