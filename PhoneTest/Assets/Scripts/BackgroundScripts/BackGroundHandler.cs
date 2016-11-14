using UnityEngine;
using System.Collections;



public class BackGroundHandler : MonoBehaviour {


    public GameObject tree;

	void Start () {

	}
	
	// Update is called once per frame
	void Update ()
    {
        int a = Random.Range(0, 120);
        if (a > 115)
        {
            Instantiate(tree, new Vector3(14, -0.65f, 0), Quaternion.identity);
        }
        
    }
}
