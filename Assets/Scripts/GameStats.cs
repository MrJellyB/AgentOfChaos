using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameStats : MonoBehaviour
{
    public int winningWavesCount = 5;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI enemyText;
    public string chickensLeftTitle = "Chickens Left: {0}";

    private int score = 0;
    private int leftEnemies = 100;

    // Start is called before the first frame update
    void Start()
    {
        GameEvents.EntityDeathEvent += GameEvents_EntityDeathEvent;
        GameEvents.CrossedEnemyEvent += GameEvents_CrossedEnemyEvent;

        scoreText.text += " " + score;
    }

    private void GameEvents_CrossedEnemyEvent()
    {
        leftEnemies--;
        enemyText.text = string.Format(chickensLeftTitle, leftEnemies);

        if (leftEnemies == 0)
        {
            // Game over
        }
    }

    private void GameEvents_EntityDeathEvent(EntityStats stats)
    {
        score += 10;

        scoreText.text =  "Score: " + score;
    }

    // Update is called once per frame
    void Update()
    {
    }
}
