using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private float speed = 5.0f;
    private float turnSpeed = 10.0f;
    private float horizontalinput;
    private float forwardInput;
    public AudioClip Crash;
    public AudioClip lose;
    private AudioSource playerAudio;
    private GameManager gameManager;


    // Start is called before the first frame update
    void Start()
    {

        playerAudio = GetComponent<AudioSource>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {

        // dont go off screen
        if (transform.position.x < -10)
        {
            transform.position = new Vector3(-10, transform.position.y, transform.position.z);
        }
        if (transform.position.x > 10)
        {
            transform.position = new Vector3(10, transform.position.y, transform.position.z);
        }
        //turn on input
        horizontalinput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");
        //move forward
        transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);
        transform.Translate(Vector3.right * Time.deltaTime * turnSpeed * horizontalinput);

    }
    private void OnCollisionEnter(Collision collision)
    {
        //if you hit the farmer
        if (collision.gameObject.CompareTag("Finish"))
        {

            SceneManager.LoadScene("Level2");
            playerAudio.PlayOneShot(Crash, 1.0f);
        }
        //if you hit an enemy
        if (collision.gameObject.CompareTag("enemy"))
        {
            gameManager.GameOver();
            Debug.Log("You lost :(");
            playerAudio.PlayOneShot(lose, 1.0f);
        }
        //level 3 load
        if (collision.gameObject.CompareTag("L3")) {
            SceneManager.LoadScene("Level3");
                }
        if (collision.gameObject.CompareTag("L4"))
        {
            gameManager.GameWon();
        }

    }
}

//sounds asset

/* https://assetstore.unity.com/packages/audio/sound-fx/free-casual-game-sfx-pack-54116 */


