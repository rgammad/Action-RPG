using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    public GameObject projectile;
    public float fireRate;
    private Vector3 movePosition;
    private NavMeshAgent agent;
    private float waitTilNextFire;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        movePosition = transform.position;
        waitTilNextFire = 1;
    }
    // Update is called once per frame
    void Update()
    {
        MouseMovement();
        Shoot();
    }

    void MouseMovement()
    {

        RaycastHit clickPosition;
        Ray ray;
        if (Input.GetMouseButton(0))
        {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out clickPosition))
            {
                movePosition = clickPosition.point;
                agent.destination = movePosition;
                agent.Resume();
            }
        }
        else if (Input.GetMouseButton(1))
        {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if(Physics.Raycast(ray, out clickPosition))
            {
                Vector3 targetPos = new Vector3(clickPosition.point.x, transform.position.y, clickPosition.point.z);
                transform.LookAt(targetPos);
            }
            agent.Stop();
        }
    }

    void Shoot()
    {
        if (Input.GetMouseButton(1) || Input.GetMouseButtonDown(1))
        {
            if (waitTilNextFire <= 0)
            {
                GameObject clone = Instantiate(projectile, transform.TransformPoint(Vector3.forward), transform.rotation) as GameObject;
                waitTilNextFire = 1;
            }
        }
        waitTilNextFire -= Time.deltaTime * fireRate;
    }
}
