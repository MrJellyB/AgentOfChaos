using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameStats : MonoBehaviour
{
    public int allowedEnemyCrossings = 10; 
    public int score = 0;
    public int enemiesCrossed = 0;
    public GameUIManager uiManager;

    // Start is called before the first frame update
    void Start()
    {
        GameEvents.EntityDeathEvent += GameEventsOnEntityDeathEvent;
        GameEvents.CrossedEnemyEvent += GameEventsOnCrossedEnemyEvent;
    }

    private void GameEventsOnCrossedEnemyEvent()
    {
        enemiesCrossed += 1;

        if (enemiesCrossed == allowedEnemyCrossings)
        {
            GameEvents.InvokeGameOverEvent();
        }
    }

    private void GameEventsOnEntityDeathEvent(EntityStats stats)
    {
        if (stats.CompareTag("Chicken"))
        {
            score += stats.score;
            uiManager.UpdateScore(score);
        }
    }
}
