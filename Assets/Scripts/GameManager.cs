using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Variables
    [Header("Game Information")]
    [SerializeField] private int maxScore = 3;
    [SerializeField] private int playerOneScore;
    [SerializeField] private int playerTwoScore;
    [SerializeField] private int gameStage;
    [SerializeField] private bool hasCountDown;
    [SerializeField] private float timeLeft = 1.0f;
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

    void FixedUpdate()
    {
        if (hasCountDown)
        {
            timeLeft -= Time.deltaTime;
        }
        CheckVictory();
    }

    // Functions
    public void CheckVictory()
    {
        if (timeLeft <= 0.0f)
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
                        SceneManager.LoadSceneAsync("Victory Player Two", LoadSceneMode.Single);
                    }
                    break;
                case 2:
                    if (playerOneScore > playerTwoScore)
                    {
                        Debug.Log("Player One has won!");
                        SceneManager.LoadSceneAsync("VSAI Stage 3", LoadSceneMode.Single);
                    }
                    else if (playerTwoScore > playerOneScore)
                    {
                        Debug.Log("Player Two has won!");
                        SceneManager.LoadSceneAsync("Victory Player Two", LoadSceneMode.Single);
                    }
                    break;
                case 3:
                    if (playerOneScore > playerTwoScore)
                    {
                        Debug.Log("Player One has won!");
                        SceneManager.LoadSceneAsync("Victory Player One", LoadSceneMode.Single);
                    }
                    else if (playerTwoScore > playerOneScore)
                    {
                        Debug.Log("Player Two has won!");
                        SceneManager.LoadSceneAsync("Victory Player Two", LoadSceneMode.Single);
                    }
                    break;
                default:
                    SceneManager.LoadSceneAsync("MainMenu", LoadSceneMode.Single);
                    break;
            }
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
