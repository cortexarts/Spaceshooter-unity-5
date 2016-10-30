using UnityEngine;
using System.Collections;

public class EvasiveManouver : MonoBehaviour {

    public Vector2 startWait;
    private float targetManeuver;
    public float dodge;
    public Vector2 maneuverTime;
    public Vector2 maneurerWait;
    private Rigidbody rb;
    public float smoothing;
    private float currentSpeed;
    public Boundary boundary;
    public float tilt;
	void Start ()
    {
        rb = GetComponent<Rigidbody>();
        currentSpeed = rb.velocity.z;
        StartCoroutine(Evade());
	}
    
   IEnumerator Evade()
    {
        yield return new WaitForSeconds( Random.Range (startWait.x, startWait.y));

        while (true)
        {
            targetManeuver = Random.Range(1, dodge) -Mathf.Sign (transform.position.x);
            yield return new WaitForSeconds( Random.Range (maneuverTime.x, maneuverTime.y));
            targetManeuver = 0;
            yield return new WaitForSeconds( Random.Range (maneurerWait.x, maneurerWait.y));
        }
    }
	void FixedUpdate ()
    {
        float newManeuver = Mathf.MoveTowards(rb.velocity.x, targetManeuver, Time.deltaTime * smoothing);
    rb.velocity = new Vector3(newManeuver, 0.0f, currentSpeed);
    rb.position = new Vector3
            (
            Mathf.Clamp(rb.position.x, boundary.xMin, boundary.xMax),
            0.0f,
            Mathf.Clamp(rb.position.z, boundary.zMin, boundary.zMax)
        );
        rb.rotation = Quaternion.Euler(0.0f, 0.0f, rb.velocity.x * -tilt);
        }
}
