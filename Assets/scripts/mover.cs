using UnityEngine;
using System.Collections;

public class mover : MonoBehaviour 
{
	public float speed; 
	void FixedUpdate  () {
				//rigidbody.velocity = transform.forward * speed;
		GetComponent<Rigidbody>().position = new Vector3 
			(
				GetComponent<Rigidbody>().position.x, 
				0.0f, 
				GetComponent<Rigidbody>().position.z - (speed / 100.0f)
			);

	}
}
