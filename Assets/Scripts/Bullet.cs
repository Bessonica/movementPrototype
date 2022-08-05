using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Transform target;
    public float speed = 70f;
    public int damage = 60;

    // _target почему написано так?
    public void Seek(Transform _target)
    {
        target = _target;
    }


    // Update is called once per frame
    void Update()
    {
        if(target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        if(dir.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
        }

        transform.Translate(dir.normalized * distanceThisFrame, Space.World);
    }

    void HitTarget()
    {
        // UnityEngine.Debug.Log("WE HIT ");
        EnemyMovement e = target.GetComponent<EnemyMovement>();
        if(e!=null)
        {
            e.TakeDamage(damage);
        }


        
        
        // HERE WE KILL enemies, for now we dont have hp system for them
        // Destroy(target.gameObject);
        Destroy(gameObject);
    }
}
