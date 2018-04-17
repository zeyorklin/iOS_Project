using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateBall : MonoBehaviour {
	public int rotatingSpeed;
	public int rotateBackSpeed; //speed for rotate the back to original rotation
    private Rigidbody ball;
	public Transform target;

    void Start()
    {
        ball = GetComponent<Rigidbody>();
    }

    void Update () {
		//transform.Rotate (new Vector3 (0, 0, rotatingSpeed) * Time.deltaTime);
	}

    void FixedUpdate()
    {
		transform.Rotate (new Vector3 (0, 0, rotatingSpeed) * Time.deltaTime);
		if (Input.GetKey ("left")) {
			transform.Rotate (new Vector3 (-rotatingSpeed, 0, 0) * Time.deltaTime);
		} else if (Input.GetKey ("right")) {
			transform.Rotate (new Vector3 (rotatingSpeed, 0, 0) * Time.deltaTime);
		} else {
			if(transform.rotation != target.rotation) //if ball's rotation changed, rotate back
				transform.rotation = Quaternion.RotateTowards (transform.rotation, target.rotation, rotateBackSpeed*Time.deltaTime);
		}
        if(Input.GetKey("space"))
        {
            jump();
        }
    }
    
    void jump()
    {
        ball.AddForce(Vector3.up * 3 * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Obstacle"))
        {
            other.gameObject.SetActive(false);
        }
    }
}
