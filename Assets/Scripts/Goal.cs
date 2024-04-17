using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;

public class Goal : MonoBehaviour
{
    // Variables
    [Header("Players")]
    public bool playerOneGoal;
    [Header("Game Manager")]
    public GameObject gameManager;

    // Functions

    // Triggers
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ball"))
        {
            if (playerOneGoal)
            {
                gameManager.GetComponent<GameManager>().PlayerOneScore();
            }
            else
            {
                gameManager.GetComponent<GameManager>().PlayerTwoScore();
            }
        }
    }
}
