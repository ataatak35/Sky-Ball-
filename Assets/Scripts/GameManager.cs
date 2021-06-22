using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    protected GameManager(){}
    
    private GameObject player;
    private Vector3 startingPos;
    private Vector3 instantPos;
    public ParticleSystem particleSystem;

    public bool gameCanStart;
    private bool isGainSpeed;
    
    int gameOverCount;
    
    void Start()
    {
        gameOverCount = 0;
        
        gameCanStart = false;
        isGainSpeed = false;
        PlayerController.velocity = 0f;
        
        ScoreManager.score = 0;
        player = GameObject.Find("Player");
        startingPos = player.transform.position;
    }

    private IEnumerator WaitForGameOver()
    {
        yield return new WaitForSeconds(1.9f);
        
        particleSystem.Stop();
        Time.timeScale = 0;
        UIManager.Instance.OpenGameOverMenu();

    }
    
    public void GameOver()
    {
        
        Instantiate(particleSystem, player.transform.position, Quaternion.identity);
        player.SetActive(false);

        StartCoroutine(WaitForGameOver());

    }

    
    void Update()
    {
        instantPos = player.transform.position;

        Vector3 distance = instantPos - startingPos;

        ScoreManager.score = (int) distance.x;

        if (gameCanStart)
        {
            PlayerController.velocity = 10f;
            Time.timeScale = 1;
            gameCanStart = false;
        }

        if (ScoreManager.score % 100 == 0 && ScoreManager.score != 0)
        {
            isGainSpeed = true;
        }

        if (PlayerController.rb.velocity.x == 0 && player.transform.position.x - startingPos.x != 0)
        {
            gameOverCount += 1;
        }
        
        if(gameOverCount == 1)
            GameOver();
        
    }

    private void FixedUpdate()
    {
        
        if (isGainSpeed)
        {
            PlayerController.velocity += 0.3f;
            isGainSpeed = false;
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
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    
    
}
