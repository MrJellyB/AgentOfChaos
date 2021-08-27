using System.Timers;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public Rigidbody body;
    public GameObject bulletPrefab;
    public GameObject towerPrefab;
    public float speed = 5;

    public float spread = 2.5f;

    public float shotsPerSecond = 10f;

    private float timeSinceShot = 0f;
    private float shotCooldown = 0f;
    // Start is called before the first frame update
    void Start()
    {
        shotCooldown = 1 / shotsPerSecond;
    }

    // Update is called once per frame
    void Update()
    {
        timeSinceShot += Time.deltaTime;
        var x = Input.GetAxis("Horizontal") * Time.deltaTime;
        var y = Input.GetAxis("Vertical") * Time.deltaTime;
        var offset = new Vector3(x, 0, y);
        body.MovePosition(body.position + offset * speed);
        var mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition,Camera.MonoOrStereoscopicEye.Mono);
        if (Physics.Raycast(mouseRay, out RaycastHit hitInfo, maxDistance: 200f))
        {
            var target = hitInfo.point;
            target = new Vector3(target.x,body.position.y,target.z);
            Debug.DrawLine(body.position,target, Color.red);
            //target.y = 0;
            body.transform.LookAt(target);
            // this.transform.rotation = Quaternion.LookRotation(target, Vector3.up);
        }

        if (Input.GetMouseButton(0) && timeSinceShot >= shotCooldown)
        {
            timeSinceShot = 0;
            var eulerRotation = body.rotation.eulerAngles + Vector3.up * Random.Range(-spread, spread);
            Instantiate(bulletPrefab, body.transform.position+body.transform.forward, Quaternion.Euler(eulerRotation));
        }
        if (Input.GetMouseButtonDown(1))
        {
            var t = Instantiate(towerPrefab, body.transform.position+body.transform.forward, body.rotation);
            var pm = t.GetComponent<ProjectileMultiplexer>();
            pm.multiplyAmount = Random.Range(2, 7);
            if (pm.multiplyAmount > 4)
            {
                pm.angle = Random.Range(10f, 30f);
            }
            else
            {
                pm.angle = Random.Range(25f, 75f);
            }
        }
    }
}
