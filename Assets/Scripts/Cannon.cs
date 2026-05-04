using UnityEngine;

public class Cannon : MonoBehaviour
{
    public GameObject Enemy;


    public GameObject turretPrefab;
    public bool aimMode;
    public float rotationSpeed;
    public Transform spawnCannon;

    void Start()
    {

    }

    void Update()
    {
        Shoot();
        SpawnCannon();
    }

    public void Shoot()
    {


        Vector3 HeadDir = (Enemy.transform.position - transform.position);

        Quaternion targetQuaternion = Quaternion.LookRotation(HeadDir);
        transform.rotation = targetQuaternion;
        turretPrefab.transform.rotation = Quaternion.Slerp(turretPrefab.transform.rotation, targetQuaternion, rotationSpeed * Time.deltaTime);




    }

    public void SpawnCannon()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            Instantiate(turretPrefab, spawnCannon.position, spawnCannon.rotation);
        }
    }
}