using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Manage the obstacles on this tunnel cutout
public class ObstacleManager : MonoBehaviour {

    // All child objet(tunnel pieces) of this tunnel cutout
    private GameObject[] tunnelPieces;

	// Use this for initialization
	void Awake () {
        InitializeTunnelPieces();
	}
	
    // Get all the tunnel pieces.
	private void InitializeTunnelPieces()
    {
        tunnelPieces = new GameObject[16];
        for (int i = 0; i < 16; i++)
        {
            tunnelPieces[i] = transform.GetChild(i).gameObject;
        }
    }

    // Generate n obstacles randomly on this tunnel cutout
    public void GenerateObstacles(int n)
    {
        for (int i = 1; i < n;)
        {
            int rand = Random.Range(0, 16);
            if (!tunnelPieces[rand].GetComponent<ObstacleGenerator>().hasObs)
            {
                tunnelPieces[rand].GetComponent<ObstacleGenerator>().ActivateObs();
                i++;
            }
        }
    }

    // Disable all obstacles on this tunnel cutout
    public void DestroyObstacles()
    {
        for (int i = 0; i < 16; i++)
        {
            tunnelPieces[i].GetComponent<ObstacleGenerator>().DestroyObs();
        }
    }
}
