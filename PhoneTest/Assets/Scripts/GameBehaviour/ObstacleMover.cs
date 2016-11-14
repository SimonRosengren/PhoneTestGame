using UnityEngine;
using System.Collections;

public class ObstacleMover : MonoBehaviour {

    public  Vector3 speed; //Sätt till rävens speed
    PlayerBehaviour playerBehaviour;

    Transform player;
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
