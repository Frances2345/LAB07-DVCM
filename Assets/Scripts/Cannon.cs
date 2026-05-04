using UnityEngine;

public class Cannon : MonoBehaviour
{
    public float range = 10f;
    public float rotationSpeed = 5f;

    public GameObject bulletPrefab;
    public Transform firePoint;
    public Transform head;

    private Transform target;

    void Update()
    {
        FindTarget();

        if (target == null) return;

        Aim();
        Shoot();
    }

    void FindTarget() // encuentra al enemigo más cercano dentro del rango
    {
        GameObject enemy = GameObject.FindGameObjectWithTag("Enemy");

        if (enemy == null)
        {
            target = null;
            return;
        }

        float dist = Vector3.Distance(transform.position, enemy.transform.position);

        if (dist <= range)
            target = enemy.transform;
        else
            target = null;
    }

    void Aim() // gira a torre para mirar 
    {
        Vector3 dir = target.position - transform.position;
        dir.y = 0f;

        Quaternion rot = Quaternion.LookRotation(dir);
        head.rotation = Quaternion.Slerp(head.rotation,rot,rotationSpeed * Time.deltaTime);

    }

    void Shoot() // dispara projétil
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
