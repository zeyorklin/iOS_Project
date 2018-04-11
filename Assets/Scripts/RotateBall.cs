using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateBall : MonoBehaviour {
	public int rotatingSpeed = 0;
	// Update is called once per frame
	void Update () {
		transform.Rotate (new Vector3 (0, 0, rotatingSpeed) * Time.deltaTime);
	}
}
