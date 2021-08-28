using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 0.1f;
    public int damage = 10;

    public int hops = 5;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        var dt = Time.deltaTime;
        this.transform.Translate(this.transform.forward * speed * dt, Space.World);
    }
}
