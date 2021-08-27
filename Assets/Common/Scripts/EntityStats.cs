using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void EntityDeathHandler(EntityStats stats);

public class EntityStats : MonoBehaviour
{
    private int originalHp;
    private Transform ownHealthBar;

    public int hp = 100;
    public int hit = 10;
    public bool showBar = false;
    public Transform HealthBar;

    public static event EntityDeathHandler EntityDeathEvent;

    private void Start()
    {
        originalHp = hp;
        if (showBar)
        {
            ownHealthBar = Instantiate(HealthBar, transform.position + (Vector3.up * 2), Quaternion.identity);
        }
    }

    // TODO: change collsion to ballistic object class
    public void OnCollisionEnter(Collision collision)
    {
        if (collision?.transform?.parent?.GetComponent<Projectile>() != null)
        {
            if (hp - hit <= 0)
            {
                EntityStats.EntityDeathEvent?.Invoke(this);
                gameObject.SetActive(false);
                ownHealthBar?.gameObject.SetActive(false);
            }
            else
            {
                hp -= hit;

                if (showBar)
                {
                    Transform healthPlane = ownHealthBar.Find("healthPlane");
                    healthPlane.localScale = new Vector3(
                        healthPlane.localScale.x * (float)hp / (float)originalHp,
                        healthPlane.localScale.y,
                        healthPlane.localScale.z
                    );
                }
            }
        }
    }

    private void FixedUpdate()
    {
        if (showBar)
        {
            Vector3 updatedPos = transform.position + (Vector3.up * 2);
            if (Camera.current != null)
            {
                ownHealthBar.transform.SetPositionAndRotation(updatedPos, Quaternion.LookRotation(Vector3.up, Camera.current.transform.position));
            }
        }
    }
}
