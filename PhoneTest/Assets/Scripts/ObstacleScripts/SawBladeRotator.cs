using UnityEngine;
using System.Collections;

public class SawBladeRotator : MonoBehaviour {

    public int speed;
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        transform.Rotate(Vector3.forward * speed * Time.deltaTime);
	}
}
