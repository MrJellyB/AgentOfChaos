using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void StartBatchHandler();

public class GameEvents
{
    public static event StartBatchHandler StartBatchEvent;

    public static void InvokeStartBatchEvent()
    {
        StartBatchEvent?.Invoke();
    }
}
