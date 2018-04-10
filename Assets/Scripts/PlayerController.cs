using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

	public float speed;
	public Text gameScore;
	public Text winText;
	private int count;
	private Rigidbody rb;

	void Start()
	{
		rb = GetComponent<Rigidbody> ();
		count = 0;
		setGameScore ();
		winText.text = "";
	}
	void FixedUpdate()
	{
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

		rb.AddForce (movement * speed);
	}

	void OnTriggerEnter (Collider other)
	{
		if(other.gameObject.CompareTag("Pickup"))
		{
			other.gameObject.SetActive(false);
			count++;
			setGameScore ();
		}
	}

	void setGameScore()
	{
		gameScore.text = "Count: " + count.ToString();
		if (count == 9) 
		{
			winText.text = "You Win!";
		}
	}
}
