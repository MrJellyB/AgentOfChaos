using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EntityStats : MonoBehaviour
{
    private int originalHp;
    private Transform ownHealthBar;

    public int hp = 100;
    public bool showBar = false;
    public Transform HealthBar;

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
        Projectile bullet = collision.gameObject.GetComponentInParent<Projectile>();

        if (bullet != null)
        {
            int hit = bullet.damage;

            if (hp - hit <= 0)
            {
                GameEvents.InvokeEntityDeathEvent(this);
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
