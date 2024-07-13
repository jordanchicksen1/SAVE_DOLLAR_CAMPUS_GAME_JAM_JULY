using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class titleScreen : MonoBehaviour
{
    public GameObject cameraPlacer;
    public void playGame()
    {
        cameraPlacer.transform.position = new Vector3(23.2f, 0f, 0f);
        Debug.Log("it should move");
    }

    public void quitGame()
    {
        Application.Quit();
    }

    public void firsNext()
    {
        cameraPlacer.transform.position = new Vector3(45f, 0f, 0f);
    }

    public void secondNext()
    {
        cameraPlacer.transform.position = new Vector3(66f, 0f, 0f);
    }

    public void thirdNext()
    {
        cameraPlacer.transform.position = new Vector3(88f, 0f, 0f);
    }

    public void fourthNext() 
    {
        cameraPlacer.transform.position = new Vector3(106f, 0f, 0f);
    }

    public void fifthNext()
    {
        cameraPlacer.transform.position = new Vector3(125f, 0f, 0f);
    }

    public void sizthNext()
    {
        cameraPlacer.transform.position = new Vector3(145f, 0f, 0f);
    }

    public void seventhNext()
    {
        cameraPlacer.transform.position = new Vector3(165f, 0f, 0f);
    }

    public void lastNext()
    {
        cameraPlacer.transform.position = new Vector3(185f, 0f, 0f);
    }

    public void playButton()
    {
        SceneManager.LoadScene("LevelDesignTest");
    }
}
