using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Destroy_By_Contact : MonoBehaviour
{
    public GameObject explosion;
    public GameObject playerExplosion;
    public int scoreValue;
    public GameController gameController;

    void Start ()
    {
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        if (gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent <GameController>();
        }
        if (gameController == null)
        {
            Debug.Log ("Cannot find 'GameController' script");
        }
    }


    void OnTriggerEnter(Collider other)
    {
       

        if (other.CompareTag ("Pipes"))
        {
            Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
            Destroy(other.gameObject);                      
        }

        else
        {
            if (other.CompareTag ("Boundry") || other.CompareTag ("Enemy"))
            {
                return;
            }

            if(explosion != null)
            {
                Instantiate(explosion, transform.position, transform.rotation);               
                Destroy(gameObject);
            }

            if (other.CompareTag ("Bolt"))
            {                
                Destroy(gameObject);
                Instantiate(explosion, transform.position, transform.rotation);   
                Destroy(other.gameObject);
                gameController.AddScore (scoreValue);
            }


            if (other.CompareTag ("Player"))
            {
                Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
                gameController.GameOver ();
                Destroy(other.gameObject);
                Destroy(gameObject);
            }
        }

        
    }


}
