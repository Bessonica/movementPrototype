using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// test turrets
// how fast should they be, how much hp enemy should have
//           dont forget to hide bullets


public class Turret : MonoBehaviour
{

    public Transform target;

    [Header("Attributes of turret")]
    public float range = 15f;
    public float fireRate = 1f;
    private float fireCountdown = 0f;


    [Header("Attributes of bullet")]
    public GameObject bulletPrefab;
    public Transform firePoint;

    [Header("Enemy tag(dont change it) shows at whoom to shoot")]
    public string enemyTag = "Enemy";







    void Start()
    {
        //  can reuse this function???
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }

    void UpdateTarget()
    {
        //  can reuse this function??? for waves, ways maybe
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);

            if(distanceToEnemy<shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        if(nearestEnemy != null && shortestDistance <= range)
        {
            target = nearestEnemy.transform;
        }
        else
        {
            target = null;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(target == null)
        {
            return;
        }

        if(fireCountdown <= 0f)
        {
            Shoot();
            fireCountdown = 1f/fireRate;
        }
        // how this works, if fireCountdown if 3 then game waits 3 seconds?
        fireCountdown -= Time.deltaTime;
        
    }

    void Shoot()
    {
        // UnityEngine.Debug.Log("Shooting you");
// this is important code, understand it!!!
        GameObject bulletGameObject = (GameObject)Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Bullet bullet = bulletGameObject.GetComponent<Bullet>();

        if(bullet != null)
        {
            bullet.Seek(target);
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        // UnityEngine.Debug.Log(transform.position);
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
