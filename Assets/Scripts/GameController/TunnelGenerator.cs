using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TunnelGenerator : MonoBehaviour {
    public GameObject tunnelCutout;
	private GameObject[] tunnelCutoutArr;
    private GameObject[] preprePhase;
    public int preparePhaseAmount;
	public int numTunnelCutout;
	private Quaternion rotation;
	private float lastPos;
    public int maxObs;
    public float scaleDistance;

    public int generateDistance = 3;
    // Use this for initialization
    void Start () {
        TunnelInitilization();
    }
	
	// Update is called once per frame
	void Update () {
        TunnelUpdate();
	}

    // Initilize tunnels
    private void TunnelInitilization()
    {
        tunnelCutoutArr = new GameObject[numTunnelCutout];
        for (int x = 0; x < numTunnelCutout; x++)
        {
            tunnelCutoutArr[x] = (GameObject)Instantiate(tunnelCutout, new Vector3(0, 0, 0 + x * scaleDistance), Quaternion.identity);

        }
        for (int x = numTunnelCutout / 2; x < numTunnelCutout; x+= 2)
        {
            int n = Random.Range(1, maxObs + 1);
            tunnelCutoutArr[x].GetComponent<ObstacleManager>().GenerateObstacles(n);
        }
    }


    // Update tunnels
    void TunnelUpdate()
    {
        if (generateDistance <= 0)
        {
            generateDistance = 3;
        }

        for (int x = 0; x < numTunnelCutout; x++)
        {
            
            // Get the index of the furtherst tunnel cutout
            int pre = x == 0 ? numTunnelCutout - 1 : x - 1;
            if (tunnelCutoutArr[x].transform.position.z <= -12)
            {
                // Disable all obstacles on this tunnel cutout
                tunnelCutoutArr[x].GetComponent<ObstacleManager>().DestroyObstacles();
                tunnelCutoutArr[x].transform.position = new Vector3(tunnelCutoutArr[x].transform.position.x,
                    tunnelCutoutArr[x].transform.position.y,
                    tunnelCutoutArr[pre].transform.position.z + scaleDistance);

                // Generate obstacles randomly
                if (generateDistance == 3)
                {
                    int n = Random.Range(1, maxObs + 1);
                    tunnelCutoutArr[x].GetComponent<ObstacleManager>().GenerateObstacles(n);
                    
                }
                generateDistance--;
            }
        }
    }

}
