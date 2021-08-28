using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEditor;
using UnityEngine;

public enum LevelState
{
    Rest,
    Wave
}

public class WavesManager : MonoBehaviour
{
    public float waveTimeSeconds;
    public float inBetweenBatchSeconds;
    public float restTimeSeconds;

    [HideInInspector]
    public float waveTimeLeftSeconds;
    [HideInInspector]
    public float inBetweenBatchLeftSeconds;
    [HideInInspector]
    public float restTimeLeftSeconds;
    
    private LevelState state = LevelState.Rest;
    
    // Start is called before the first frame update
    void Start()
    {
        waveTimeLeftSeconds = waveTimeSeconds;
        inBetweenBatchLeftSeconds = inBetweenBatchSeconds;
        restTimeLeftSeconds = restTimeSeconds;
    }

    // Update is called once per frame
    void Update()
    {
        switch (state)
        {
            case (LevelState.Rest):
                {
                    restTimeLeftSeconds -= Time.deltaTime;

                    if (restTimeLeftSeconds < 0)
                    {
                        state = LevelState.Wave;
                        restTimeLeftSeconds = restTimeSeconds;
                    }

                    break;
                }
            case (LevelState.Wave):
                {
                    if (inBetweenBatchLeftSeconds < 0)
                    {
                        GameEvents.InvokeStartBatchEvent();
                        inBetweenBatchLeftSeconds = inBetweenBatchSeconds;
                    } 

                    waveTimeLeftSeconds -= Time.deltaTime;
                    inBetweenBatchLeftSeconds -= Time.deltaTime;

                    if (waveTimeLeftSeconds < 0)
                    {
                        state = LevelState.Rest;
                        waveTimeLeftSeconds = waveTimeSeconds;
                        inBetweenBatchLeftSeconds = inBetweenBatchSeconds;
                    }
                    break;
                }
            default:
            {
                break;
            }
        }
    }
}

//[CustomEditor(typeof(WavesManager))]
//public class WavesManagerEditor : Editor
//{
//    public void Start()
//    {

//    }

//    public void OnSceneGUI()
//    {
//        var t = target as WavesManager;

//        Handles.Label(
//            Camera.current.transform.position - Vector3.one, 
//            "Rest Timer: " + (int)t.restTimeLeftSeconds + " Wave Timer: " + (int)t.waveTimeLeftSeconds);
//    }
//}
