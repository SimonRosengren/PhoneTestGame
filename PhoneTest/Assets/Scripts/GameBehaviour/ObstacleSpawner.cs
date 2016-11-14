using UnityEngine;
using System.Collections;

public class ObstacleSpawner : MonoBehaviour {

    public GameObject obstacle1;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        int a = Random.Range(0, 120);
        if (a == 100)
        {
            Instantiate(obstacle1, new Vector3(10, -3, 0), Quaternion.identity);
        }
	}
}
