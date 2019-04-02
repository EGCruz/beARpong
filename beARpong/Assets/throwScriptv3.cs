using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class throwScriptv3 : MonoBehaviour {
    public Rigidbody rb;
    public Transform planeTrans;

	public float forceMultiplier = 150f;
    private Vector2 startSwipe;
	private Vector2 endSwipe;
	private Vector3 originalPos;

    public static int scoreValue=0; //reference to the ScoreText gameobject, set in editor
	public Text scoreText;
    public Text scoreText2;

    public GameObject ball;

    void Start(){
        scoreValue = 0;
        // rb = GetComponent<Rigidbody>();
        originalPos = ball.transform.position;
    }

    void FixedUpdate(){
        if(Input.GetMouseButtonDown (0)){
            Debug.Log("Begin");

            startSwipe = Camera.main.ScreenToViewportPoint (Input.mousePosition) * 2;
            Debug.Log(startSwipe);
        }
        if (Input.GetMouseButtonUp (0)){
            endSwipe = Camera.main.ScreenToViewportPoint (Input.mousePosition) * 2;
            Vector2 swipe = startSwipe - endSwipe;
            Debug.Log("End");
            Debug.Log(swipe.y);
            if(Math.Abs(swipe.y) > 0){
                Launch();
            }
            StartCoroutine(ResetAfterTime(3f));
        }
    }

    void Launch(){
        rb.isKinematic = false;
		Vector2 swipe = startSwipe - endSwipe;
		float xforce = -(swipe.x * forceMultiplier);
        if(-10f <= xforce && xforce <= 10f)
            xforce = 0f;
		float yforce = Math.Abs((swipe.y * forceMultiplier)/2);
        float tentativeZ = (Math.Abs(planeTrans.position.z - ball.transform.position.z) + 1.25f)*forceMultiplier;
        float zforce;
        if(tentativeZ < yforce)
            zforce = tentativeZ;
        else
            zforce = yforce;

        rb.AddForce (xforce, 100f, zforce, ForceMode.Force);
        Debug.Log("xForce="+xforce+", zForce="+zforce);

        scoreValue++;
        scoreText.text = "Attempts: " + scoreValue.ToString();
        scoreText2.text = "Attempts: " + scoreValue.ToString();
    }

    public IEnumerator ResetAfterTime(float passtime){
		yield return new WaitForSeconds(passtime);
		Debug.Log("Reset");
		rb.isKinematic = true;
		// ball.transform.position = new Vector3(0.0f,-0.12f,0.383f);
		ball.transform.localPosition = new Vector3(0.0f,-0.12f,0.383f);
		ball.transform.localRotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
	}
}