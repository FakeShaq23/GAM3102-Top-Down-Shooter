using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string startScene;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.N))
        {
            PlayerPrefs.DeleteAll();
        }
    }

    // Start is called before the first frame update
    public void StartGame()
    {
        SceneManager.LoadScene(startScene);
    }

    // Update is called once per frame
    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
