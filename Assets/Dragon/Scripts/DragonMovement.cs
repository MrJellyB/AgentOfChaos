using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MovementMode
{
    ByForce,
    ByTranslte
}

public class DragonMovement : MonoBehaviour
{

    public Rigidbody m_rigidbody;
    public float force;
    public int frameUpdateInterval = 100;
    Queue<Transform> pathQueue;
    public Transform[] path;
    public MovementMode movementMode = MovementMode.ByForce;
    public float speed = 5f;
    public float targetAreaRadius = 2f;

    public bool drawGizmos = false;

    private Vector3 instantiationPoint;

    // Start is called before the first frame update
    void Start()
    {
        pathQueue = new Queue<Transform>(path);
        instantiationPoint = transform.position;
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(instantiationPoint, path[0].position);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Time.frameCount % frameUpdateInterval == 0) {
            if (pathQueue.Count != 0)
            {
                Transform gotoPoint = pathQueue.Peek();
                Vector3 route = gotoPoint.position - instantiationPoint; 
                Vector3 distance = gotoPoint.position - m_rigidbody.position;
                distance.y = 0;
                Vector3 normalizedDistance = distance.normalized;

                if (Mathf.Abs(Vector3.Dot(Vector3.one, distance)) > targetAreaRadius)
                {
                    m_rigidbody.transform.LookAt(gotoPoint.position);


                    switch (movementMode)
                    {
                        case MovementMode.ByForce:
                            {
                                m_rigidbody.AddForce(normalizedDistance * force, ForceMode.Acceleration);
                                break;
                            }
                        case MovementMode.ByTranslte:
                            {
                                var x = route.x * Time.deltaTime;
                                var y = route.z * Time.deltaTime;
                                Debug.Log(string.Format("x: {0} y: {0}", x, y));
                                var offset = new Vector3(x * (float)speed, 0, y * (float)speed);
                                m_rigidbody.MovePosition(m_rigidbody.transform.position + offset);

                                break;
                            }
                        default:
                            break;
                    }
                    if (movementMode == MovementMode.ByForce)
                    {
                        m_rigidbody.AddForce(distance.normalized * force, ForceMode.Acceleration);
                    }
                        //m_rigidbody.MovePosition(gotoPoint);
                }
                else
                {
                    pathQueue.Dequeue();
                }
            } else
            {
                GameEvents.InvokeCrossedEnemyEvent();
                Destroy(m_rigidbody.gameObject);
            }
        }
    }


    void OnDrawGizmos()
    {
        if (drawGizmos)
        {
            foreach (var item in path)
            {
                Gizmos.color = Color.yellow;
                Gizmos.DrawSphere(item.position, 0.1f);
            }
        }
    }
}
