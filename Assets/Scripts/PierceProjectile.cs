using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PierceProjectile : MonoBehaviour
{
    [SerializeField] float timeToLive = 10;
    [SerializeField] float bulletSpeed = 1;
    [SerializeField] int maxEnemiesHitNumber;
    int enemiesHitNumberSoFar = 0;
    int damage;
    float time = 0;
    GameObject targetObject;
    Projectile projectileValues;


    void Start()
    {
        projectileValues = gameObject.GetComponent<Projectile>();
        damage = projectileValues.Damage;
        targetObject = projectileValues.TargetObject;
        LookAtTargetDirection();
    }
    
    void Update()
    {
        ShootMovement();
        CheckIfBulletDies();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (targetObject.GetComponent<EnemyStats>() != null)
        {
            targetObject.GetComponent<EnemyStats>().RemoveHP(damage);
            enemiesHitNumberSoFar++;
        }
    }

    void LookAtTargetDirection()
    {
        transform.LookAt(targetObject.transform);
        transform.rotation = Quaternion.Euler(new Vector3(0, transform.eulerAngles.y, transform.eulerAngles.z));
        
    }

    void ShootMovement()
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
        if (timeToLive < time || enemiesHitNumberSoFar >= maxEnemiesHitNumber)
        {
            Destroy(gameObject);
        }
    }
}
