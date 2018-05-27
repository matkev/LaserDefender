using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

    

    public void Start()
    {

    }

    public void LoadLevel(string name)
    {
        Debug.Log("Level load requested for: " + name);
        Application.LoadLevel(name);

    }

    public void QuitRequest()
    {
        Debug.Log("Quit requested");

        Application.Quit();
    }

    public void LoadNextLevel()
    {
        print(Application.loadedLevel + 1);

       SceneManager.LoadScene(Application.loadedLevel + 1);
    }

    /*
    public void LoadLastLevel()
    {
        print(Application.loadedLevel);
        Application.LoadLevel(buildIndex);
    }
    */


    /*
    public void BrickDestroyed()
    {
        if (Brick.breakableCount == 0)
        {
            buildIndex++;

            print("index = " + buildIndex);
            print("winIndex = " + winIndex);

            if (buildIndex == winIndex)
            {
                buildIndex = 2;
                Destroy(diffSetting);
            }
            else
            {
                DifficultySetting.instance = null;
            }
            LoadNextLevel();
        }
    }
    */

}
