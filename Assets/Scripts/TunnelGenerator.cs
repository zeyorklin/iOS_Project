using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TunnelGenerator : MonoBehaviour {
    public GameObject tunnelCutout;
	private GameObject[] tunnelCutoutArr;
	public int numTunnelCutout;
	private Quaternion rotation;
	private float lastPos;
    public int maxObs;
    // Use this for initialization
    void Start () {
		tunnelCutoutArr = new GameObject[numTunnelCutout];
		for (int x = 0; x < numTunnelCutout; x++) {
			tunnelCutoutArr [x] = (GameObject)Instantiate (tunnelCutout, new Vector3 (0, 0, -12 + x * 3), Quaternion.identity);
            
        }
        for (int x = 0; x < numTunnelCutout; x++)
        {
            int n = Random.Range(1, maxObs + 1);
            tunnelCutoutArr[x].GetComponent<GenObsTunnel>().GenObsT(n);
        }
    }
	
	// Update is called once per frame
	void Update () {
        TunnelUpdate();
		//for (int x = 0; x < numTunnelCutout; x++) {
		//	if (tunnelCutoutArr [x].transform.position.z < -12) {
			//	rotation = tunnelCutoutArr [x].transform.rotation;
				//Destroy (tunnelCutoutArr [x]);
				//if (x == 0) {
				//	lastPos = tunnelCutoutArr [numTunnelCutout - 1].transform.position.z;
				//} else {
				//	lastPos = tunnelCutoutArr [x - 1].transform.position.z;
				//}
				//tunnelCutoutArr [x] = (GameObject)Instantiate (tunnelCutout, new Vector3 (0, 0, lastPos + 2), Quaternion.identity);
			//}
		//}
	}

    void TunnelUpdate()
    {
        for (int x = 0; x < numTunnelCutout; x++)
        {
            int pre = x == 0 ? numTunnelCutout - 1 : x - 1;
            if (tunnelCutoutArr[x].transform.position.z <= -12)
            {
                tunnelCutoutArr[x].GetComponent<GenObsTunnel>().DestroyObsT();
                tunnelCutoutArr[x].transform.position = new Vector3(tunnelCutoutArr[x].transform.position.x,
                    tunnelCutoutArr[x].transform.position.y,
                    tunnelCutoutArr[pre].transform.position.z + 3);
                //-12 + (numTunnelCutout - 1) * 3);
                int n = Random.Range(1, maxObs + 1);
                tunnelCutoutArr[x].GetComponent<GenObsTunnel>().GenObsT(n);
            }
        }
    }

}
