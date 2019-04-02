using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class throwManager : MonoBehaviour {

	private Vector3 startPos; //mouse slide movement start pos
	private Vector3 endPos; //mouse slide movement end pos
	private bool isThrown;
	private bool notThrown;
	public float mult = 5f;

	public GameObject ball;

	void Start(){
		isThrown=false;
		notThrown=true;
	}

	void Update () 
	{
		if (Input.GetKeyDown(KeyCode.R)) {
			SceneManager.LoadScene ("Scene1"); // Reset scene on pressing R
		}

		if (isThrown) {
			return; //prevent user from accesing ball after being thrown
		}

		if(notThrown){
			ball.GetComponent<Rigidbody>().isKinematic = false;
			ball.GetComponent<Rigidbody>().useGravity = false;
		}

		if (Input.GetMouseButtonDown (0)) {
			//get start mouse position
			Vector3 mousePos = Input.mousePosition*-1.0f;

			startPos = Camera.main.ScreenToWorldPoint(mousePos);

			//Print start Pos for debugging
			Debug.Log ("startpos"+startPos);
		}

		if(Input.GetMouseButtonUp(0))
		{
			
			//get release mouse position
			Vector3 mousePos = Input.mousePosition *-1.0f;

			// convert mouse position to world position
			endPos= Camera.main.ScreenToWorldPoint(mousePos);
			endPos.z = Camera.main.nearClipPlane; //removing this breaks stuff,no idea why though
			notThrown = false;
			//Print start Pos for debugging
			Debug.Log ("endpos"+endPos);

			Vector3 throwDir = this.transform.forward;//get throw direction based on start and end pos
			ball.GetComponent<Rigidbody>().isKinematic = true;
			ball.GetComponent<Rigidbody>().useGravity = true;
			ball.gameObject.GetComponent<Rigidbody> ().AddForce (throwDir*(startPos - endPos).sqrMagnitude*mult);//add force to throw direction*magnitude

			isThrown = true;
			
		}
		// Debug.Log(Input.touchCount);
		// if(Input.touchCount > 0){
		// 	Debug.Log("FOUND");
		// 	if(Input.GetTouch(0).phase == TouchPhase.Began){
		// 		Vector3 mousePos = Input.GetTouch(0).position;

		// 		startPos = Camera.main.ScreenToWorldPoint(mousePos);

		// 		//Print start Pos for debugging
		// 		Debug.Log ("startpos"+startPos);
		// 	}
		// 	if(Input.GetTouch(0).phase == TouchPhase.Ended){
		// 		Vector3 mousePos = Input.mousePosition *-1.0f;

		// 		// convert mouse position to world position
		// 		endPos= Camera.main.ScreenToWorldPoint(mousePos);
		// 		notThrown = false;
		// 		//Print start Pos for debugging
		// 		Debug.Log ("endpos"+endPos);

		// 		Vector3 throwDir = this.transform.forward;//get throw direction based on start and end pos
		// 		ball.GetComponent<Rigidbody>().isKinematic = true;
		// 		ball.GetComponent<Rigidbody>().useGravity = true;
		// 		this.gameObject.GetComponent<Rigidbody> ().AddForce (throwDir*(startPos - endPos).sqrMagnitude*mult);//add force to throw direction*magnitude

		// 		isThrown = true;
		// 	}
		// }
	}

}
