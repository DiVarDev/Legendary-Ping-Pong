using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIBehavior : MonoBehaviour
{
    // Variables
    [SerializeField] private float speed = 3.0f;
    [Range(1f, 25f)]
    [SerializeField] private float multiplayer = 1.0f;
    [SerializeField] private float minimumY = -3.639f;
    [SerializeField] private float maximumY = 3.639f;
    [SerializeField] private GameObject ball;
    [SerializeField] private Vector2 ballPosition;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    // Functions
    public void Movement()
    {
        ballPosition = ball.transform.position;
        if (transform.position.y > ballPosition.y && transform.position.y > minimumY)
        {
            transform.position += new Vector3(0, -speed * Time.deltaTime * multiplayer, 0);
        }

        if (transform.position.y < ballPosition.y && transform.position.y < maximumY)
        {
            transform.position += new Vector3(0, (speed * multiplayer) * Time.deltaTime, 0);
        }
    }
}
