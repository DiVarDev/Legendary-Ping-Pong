using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Variables
    [SerializeField] private bool player;
    [SerializeField] private Rigidbody2D playerRigidBody;
    [Range(1f, 10f)]
    [SerializeField] private float speed = 5.0f;
    [Range(1f, 10f)]
    [SerializeField] private float multiplayer = 1.0f;
    [SerializeField] private Vector2 startPosition;

    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {

    }

    // Functions
    public void ProcessMove(Vector2 input)  // Will receive the input from the InputManager.cs and apply them to the character controler
    {
        if (player)
        {
            Vector3 moveDirection = Vector3.zero;
            moveDirection.y = input.y;
            //moveDirection.z = input.y;
            //controller.Move(transform.TransformDirection(moveDirection) * speed * Time.deltaTime);

            //controller.Move(playervelocity * Time.deltaTime);
            transform.Translate(moveDirection * (speed * multiplayer) * Time.deltaTime);
            //Debug.Log(playervelocity.y);
        }
    }

    public void Reset()
    {
        playerRigidBody.velocity = new Vector2(0, 0);
        transform.position = startPosition;
    }
}
