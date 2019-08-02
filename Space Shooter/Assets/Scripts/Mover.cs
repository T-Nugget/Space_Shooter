using UnityEngine;
using System.Collections;

public class Mover : MonoBehaviour
{
     public float speed;

     private Rigidbody rb;

     public GameController myGameController;

     void Start()
     {
          rb = GetComponent<Rigidbody>();
          rb.velocity = transform.forward * speed;
     }

     void Update()
    {
          if (myGameController.score >= 300)
          {         
               speed = -30;                     
          }
          
     rb.velocity = transform.forward * speed;
    }



}