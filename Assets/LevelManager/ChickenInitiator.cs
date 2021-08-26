using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public enum InitiateMode
{
    Circle,
    Line
}

public class ChickenInitiator : MonoBehaviour
{
    public Vector3 pointToInitiateAround;
    public float radius = 5;
    public GameObject chickenToInitiate;
    public int countToInitiate = 0;
    public InitiateMode mode = InitiateMode.Circle;

    public Vector3 pointToInLine;

    private float minGapBetweenPoints = 3;

    // Start is called before the first frame update
    void Start()
    {
        if (mode == InitiateMode.Circle)
        {
            for (int i = 0; i < countToInitiate; i++)
            {
                Vector3 randomCircle = (Vector3)Random.insideUnitCircle * radius;
                randomCircle.Set(randomCircle.x, 2, randomCircle.y);
                Instantiate(chickenToInitiate, pointToInitiateAround + randomCircle, Quaternion.identity);
            }
        }
        else
        {
            float distance = Mathf.Abs(Vector3.Distance(pointToInitiateAround, pointToInLine));
            float maxGapBetweenPoints = distance / countToInitiate;

            for (int i = 0; i < countToInitiate; i++)
            {
                Vector3 direction = pointToInLine - pointToInitiateAround;
                Vector3 instantiationPoint = pointToInitiateAround + (direction.normalized * Random.Range(minGapBetweenPoints, maxGapBetweenPoints));

                Instantiate(chickenToInitiate, instantiationPoint, Quaternion.identity);

                distance = Mathf.Abs(Vector3.Distance(instantiationPoint, pointToInLine));
                maxGapBetweenPoints = distance / (countToInitiate - i);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}


[CustomEditor(typeof(ChickenInitiator))]
public class InitiatorEditor : Editor
{
    public void Start()
    {

    }

    public void OnSceneGUI()
    {
        var t = target as ChickenInitiator;
        var color = new Color(1, 0.8f, 0.4f, 1);
        Handles.color = color;
        if (t.mode == InitiateMode.Circle)
        {
            Handles.DrawWireDisc(t.pointToInitiateAround, Vector3.up, t.radius);
        }
        else
        {
            Handles.DrawLine(t.pointToInitiateAround, t.pointToInLine, 2);
        }
    }
}