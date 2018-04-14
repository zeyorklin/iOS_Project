using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TunnelGenerator : MonoBehaviour {
    public GameObject cube;
    // Use this for initialization
    void Start () {
        float deg = 11.25f;
        float rad = deg * Mathf.Deg2Rad;
        float dis = 0.5f / Mathf.Tan(rad) + 0.5f;
        for (int i = 0; i < 16; i++)
        {
            GameObject cb = Instantiate(cube, new Vector3(0, dis, 0), Quaternion.identity) as GameObject;
            cb.transform.RotateAround(Vector3.zero, Vector3.forward, 22.5f * i);
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
