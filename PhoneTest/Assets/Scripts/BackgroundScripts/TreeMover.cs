using UnityEngine;
using System.Collections;

public class TreeMover : MonoBehaviour {

    // Use this for initialization
    public Vector3 speed;
    Transform player;
    PlayerBehaviour playerBehaviour;
	void Start ()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        playerBehaviour = player.GetComponent<PlayerBehaviour>();


    }

    // Update is called once per frame
    void Update ()
    {
        
        transform.position += speed * Time.deltaTime;
        if (transform.position.x < -15)
        {
            Destroy(gameObject);
        }
	}
}
