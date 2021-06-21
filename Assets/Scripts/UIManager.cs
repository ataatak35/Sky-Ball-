using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]private GameObject playButton;
    [SerializeField]private GameObject skyBallText;
    [SerializeField]private GameObject pauseMenu;
    [SerializeField]private GameObject pauseButton;
    
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
    
}
