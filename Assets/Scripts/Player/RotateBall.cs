using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateBall : MonoBehaviour {
	public int rotatingSpeed;
	public int rotateBackSpeed; //speed for rotate the back to original rotation
    private Rigidbody ball;
	public Transform target;
    public Material crackedBall;
    private int hitCounter = 0;
    public int hitLimit;
    public GameObject player;
    private int isJump = 0;

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
			transform.Rotate (new Vector3 (-rotatingSpeed/2, 0, rotatingSpeed/2) * Time.deltaTime);
		} else if (Input.GetKey ("right")) {
			transform.Rotate (new Vector3 (rotatingSpeed/2, 0, rotatingSpeed/2) * Time.deltaTime);
		} else {
			if(transform.rotation != target.rotation) //if ball's rotation changed, rotate back
				transform.rotation = Quaternion.RotateTowards (transform.rotation, target.rotation, rotateBackSpeed*Time.deltaTime);
		}
        if(Input.GetKey("space"))
        {
            isJump = 1;
            //jump();
        }
        if (isJump == 1)
        {
            transform.Translate(Vector3.up * Time.deltaTime * 5, Space.World);
        }
        if(transform.position.y >= 1.5)
        {
            isJump = 2;
        }
        if(isJump == 2)
        {
            transform.Translate(Vector3.down * Time.deltaTime * 5, Space.World);
        }
        if(transform.position.y <= 0.4)
        {
            isJump = 0;
        }
    }
    
    void jump()
    {
        ball.AddForce(Vector3.up * 50.0f);
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Obstacle"))
        {
            hitCounter++;
            if(hitCounter == 1)
            {
                player.GetComponent<MeshRenderer>().material = crackedBall;
                //player.GetComponent<MeshRenderer>().material = crackedBall;
            }
            other.gameObject.SetActive(false);
        }
    }
}
