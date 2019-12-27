using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AOEprojektil : NerfBulletTrajectory
{
    public float explosionRadius = 0f;

    void Start()
    {
        LookAtTargetDirection();
    }

    internal override void Update()
    {
        Shoot();
    }

    internal override void DoOnCollision(Collision collision)
    {
        if (explosionRadius > 0f)
        {
            Explode();
        }
        else
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

    void Damage(GameObject enemy)
    {

        if (targetObject.GetComponent<EnemyStats>().hp <= 0)
        {
            Destroy(enemy.gameObject);
            Debug.Log("destroy?");
            return;
        }
    }

    void Explode()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);

        foreach (Collider collider in colliders)
        {
            if (collider.tag == "enemy")
            {
                Damage(collider.gameObject);
            }
        }
    }
}
