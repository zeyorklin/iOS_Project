using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleRotator : MonoBehaviour {
	public float rotSpeed;
	public float forwardSpeed;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(0, 0, -1 * Time.deltaTime * forwardSpeed);
		if (Input.GetKey("left"))
		{
			transform.RotateAround(new Vector3(0, 3, 0), Vector3.forward, rotSpeed * Time.deltaTime);
		}
		else if (Input.GetKey("right"))
		{
			transform.RotateAround(new Vector3(0, 3, 0), Vector3.back, rotSpeed * Time.deltaTime);
		}
	}
}
