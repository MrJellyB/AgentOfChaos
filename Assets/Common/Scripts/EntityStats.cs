using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EntityStats : MonoBehaviour
{
    private int originalHp;
    private Transform ownHealthBar;

    public int score = 10;
    public int hp = 100;
    public bool showBar = false;
    public Transform HealthBar;
    public GameObject onDeathEffect;
    public ClipPlayer onDeathClip;
    public void AddHP(int bonusHp)
    {
        hp = Mathf.Max(hp + bonusHp, originalHp);
    }
    
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
                if (CompareTag("Player"))
                {
                    GameEvents.InvokePlayerHpChangedEvent(0);
                }

                gameObject.SetActive(false);
                Destroy(gameObject);
                ownHealthBar?.gameObject.SetActive(false);
                if (onDeathEffect != null)
                {
                    Instantiate(onDeathEffect, transform.position, Quaternion.identity);
                }

                if (onDeathClip != null)
                {
                    onDeathClip.Play();
                }
            }
            else
            {
                hp -= hit;
                if (CompareTag("Player"))
                {
                    GameEvents.InvokePlayerHpChangedEvent(hp*1f / originalHp);
                }

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
