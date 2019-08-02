using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pipes_Behavior : MonoBehaviour
{
    public GameObject explosion;
    public GameObject playerExplosion;
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
      
        if(explosion != null)
        {
            Instantiate(explosion, transform.position, transform.rotation);
        }

        if (other.CompareTag ("Player"))
        {
            Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
            gameController.GameOver ();
            Destroy(other.gameObject);
        }

         if (other.CompareTag ("Bolt"))
            {
                Destroy(other.gameObject);
            }
       
        
    }


}
