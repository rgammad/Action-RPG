using UnityEngine;
using System.Collections;

public class ProjectileBehavior : MonoBehaviour
{
    public int projectileSpeed;
    void Awake()
    {
        gameObject.GetComponent<Rigidbody>().velocity = projectileSpeed * transform.forward;
    }
    void OnTriggerExit(Collider col)
    {
        if (col.CompareTag("Wall"))
        {
            Destroy(this.gameObject);
        }
    }
}
