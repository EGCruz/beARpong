using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseGame : MonoBehaviour {

    public GameObject canvas1;
    public GameObject canvas2;

    void Update()
    {

    }

    public void Pause()
    {
        if(canvas2.activeInHierarchy == false)
        {
            canvas2.SetActive(true);
            canvas1.SetActive(false);
            Time.timeScale = 0;
        }

        else
        {
            canvas1.SetActive(true);
            canvas2.SetActive(false);
            Time.timeScale = 1;
        }
        
    }

    public void BackToMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("initUI"); 
    }
}
