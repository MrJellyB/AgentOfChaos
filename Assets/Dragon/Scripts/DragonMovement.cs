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
    public int speed = 5;

    public bool drawGizmos = false;

    // Start is called before the first frame update
    void Start()
    {
        pathQueue = new Queue<Transform>(path);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Time.frameCount % frameUpdateInterval == 0) {
            if (pathQueue.Count != 0)
            {
                Transform gotoPoint = pathQueue.Peek();
                Vector3 heading = gotoPoint.position - m_rigidbody.position;
                heading.y = 0;
                Vector3 normalizedHeading = heading.normalized;

                if (Vector3.Dot(Vector3.one, heading) > 0f)
                {
                    m_rigidbody.transform.LookAt(gotoPoint.position);


                    switch (movementMode)
                    {
                        case MovementMode.ByForce:
                            {
                                m_rigidbody.AddForce(normalizedHeading * force, ForceMode.Acceleration);
                                break;
                            }
                        case MovementMode.ByTranslte:
                            {
                                var x = normalizedHeading.x * Time.deltaTime;
                                var y = normalizedHeading.z * Time.deltaTime;
                                var offset = new Vector3(x, 0, y) * (float)speed;
                                m_rigidbody.MovePosition(m_rigidbody.transform.position + offset);

                                break;
                            }
                        default:
                            break;
                    }
                    if (movementMode == MovementMode.ByForce)
                    {
                        m_rigidbody.AddForce(heading.normalized * force, ForceMode.Acceleration);
                    }
                        //m_rigidbody.MovePosition(gotoPoint);
                }
                else
                {
                    pathQueue.Dequeue();
                }
            } else
            {
                m_rigidbody.Sleep();
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
