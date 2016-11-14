using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreText : MonoBehaviour {

    Text score;
    int scoreInt;
	void Start () {
        score = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        scoreInt++;
        score.text = "Distance: " + scoreInt + " meters";
	}
}
