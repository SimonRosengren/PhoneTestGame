using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

    Transform player;
    public int distance;
	void Start ()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

    }
	
	// Update is called once per frame
	void Update ()
    {
        gameObject.transform.position = new Vector3(player.position.x + 7, player.position.y + 2, player.position.z - distance);
	}
}
