using UnityEngine;
using System.Collections;

[System.Serializable]
public class Boundary
{
     public float xMin, xMax, zMin, zMax;
}

public class PlayerController : MonoBehaviour
{
     public float speed;
     public float tilt;
     public float fireRate;
     private float nextFire;
     public Boundary boundary;
     public GameObject shot;
     public Transform[] shotSpawns;
     public Transform singleShot;
     public bool Pow;
     private Rigidbody rb;
     Collider m_Collider;
     

     public AudioClip weapon_player;
     public AudioSource musicSource;
 
     
     public GameController myGameController;

     private void Start()
     {
          rb = GetComponent<Rigidbody>();
          m_Collider = GetComponent<Collider>();
          Pow=false;

     }

     void FixedUpdate()
     {
          float moveHorizontal = Input.GetAxis("Horizontal");
          float moveVertical = Input.GetAxis("Vertical");

          Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
          rb.velocity = movement * speed;

          rb.position = new Vector3
          (
               Mathf.Clamp(rb.position.x, boundary.xMin, boundary.xMax),
               0.0f,
               Mathf.Clamp(rb.position.z, boundary.zMin, boundary.zMax)
          );

          rb.rotation = Quaternion.Euler(0.0f, 0.0f, rb.velocity.x * -tilt);
     }

     void OnTriggerEnter(Collider other)
    {
          if (other.CompareTag ("PowerUp"))
          {
               Pow = true;
               Destroy(other.gameObject);               
          }
    }








    void Update()
    {
          musicSource.clip = weapon_player; 
          
          if (Input.GetButton("Fire1") && Time.time > nextFire)
          {
               nextFire = Time.time + fireRate;

                    if (Pow == true)
                    {                                       
                         foreach (var shotSpawn in shotSpawns)
                         {
                              nextFire = Time.time + (fireRate/2);
                              Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
                         }               

                    }                     
 
              
               Instantiate(shot, singleShot.position, singleShot.rotation);

               musicSource.Play();
          }

          if (Input.GetKey("escape"))
          Application.Quit();

          if (myGameController.score >= 300)
          {    
               m_Collider.enabled = false;
               transform.position = new Vector3(rb.position.x,9,rb.position.z);
               //gameObject.transform.Rotate(new Vector3(-45, 0, 0));
               transform.localScale = new Vector3(2,2,2);

          }
     }

}