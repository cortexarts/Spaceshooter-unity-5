using UnityEngine;
using System.Collections;

public class Done_Mover : MonoBehaviour
{
	public float speed;
	private float startY;

	void Start ()
	{
        startY = GetComponent<Rigidbody>().position.y;
		GetComponent<Rigidbody>().velocity = transform.forward * speed;
	}
	void Update() {
		GetComponent<Rigidbody>().position = new Vector3 (GetComponent<Rigidbody>().position.x,startY, GetComponent<Rigidbody>().position.z);
	}
}
