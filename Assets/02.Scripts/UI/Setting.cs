using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Setting : MonoBehaviour
{
    public GameObject SettingUI;
    public GameObject resume;
    
    public static bool GameIsPaused;

    private void Awake() 
    {
        GameIsPaused = true;
        Time.timeScale = 1f;

        // Mouse Lock
        Cursor.lockState = CursorLockMode.Locked;
        // Cursor visible
        Cursor.visible = false;
    }
    
    
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(GameIsPaused == true)
            {
                Pause();

                // Mouse Lock
                Cursor.lockState = CursorLockMode.None;
                // Cursor visible
                Cursor.visible = true;
            }
            else if(GameIsPaused == false)
            {
                Resume();
                
                // Mouse Lock
                Cursor.lockState = CursorLockMode.Locked;
                // Cursor visible
                Cursor.visible = false;

            }
        }
    }

    public void Resume()
    {
        SettingUI.SetActive(false);
        resume.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = true;
    }

    public void Pause()
    {
        SettingUI.SetActive(true);
        resume.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = false;
    }
    
    public void Lobby()
    {
        SceneManager.LoadScene("Start");
    }

    public void Exit() 
    {
        Application.Quit();
    }
}
