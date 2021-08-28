using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuNavigation : MonoBehaviour
{

    public void StartLevelButton()
    {
        //GetComponent<AudioSource>().Play();
        SceneManager.LoadScene("DemoScene");
    }

    public void ExitGameButton()
    {
        //GetComponent<AudioSource>().Play();
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
