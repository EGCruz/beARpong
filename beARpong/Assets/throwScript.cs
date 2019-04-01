using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class throwScript : MonoBehaviour {
	Vector2 startPos, endPos, direction; // touch start position, touch end position, swipe direction
	float touchTimeStart, touchTimeFinish, timeInterval; // to calculate swipe time to sontrol throw force in Z direction

	// [SerializeField]
	// float throwForceInXandY = 0.5f; // to control throw force in X and Y directions

	[SerializeField]
	float throwForceInZ = 35f; // to control throw force in Z direction

    Transform camTransform;
	Rigidbody rb;
    // [SerializeField]
    // Transform farCup;

	public GameObject ball;

	void Start()
	{
		rb = GetComponent<Rigidbody> ();
	}

	void FixedUpdate () {

		// if you touch the screen
		if (Input.touchCount > 0 && Input.GetTouch (0).phase == TouchPhase.Began) {
            Debug.Log("Began");
			// getting touch position and marking time when you touch the screen
			touchTimeStart = Time.time;
			//startPos = Input.GetTouch (0).position;
		}
        // float reqRel = throwForceInZ/(farCup.position.z);
        // Debug.Log("required release time: "+reqRel);
		// if you release your finger
		if (Input.touchCount > 0 && Input.GetTouch (0).phase == TouchPhase.Ended) {
            Debug.Log("Release");
			// marking time when you release it
			touchTimeFinish = Time.time;

			// calculate swipe time interval 
			timeInterval = touchTimeFinish - touchTimeStart;

			// getting release finger position
			//endPos = Input.GetTouch (0).position;

			// calculating swipe direction in 2D space
			//direction = startPos - endPos;

			// add force to balls rigidbody in 3D space depending on swipe time, direction and throw forces
			rb.isKinematic = false;
            rb.AddForce(0,100f,throwForceInZ / timeInterval);
			//rb.AddForce (0, - direction.y * throwForceInXandY, throwForceInZ / timeInterval);
            //rb.AddForce(camTransform.forward*direction.sqrMagnitude);

			// Destroy ball in 4 seconds
			// Destroy (gameObject, 3f);
			
		}

        if(Input.GetMouseButtonDown (0)){
            Debug.Log("Mouse Down");
            touchTimeStart = Time.time;
        }
        if(Input.GetMouseButtonUp(0)){
            Debug.Log("Mouse Up");
            touchTimeFinish = Time.time;
            timeInterval = touchTimeFinish - touchTimeStart;
            rb.isKinematic = false;
            rb.AddForce(0,100f,throwForceInZ / timeInterval);
        }
	}

	public void Reset()
	{
		rb.isKinematic = true;
		ball.transform.position = new Vector3(0.0f,0.659f,-1.623f);
		ball.transform.eulerAngles = new Vector3(0.0f,0.0f,0.0f);
	}
}
