using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private bool isGameActive;
    public TextMeshProUGUI gameOverText;
    public TextMeshProUGUI ResetText;
    public TextMeshProUGUI WONText;


    // Start is called before the first frame update
    void Start()
    {
        isGameActive = true;
    }

    //when you hit your enemy method
    public void GameOver()
    {
        isGameActive = false;
        ResetText.gameObject.SetActive(true);
        gameOverText.gameObject.SetActive(true);


    }
    public void GameWon()
    {
        isGameActive = false;
        WONText.gameObject.SetActive(true);
    }
    // Update is called once per frame
    void Update()
    {
        //restart
        if (Input.GetKeyDown("r"))
        { //If you press R
            SceneManager.LoadScene("SampleScene"); //Load scene called Game
        }
    }
}