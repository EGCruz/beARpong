using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class basket : MonoBehaviour
{
	private static int cups=0; 
    public GameObject canvas1;
    public GameObject winCanvas;
    
    void Awake()
    {
        
    }

    void Start()
    {
        cups=0;
    }

	void OnCollisionEnter() //if ball hits board
    {
        cups++;
        Debug.Log(cups);
        
        Destroy (transform.parent.gameObject);
        Destroy (gameObject);

        if(cups >= 10)
        {
            winCanvas.SetActive(true);
            canvas1.SetActive(false);
            Debug.Log("win");

        }
            
    }
}
