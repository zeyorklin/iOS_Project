using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TunnelGenerator : MonoBehaviour {
    public GameObject tunnelCutout;
	private GameObject[] tunnelCutoutArr;
	public int numTunnelCutout;
	private Quaternion rotation;
	private float lastPos;

    void Start () {
		tunnelCutoutArr = new GameObject[numTunnelCutout];
		for (int x = 0; x < numTunnelCutout; x++) {
			tunnelCutoutArr [x] = (GameObject)Instantiate (tunnelCutout, new Vector3 (0, 0, -12 + x * 3), Quaternion.identity);
		}
    }
	
	void Update () {
        TunnelUpdate();
        /*for (int x = 0; x < numTunnelCutout; x++) {
			if (tunnelCutoutArr [x].transform.position.z < -12) {
                tunnelCutoutArr[x].transform.position = new Vector3(tunnelCutoutArr[x].transform.position.x, tunnelCutoutArr[x].transform.position.y, -12 + (numTunnelCutout - 1) * 3);
			}
		}*/
	}

    void TunnelUpdate()
    {
        for (int x = 0; x < numTunnelCutout; x++)
        {
            int pre = x == 0 ? numTunnelCutout - 1 : x - 1;
            Debug.Log(pre);
            if (tunnelCutoutArr[x].transform.position.z <= -12)
            {
                tunnelCutoutArr[x].transform.position = new Vector3(tunnelCutoutArr[x].transform.position.x,
                    tunnelCutoutArr[x].transform.position.y,
                    tunnelCutoutArr[pre].transform.position.z + 3);
            }
        }
    }
}
