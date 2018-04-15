using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Initialize/generate/disble obstacle on the
// current tunnel piece.
public class ObstacleGenerator : MonoBehaviour {

    // Obstacle prefab
    public GameObject obs;

    // Does this tunnel piece have obstacle
    public bool hasObs;

    // The current obstacle on this tunnel piece
    private GameObject myObs;

	// Use this for initialization
	void Awake () {
        hasObs = false;
        InitializeObstacle();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    // Initialize obstacle for later use
    public void InitializeObstacle()
    {       
        myObs = Instantiate(obs, transform.position, transform.rotation) as GameObject;
        // Make the tunnel piece the parent of the obstacle
        myObs.transform.parent = transform;
        // Raise the obstacle locally.
        myObs.transform.localPosition = new Vector3(0, 5.5f, 0);
        // Disable the obstacle
        myObs.SetActive(false);
    }

    // Disable the obstacle
    public void DestroyObs()
    {
        hasObs = false;
        myObs.SetActive(false);
    }

    // Enable the obstacle
    public void ActivateObs()
    {
        hasObs = true;
        myObs.transform.position = transform.position;
        myObs.transform.localPosition = new Vector3(0, 5.5f, 0);
        myObs.SetActive(true);
    }
}
