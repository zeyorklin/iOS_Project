using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenObs : MonoBehaviour {

    public GameObject cube;
    public bool hasObs;
    private GameObject myObs;

	// Use this for initialization
	void Awake () {
        hasObs = false;
        GenObsCube();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void GenObsCube()
    {

        myObs = Instantiate(cube, transform.position + new Vector3(0, 0, 0),
        transform.rotation) as GameObject;
        myObs.transform.parent = transform;
        myObs.transform.localPosition = new Vector3(0, 5.05f, 0);
        myObs.SetActive(false);
    }

    public void DestroyObs()
    {
        hasObs = false;
        myObs.SetActive(false);
    }

    public void ActivateObs()
    {
        hasObs = true;
        myObs.SetActive(true);
    }
}
