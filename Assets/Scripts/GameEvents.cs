using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void StartBatchHandler();
public delegate void CrossedEnemyHandler();
public delegate void DiedEnemyHandler();
public delegate void GameOverHandler();
public delegate void EntityDeathHandler(EntityStats stats);
public delegate void PlayerHpChangedHandler(float percentLeft);


public class GameEvents
{
    public static event StartBatchHandler StartBatchEvent;
    public static event CrossedEnemyHandler CrossedEnemyEvent;
    public static event DiedEnemyHandler DiedEnemyEvent;
    public static event EntityDeathHandler EntityDeathEvent;
    public static event GameOverHandler GameOverEvent;

    public static event PlayerHpChangedHandler PlayerHpChangedEvent;
    public static void InvokeStartBatchEvent()
    {
        StartBatchEvent?.Invoke();
    }

    public static void InvokeGameOverEvent()
    {
        GameOverEvent?.Invoke();
    }

    public static void InvokeCrossedEnemyEvent()
    {
        CrossedEnemyEvent?.Invoke();
    }

    public static void InvokeDiedEnemyEvent()
    {
        DiedEnemyEvent?.Invoke();
    }

    public static void InvokeEntityDeathEvent(EntityStats stats)
    {
        EntityDeathEvent?.Invoke(stats);
    }

    public static void InvokePlayerHpChangedEvent(float hpPercent)
    {
        PlayerHpChangedEvent?.Invoke(hpPercent);
    }
}
