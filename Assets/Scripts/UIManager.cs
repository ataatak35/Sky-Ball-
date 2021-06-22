using UnityEngine;
using UnityEngine.UI;

public class UIManager : Singleton<UIManager>
{
    protected UIManager(){}
    
    [SerializeField]private GameObject playButton;
    [SerializeField]private GameObject skyBallText;
    [SerializeField]private GameObject pauseMenu;
    [SerializeField]private GameObject pauseButton;
    [SerializeField]private GameObject gameOverMenu;
    [SerializeField]private Text gameOverMenuScoreText;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }

    public void OnPlayButtonClicked()
    {

        GameManager.Instance.gameCanStart = true;
        playButton.SetActive(false);
        skyBallText.SetActive(false);

    }

    public void OnPauseButtonClicked()
    {

        GameManager.Instance.Pause();
        pauseMenu.SetActive(true);
        pauseButton.SetActive(false);

    }

    public void OnContinueButtonClicked()
    {

        GameManager.Instance.Continue();
        pauseMenu.SetActive(false);
        pauseButton.SetActive(true);

    }

    public void OnRestartButtonClicked()
    {

        GameManager.Instance.Restart();

    }

    public void OpenGameOverMenu()
    {

        gameOverMenu.SetActive(true);
        gameOverMenuScoreText.text = ScoreManager.score.ToString();

    }
    
}
