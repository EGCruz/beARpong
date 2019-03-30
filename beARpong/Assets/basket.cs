using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class basket : MonoBehaviour
{
	public static int scoreValue=0; //reference to the ScoreText gameobject, set in editor

	public Text scoreText;
	
	//public Text text;
    
    void Awake()
    {
        scoreText.text = "Score: 0";
    }

	void OnCollisionEnter() //if ball hits board
    {
         scoreValue++;
         Debug.Log(scoreValue);
         scoreText.text = "Score: " + scoreValue.ToString();
		 Destroy (transform.parent.gameObject);
         Destroy (gameObject);
        
    }
 

}
