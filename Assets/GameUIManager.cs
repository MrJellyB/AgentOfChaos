using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameUIManager : MonoBehaviour
{
    public Image playerHpBar;

    public TextMeshProUGUI scoreText;
    // Start is called before the first frame update
    void Start()
    {
        GameEvents.PlayerHpChangedEvent += GameEventsOnPlayerHpChangedEvent;
    }

    private void GameEventsOnPlayerHpChangedEvent(float percentleft)
    {
        playerHpBar.fillAmount = percentleft;
    }

    public void UpdateScore(int score)
    {
        scoreText.text = score.ToString();
    }
}
