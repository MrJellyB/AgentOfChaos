using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonMovement : MonoBehaviour
{

    public Rigidbody m_rigidbody;
    public float force;
    public int frameUpdateInterval = 100;
    Queue<Transform> pathQueue;
    public Transform[] path;

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

                if (Vector3.Dot(Vector3.one, heading) > 0f)
                {
                    m_rigidbody.transform.LookAt(gotoPoint.position);
                    m_rigidbody.AddForce(heading.normalized * force, ForceMode.Acceleration);
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
