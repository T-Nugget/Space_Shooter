using UnityEngine;
using System.Collections;

public class Star_Speedup : MonoBehaviour
{


    private ParticleSystem ps;
    public float hSliderValue = 1.0F;

    void Start()
    {
        ps = GetComponent<ParticleSystem>();
    }

    void Update()
    {
        var main = ps.main;
        //main.startSpeed = 0.4;
    }

   
}
