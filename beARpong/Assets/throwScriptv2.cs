using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class throwScriptv2 : MonoBehaviour {
	Vector2 startPos, endPos, direction; // touch start position, touch end position, swipe direction
	float touchTimeStart, touchTimeFinish, timeInterval; // to calculate swipe time to sontrol throw force in Z direction

	public static int scoreValue=0; //reference to the ScoreText gameobject, set in editor
	public Text scoreText;

	[SerializeField]
	float throwForceInZ = 35f; // to control throw force in Z direction

    Transform camTransform;
	Rigidbody rb;
    // [SerializeField]
    // Transform farCup;

	public GameObject ball;
	public Button throwButton;

	void Start()
	{
		scoreText.text = "Attempts: 0";
		rb = GetComponent<Rigidbody> ();
	}

	public void Hold()
	{
		Debug.Log("Began");
		touchTimeStart = Time.time;
	}

	public void Release()
	{
		// marking time when you release it
		touchTimeFinish = Time.time;

		// calculate swipe time interval 
		timeInterval = touchTimeFinish - touchTimeStart;

		// add force to balls rigidbody in 3D space depending on swipe time, direction and throw forces
		rb.isKinematic = false;
		rb.AddForce(0,100f,throwForceInZ / timeInterval);
		StartCoroutine(ResetAfterTime(2f));
			
        // if(Input.GetMouseButtonDown (0)){
        //     Debug.Log("Mouse Down");
        //     touchTimeStart = Time.time;
        // }
        // if(Input.GetMouseButtonUp(0)){
        //     Debug.Log("Mouse Up");
        //     touchTimeFinish = Time.time;
        //     timeInterval = touchTimeFinish - touchTimeStart;
        //     rb.isKinematic = false;
        //     rb.AddForce(0,100f,throwForceInZ / timeInterval);
        // }
	}

	public void Reset()
	{
		scoreValue++;
        //  Debug.Log(scoreValue);
        scoreText.text = "Attempts: " + scoreValue.ToString();

		rb.isKinematic = true;
		// ball.transform.position = new Vector3(0.0f,-0.12f,0.383f);
		ball.transform.localPosition = new Vector3(0.0f,-0.12f,0.383f);
		ball.transform.localRotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
	}

	public IEnumerator ResetAfterTime(float passtime){
		yield return new WaitForSeconds(passtime);
		Debug.Log("Reset");

		scoreValue++;
        //  Debug.Log(scoreValue);
        scoreText.text = "Attempts: " + scoreValue.ToString();

		rb.isKinematic = true;
		// ball.transform.position = new Vector3(0.0f,-0.12f,0.383f);
		ball.transform.localPosition = new Vector3(0.0f,-0.12f,0.383f);
		ball.transform.localRotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
	}
}
