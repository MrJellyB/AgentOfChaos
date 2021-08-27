using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameStats : MonoBehaviour
{
    public int winningWavesCount = 5;
    public int desiredCrossedEnemies = 100;
    public Canvas scoreCanvas;
    public Canvas enemyCountCanvas;

    private int score = 0;
    private int crossedEnemies = 0;

    // Start is called before the first frame update
    void Start()
    {
        GameEvents.EntityDeathEvent += GameEvents_EntityDeathEvent;
        GameEvents.CrossedEnemyEvent += GameEvents_CrossedEnemyEvent;

        TextMeshProUGUI scoreText = scoreCanvas.GetComponentInChildren<TextMeshProUGUI>();
        scoreText.text += " " + score;
    }

    private void GameEvents_CrossedEnemyEvent()
    {
        crossedEnemies++;
        TextMeshProUGUI enemyText = enemyCountCanvas.GetComponentInChildren<TextMeshProUGUI>();
        enemyText.text = string.Format("Enemy crossed: {0}/{1}", crossedEnemies, desiredCrossedEnemies);
    }

    private void GameEvents_EntityDeathEvent(EntityStats stats)
    {
        score += 10;

        TextMeshProUGUI scoreText = scoreCanvas.GetComponentInChildren<TextMeshProUGUI>();
        scoreText.text =  "Score: " + score;
    }

    // Update is called once per frame
    void Update()
    {
    }
}
