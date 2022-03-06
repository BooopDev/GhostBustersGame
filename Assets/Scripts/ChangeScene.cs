using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public bool isReady;
    // Update is called once per frame
    void Update()
    {
        if(isReady)
        {
            SceneManager.LoadScene("Level");
        }
    }

    public void ChangeScenes(string levelName)
    {
        SceneManager.LoadScene(levelName);
    }

    public void End()
    {
        Application.Quit();
    }
}
