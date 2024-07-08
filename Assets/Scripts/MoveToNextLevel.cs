using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveToNextLevel : MonoBehaviour
{
    public int nextsceneLoad;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void NextLevel()
    {
        SceneManager.LoadScene(nextsceneLoad);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (SceneManager.GetActiveScene().buildIndex == 10)
            {
                Debug.Log("You Won The Game");
            }
            else
            {
                SceneManager.LoadScene(nextsceneLoad);

                if (nextsceneLoad > PlayerPrefs.GetInt("levelAt"))
                {
                    PlayerPrefs.SetInt("levelAt", nextsceneLoad);
                }
            }
        }
    }
}
