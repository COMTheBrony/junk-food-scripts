using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PauseMenu : MonoBehaviour
{
    public static bool IsPaused = false;
    public GameObject menusUI;
    public GameObject pauseMenu;
    public GameObject optionsMenu;

    private void Start()
    {
        if(IsPaused != false)
            IsPaused = false;
        menusUI.gameObject.SetActive(false);
        pauseMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (IsPaused)
            {
               Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        Cursor.visible = false;
        menusUI.SetActive(false);
        pauseMenu.SetActive(false);
        optionsMenu.SetActive(false);
        Time.timeScale = 1f;
        IsPaused = false;
        AudioListener.pause = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Pause()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        menusUI.SetActive(true);
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        IsPaused = true;
        AudioListener.pause = true;
    }

    public void Controls()
    {
        Debug.Log("Controles");
    }

    public void QuitGame()
    {
        Debug.Log("QuitGame");
        Application.Quit();
    }
}
