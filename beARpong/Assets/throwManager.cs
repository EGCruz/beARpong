using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class throwManager : MonoBehaviour {

	private Vector3 startPos; //mouse slide movement start pos
	private Vector3 endPos; //mouse slide movement end pos
	private bool isThrown;
	private bool preThrow;
	public float mult = 5f;

	[SerializeField] private GameObject imgTgt;
	[SerializeField] private GameObject ballSpawn;
	[SerializeField] private GameObject ball;

	void Start(){
		isThrown=false;
		preThrow=true;
	}

	void Update () 
	{
		Debug.Log(imgTgt.transform.position-ballSpawn.transform.position);
		if (Input.GetKeyDown(KeyCode.R)) {
			SceneManager.LoadScene ("Scene1"); // Reset scene on pressing R
		}

		if (isThrown) {
			return; //prevent user from accesing ball after being thrown
		}


		if (Input.GetMouseButtonDown (0)) {
			//get start mouse position
			Vector3 mousePos = Input.mousePosition*-1.0f;

			startPos = Camera.main.ScreenToWorldPoint(mousePos);

			//Print start Pos for debugging
			Debug.Log (startPos);
		}

		if(Input.GetMouseButtonUp(0))
		{
			
			//get release mouse position
			Vector3 mousePos = Input.mousePosition *-1.0f;

			// convert mouse position to world position
			// endPos= Camera.main.ScreenToWorldPoint(mousePos);
			// endPos.z = Camera.main.nearClipPlane; //removing this breaks stuff,no idea why though
			preThrow = false;
			//Print start Pos for debugging
			Debug.Log (endPos);

			Vector3 throwDir = this.transform.forward;//get throw direction based on start and end pos

			this.gameObject.GetComponent<Rigidbody> ().AddForce (throwDir*(startPos - endPos).sqrMagnitude*mult);//add force to throw direction*magnitude

			isThrown = true;
			
		}

		if(preThrow){
			ball.transform.position = ballSpawn.transform.position;
		}

	}

}
