using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PierceProjectile : NerfBulletTrajectory
{
    
    Collider rangeTriggerArea;



    void Start()
    {
        LookAtTargetDirection();
        FindRangeTrigger();
    }
    
    internal override void Update()
    {
        Shoot();

    }
    
    void OnTriggerExit(Collider other)//for range
    {
        if (other == rangeTriggerArea && rangeTriggerArea != null)
        {
            Destroy(gameObject);
        }
    }

    internal override void OnCollisionEnter(Collision collision)
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

    void FindRangeTrigger()
    {
        rangeTriggerArea = turretObject.GetComponent<SphereCollider>();
    }

    override internal void Shoot()
    {
        MoveForward();

    }

    void MoveForward()
    {
        transform.position += transform.forward * Time.deltaTime * bulletSpeed;
    }
}
