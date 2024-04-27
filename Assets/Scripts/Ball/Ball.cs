using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    // Variables
    [Range(1f, 100f)]
    public float speed = 7f;
    [Range(1f, 100f)]
    public float multiplier = 10f;
    public Rigidbody2D ballrg;
    public Vector2 startPosition;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip playerPong;
    [SerializeField] private AudioClip barrierPong;
    [SerializeField] private AudioClip goalPong;

    // Start is called before the first frame update
    void Start()
    {
        LaunchBall();
    }

    // Update is called once per frame
    void Update()
    {

    }

    // Functions
    public void LaunchBall()
    {
        float x = Random.Range(0, 2) == 0 ? -1 : 1;
        float y = Random.Range(0, 2) == 0 ? -1 : 1;

        ballrg.velocity = new Vector2(x * (speed * multiplier) * Time.deltaTime, y * (speed * multiplier) * Time.deltaTime);
    }

    public void Reset()
    {
        ballrg.velocity = new Vector2(0.0f, 0.0f);
        transform.position = startPosition;
        LaunchBall();
    }

    // OnCollision
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            audioSource.PlayOneShot(playerPong);
        }

        if (collision.transform.CompareTag("Barrier"))
        {
            audioSource.PlayOneShot(barrierPong);
        }
    }

    // OnTrigger
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Goal"))
        {
            audioSource.PlayOneShot(goalPong);
        }
    }
}
