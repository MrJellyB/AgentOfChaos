using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameFlowManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameEvents.GameOverEvent += GameEvents_GameOverEvent;
    }

    private void GameEvents_GameOverEvent()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
