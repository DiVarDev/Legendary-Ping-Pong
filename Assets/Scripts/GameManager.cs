using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Variables
    [Header("Game Manager Scoring")]
    [SerializeField] private int maxScore = 3;
    [SerializeField] private int playerOneScore;
    [SerializeField] private int playerTwoScore;
    [Header("Game Manager Stage Setting")]
    [SerializeField] private int gameStage;
    [Header("Game Manager Time Things")]
    [SerializeField] private bool hasCountDown;
    [SerializeField] private float maxTime = 15.0f;
    [SerializeField] private float currentTimeLeft;
    [SerializeField] private TMP_Text textTimeLeft;
    [SerializeField] private TimeManager timeManager;
    [Header("Ball")]
    [SerializeField] private GameObject ball;
    [Header("Player")]
    [SerializeField] private GameObject playerOne;
    [SerializeField] private GameObject playerTwo;
    [Header("AI")]
    [SerializeField] private bool aiGame;
    [Header("World")]
    [SerializeField] private GameObject playerOneGoal;
    [SerializeField] private GameObject playerTwoGoal;
    [Header("User Interface")]
    [SerializeField] TMP_Text playerOneText;
    [SerializeField] private TMP_Text playerTwoText;

    // Start is called before the first frame update
    void Start()
    {
        if (hasCountDown)
        {
            currentTimeLeft = maxTime;
            if (textTimeLeft == null)
            {
                textTimeLeft = GameObject.Find("Canvas").transform.Find("Time Value").GetComponent<TMP_Text>();
            }
            StartCoroutine(CountdownTimer());
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void FixedUpdate()
    {
        CheckVictory();
    }

    // Coroutines
    IEnumerator CountdownTimer()
    {
        while (currentTimeLeft >= 0.0f)
        {
            timeManager.CaculateTimer(currentTimeLeft, maxTime);
            UpdateTimer(timeManager.ReturnStringTimeElapsed());
            yield return new WaitForSeconds(1f);
            currentTimeLeft--;
        }
    }

    // Functions
    public void UpdateTimer(string text)
    {
        textTimeLeft.text = text;
    }

    public void CheckVictory()
    {
        switch (gameStage)
        {
            case 1:
                if (playerOneScore == maxScore)
                {
                    Debug.Log("Player One has won!");
                    SceneManager.LoadSceneAsync("VSPlayer Stage 2", LoadSceneMode.Single);
                }
                else if (playerTwoScore == maxScore)
                {
                    Debug.Log("Player Two has won!");
                    SceneManager.LoadSceneAsync("MainMenu", LoadSceneMode.Single);
                }
                break;
            case 2:
                if (playerOneScore > playerTwoScore && currentTimeLeft < 0.0f)
                {
                    Debug.Log("Player One has won!");
                    SceneManager.LoadSceneAsync("VSAI Stage 3", LoadSceneMode.Single);
                }
                else if (playerTwoScore > playerOneScore && currentTimeLeft < 0.0f)
                {
                    Debug.Log("Player Two has won!");
                    SceneManager.LoadSceneAsync("VSPlayer Stage 1", LoadSceneMode.Single);
                }
                else if (currentTimeLeft < 0.0f && playerOneScore == playerTwoScore)
                {
                    Debug.Log("Player Two has won!");
                    SceneManager.LoadSceneAsync("VSPlayer Stage 1", LoadSceneMode.Single);
                }
                break;
            case 3:
                if (playerOneScore > playerTwoScore && currentTimeLeft < 0.0f)
                {
                    Debug.Log("Player One has won!");
                    SceneManager.LoadSceneAsync("Victory Player One", LoadSceneMode.Single);
                }
                else if (playerTwoScore > playerOneScore && currentTimeLeft < 0.0f)
                {
                    Debug.Log("Player Two has won!");
                    SceneManager.LoadSceneAsync("VSPlayer Stage 1", LoadSceneMode.Single);
                }
                else if (currentTimeLeft < 0.0f && playerOneScore == playerTwoScore)
                {
                    Debug.Log("Player Two has won!");
                    SceneManager.LoadSceneAsync("VSPlayer Stage 1", LoadSceneMode.Single);
                }
                break;
            default:
                SceneManager.LoadSceneAsync("MainMenu", LoadSceneMode.Single);
                break;
        }
    }

    public void PlayerOneScore()
    {
        playerOneScore++;
        playerOneText.text = playerOneScore.ToString();
        CheckVictory();
        ResetPosition();
    }

    public void PlayerTwoScore()
    {
        playerTwoScore++;
        playerTwoText.text = playerTwoScore.ToString();
        CheckVictory();
        ResetPosition();
    }

    public void ResetPosition()
    {
        playerOne.GetComponent<PlayerMovement>().Reset();
        if (aiGame)
        {
            ball.GetComponent<Ball>().Reset();
            playerOne.GetComponent<PlayerMovement>().Reset();
        }
        else
        {
            playerOne.GetComponent<PlayerMovement>().Reset();
            playerTwo.GetComponent<PlayerMovement>().Reset();
            ball.GetComponent<Ball>().Reset();
        }
    }
}
