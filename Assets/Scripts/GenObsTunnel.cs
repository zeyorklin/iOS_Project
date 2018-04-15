using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenObsTunnel : MonoBehaviour {

    public GameObject[] tunnels;

	// Use this for initialization
	void Awake () {
        tunnels = new GameObject[16];
        for (int i = 0; i < 16; i++)
        {
            tunnels[i] = transform.GetChild(i).gameObject;
        }
	}
	
	// Update is called once per frame
	void Update () {
	}

    public void GenObsT(int n)
    {
        for (int i = 1; i < n;)
        {
            int rand = Random.Range(0, 16);
            if (!tunnels[rand].GetComponent<GenObs>().hasObs)
            {
                tunnels[rand].GetComponent<GenObs>().ActivateObs();
                i++;
            }
        }
    }

    public void DestroyObsT()
    {
        for (int i = 0; i < 16; i++)
        {
            tunnels[i].GetComponent<GenObs>().DestroyObs();
        }
    }
}
