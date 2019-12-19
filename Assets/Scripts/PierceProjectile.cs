using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PierceProjectile : NerfBulletTrajectory
{
    
    [SerializeField] float timeToLive;
    float time = 0;


    void Start()
    {
        LookAtTargetDirection();
    }
    
    internal override void Update()
    {
        Shoot();
        CheckIfBulletDies();

    }
    
    internal override void DoOnCollision(Collision collision)
    {
        if (targetObject.GetComponent<EnemyStats>() != null)
        {
            targetObject.GetComponent<EnemyStats>().RemoveHP(damage);

        }
    }

    void LookAtTargetDirection()
    {
        transform.LookAt(targetObject.transform);
    }

    override internal void Shoot()
    {
        MoveForward();

    }

    void MoveForward()
    {
        transform.position += transform.forward * Time.deltaTime * bulletSpeed;
    }

    void CheckIfBulletDies()
    {
        time += Time.deltaTime;
        if (timeToLive < time)
        {
            Destroy(gameObject);
        }
    }
}
