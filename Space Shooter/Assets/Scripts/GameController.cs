using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject[] hazards;
    public GameObject[] powers;
    public float spawnWall;
    public Vector3 spawnValues;
    public int hazardCount;
    public int powerCount;
    public float startWait;
    public float spawnWait;
    public float waveWait;

    public Text ScoreText;
    public int score;
    private bool gameOver;
    private bool restart;
    public Text restartText;
    public Text gameOverText;
    public Text winText;
    public Text authorText;

   
     public AudioSource musicSource;
     public AudioClip winMusic;     
     public AudioClip lossMusic;
     public AudioClip backMusic;     
     

  


   

    void Start()
    {
        gameOver = false;
        restart = false;
        score = 0;
        restartText.text = "";
        gameOverText.text = "";
        winText.text = "";
        authorText.text = "";
        UpdateScore();
        StartCoroutine (SpawnWaves ());
        musicSource.clip = backMusic;
        musicSource.Play();
    }

    void Update ()
    {

        


        if (restart)
        {
            if (Input.GetKeyDown (KeyCode.Space))
            {
                SceneManager.LoadScene("Main"); 
            }
        }
    }

    void FixedUpdate()
    {
        if (Input.GetKey("escape"))
        {
            Application.Quit();
        } 
    }


    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds (startWait);
        while (true)
        {



            for(int i=0; i<hazardCount; i++)
            {
                GameObject hazard = hazards[Random.Range (0, hazards.Length) ];
                Vector3 spawnPosition = new Vector3(Random.Range (-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate (hazard, spawnPosition, spawnRotation);
                yield return new WaitForSeconds (spawnWait);
            }


/*

            for(int i=0; i<powerCount; i++)
            {
                GameObject power = powers[Random.Range (0, powers.Length) ];
                Vector3 spawnPosition = new Vector3(Random.Range (-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate (power, spawnPosition, spawnRotation);
                yield return new WaitForSeconds (spawnWait);
            }



*/





            yield return new WaitForSeconds(waveWait);

            if (gameOver)
            {
                restartText.text = "Press 'Space' for Restart";
                restart = true;
                break;
            }
        }
    }

    public void AddScore(int newScoreValue)
    {
        score = score + newScoreValue;
        UpdateScore();
    }

    void UpdateScore()
    {
        ScoreText.text = "Points: " + score;
        if (score >= 300)
        {

            musicSource.clip = winMusic;
            musicSource.Play();

            winText.text = "You Win!";
            authorText.text = "Game created by Travis Nugent";
            gameOver = true;
            restart = true;
        }
    }

    public void GameOver ()
    {

        if (score <= 300)
        {

            musicSource.clip = lossMusic;
            musicSource.Play();
        }
        gameOverText.text = "Game Over!";
        gameOver = true;
    }
}
