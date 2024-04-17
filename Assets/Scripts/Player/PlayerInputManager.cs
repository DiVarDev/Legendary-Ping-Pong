using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class PlayerInputManager : MonoBehaviour
{
    // Variables
    [SerializeField] private InputsActions inputActions;
    [SerializeField] private bool playerOneCheck;
    [SerializeField] private InputsActions.Player1Actions playerOne;
    [SerializeField] private InputsActions.Player2Actions playerTwo;

    [SerializeField] private PlayerMovement movement;

    [SerializeField] GameManager gameManager;

    void Awake()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();

        inputActions = new InputsActions();
        playerOne = inputActions.Player1;
        playerTwo = inputActions.Player2;

        movement = GetComponent<PlayerMovement>();

        playerOne.Reset.performed += ctx => gameManager.ResetPosition();
        playerTwo.Reset.performed += ctx => gameManager.ResetPosition();

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Fixed Update
    void FixedUpdate()
    {
        // When the player moves
        if (playerOneCheck)
        {
            movement.ProcessMove(playerOne.Move.ReadValue<Vector2>());
        }
        else
        {
            movement.ProcessMove(playerTwo.Move.ReadValue<Vector2>());
        }
    }

    void LateUpdate()
    {

    }

    void OnEnable()
    {
        playerOne.Enable();
        playerTwo.Enable();
    }

    void OnDisable()
    {
        playerOne.Disable();
        playerTwo.Disable();
    }
}
