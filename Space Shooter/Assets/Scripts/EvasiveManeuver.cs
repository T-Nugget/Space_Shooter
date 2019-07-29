using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvasiveManeuver : MonoBehaviour
{

    public Vector2 startWait;
    public float dodge;
    public float tilt;
    public Vector2 ManeuverTime;
    public Boundary boundary;
    public Vector2 ManeuverWait;
    private float targetManeuver;
    public float smoothing; 
    private Rigidbody rb;
    private float currentSpeed;


    void Start()
    {
        rb = GetComponent <Rigidbody> ();
        StartCoroutine (Evade ());
        currentSpeed = rb.velocity.z;
    }


    IEnumerator Evade()
    {
        yield return new WaitForSeconds (Random.Range (startWait.x, startWait.y));

        while (true)
        {
            targetManeuver = Random.Range (1, dodge) * -Mathf.Sign (transform.position.x);
            yield return new WaitForSeconds (Random.Range (ManeuverTime.x, ManeuverTime.y));
            targetManeuver = 0;
            yield return new WaitForSeconds (Random.Range (ManeuverWait.x, ManeuverWait.y));
        }
    }


    void FixedUpdate()
    {
        float newManeuver = Mathf.MoveTowards (rb.velocity.x, targetManeuver, Time.deltaTime * smoothing);
        rb.velocity = new Vector3 (newManeuver, 0, currentSpeed);
        rb.position = new Vector3
        (
            Mathf.Clamp (rb.position.x, boundary.xMin, boundary.xMax),
            0.0f,
            Mathf.Clamp (rb.position.z, boundary.zMin, boundary.zMax)
        );

        rb.rotation = Quaternion.Euler (0.0f, 0.0f, rb.velocity.x * -tilt);
    }
}
