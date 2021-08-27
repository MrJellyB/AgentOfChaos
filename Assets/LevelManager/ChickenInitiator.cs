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
    public Transform edge;
    public GameObject chickenToInitiate;
    public int countToInitiate = 0;
    public InitiateMode mode = InitiateMode.Circle;

    
    private Vector3 pointToInitiateAround;
    private float minGapBetweenPoints = 3;

    public float radius
    {
        get
        {
            return Vector3.Distance(transform.position, edge.position);
        }
    }

    public Vector3 pointToInLine
    {
        get
        {
            return edge.position;
        }
    }
    
    // Start is called before the first frame update
    void Start()
    {
        GameEvents.StartBatchEvent += InsantiateEnemies;
        pointToInitiateAround = transform.position;
    }

    private void InsantiateEnemies()
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
            Handles.DrawWireDisc(t.transform.position, Vector3.up, t.radius);
        }
        else
        {
            Handles.DrawLine(t.transform.position, t.pointToInLine, 2);
        }
    }
}