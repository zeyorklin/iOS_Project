using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoGen : MonoBehaviour {

	public Transform Tunnel;
	public GameObject tunnelCutout;
	public GameObject[] tunnelCutoutArr;
	public GameObject tunnelCutoutClone;
	// Use this for initialization
	void Start () {
		tunnelCutoutArr = new GameObject[20];
		for (int y = 0; y < 5; y++) {
			for (int x = 0; x < 5; x++) {
				//GameObject cube = GameObject.CreatePrimitive (PrimitiveType.Cube);
				//cube.AddComponent<Rigidbody> ();
				//cube.transform.position = new Vector3 (x, y, 0);
				//Instantiate (Tunnel, new Vector3 (x, y, 0), Quaternion.identity);
			}
		}

		for (int x = 0; x < 20; x++) {
			tunnelCutoutArr[x] = (GameObject) Instantiate (tunnelCutout, new Vector3 (0, 0, -12 + x * 3), Quaternion.identity);
		}

		//tunnelCutoutClone = (GameObject)Instantiate (tunnelCutout, new Vector3 (0, 0, 10), Quaternion.identity);


	}
	
	// Update is called once per frame
	void Update () {
		for (int x = 0; x < 20; x++) {
			if (tunnelCutoutArr[x].transform.position.z < -12) {
				Destroy (tunnelCutoutArr [x]);
				tunnelCutoutArr[x] = (GameObject) Instantiate (tunnelCutout, new Vector3 (0, 0, 48), Quaternion.identity);
			}
		}
		/*if (tunnelCutoutClone.transform.position.z < -3) {
			Destroy (tunnelCutoutClone);
		}*/
		//Instantiate (Tunnel, new Vector3 (0, 0, 0), Quaternion.identity);
	}
}
