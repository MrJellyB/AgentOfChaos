using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void StartBatchHandler();
public delegate void CrossedEnemyHandler();
public delegate void DiedEnemyHandler();
public delegate void EntityDeathHandler(EntityStats stats);

public class GameEvents
{
    public static event StartBatchHandler StartBatchEvent;
    public static event CrossedEnemyHandler CrossedEnemyEvent;
    public static event DiedEnemyHandler DiedEnemyEvent;
    public static event EntityDeathHandler EntityDeathEvent;

    public static void InvokeStartBatchEvent()
    {
        StartBatchEvent?.Invoke();
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
}
