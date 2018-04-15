using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TunnelGenerator : MonoBehaviour {
    public GameObject tunnelCutout;
	private GameObject[] tunnelCutoutArr;
	public int numTunnelCutout;
	private Quaternion rotation;
	private float lastPos;
    // Use this for initialization
    void Start () {
		tunnelCutoutArr = new GameObject[numTunnelCutout];
		for (int x = 0; x < numTunnelCutout; x++) {
			tunnelCutoutArr [x] = (GameObject)Instantiate (tunnelCutout, new Vector3 (0, 0, -12 + x * 3), Quaternion.identity);
		}
    }
	
	// Update is called once per frame
	void Update () {
		for (int x = 0; x < numTunnelCutout; x++) {
			if (tunnelCutoutArr [x].transform.position.z < -12) {
				rotation = tunnelCutoutArr [x].transform.rotation;
				Destroy (tunnelCutoutArr [x]);
				if (x == 0) {
					lastPos = tunnelCutoutArr [numTunnelCutout - 1].transform.position.z;
				} else {
					lastPos = tunnelCutoutArr [x - 1].transform.position.z;
				}
				tunnelCutoutArr [x] = (GameObject)Instantiate (tunnelCutout, new Vector3 (0, 0, lastPos + 2), Quaternion.identity);
			}
		}
	}
}
