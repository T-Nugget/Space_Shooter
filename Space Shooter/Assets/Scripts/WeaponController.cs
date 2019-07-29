using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    private AudioSource audioSource;
    public GameObject shot;
    public float fireRate;
    public float delay;
    public Transform shotSpawn;


    void Start()
    {
        audioSource = GetComponent<AudioSource> ();
        InvokeRepeating ("Fire", delay, fireRate);
    }

    void Fire ()
    {
        Instantiate (shot, shotSpawn.position, shotSpawn.rotation);
        audioSource.Play ();
    }
    
    void Update()
    {
        
    }
}
