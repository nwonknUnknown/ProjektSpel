﻿using UnityEngine;

//Simon Voss
//Moves this bullet towards its target each frame, destroys the bullet if target dies

public class NerfBulletTrajectory : MonoBehaviour
{

    [SerializeField] internal float bulletSpeed = 1f;
    internal GameObject targetObject;
    internal GameObject turretObject;

    public int damage;
    


    internal virtual void Update()
    {
        Shoot();
    }




    public void AssignTarget(GameObject towersTarget)
    {
        targetObject = towersTarget;
    }

    public void AssignTurret(GameObject newTurretObject)
    {
        turretObject = newTurretObject;
    }

    virtual internal void Shoot()
    {
        if (targetObject == null || targetObject.GetComponent<EnemyStats>().hp <= 0)
        {
            Destroy(gameObject);
            return;
        }
        transform.LookAt(targetObject.transform);

        transform.Translate(0, 0, bulletSpeed * Time.deltaTime * 100);
    }


    internal virtual void OnCollisionEnter(Collision collision)
    {
        collision.gameObject.GetComponent<EnemyStats>().RemoveHP(damage);
        Destroy(gameObject);
    }
}
