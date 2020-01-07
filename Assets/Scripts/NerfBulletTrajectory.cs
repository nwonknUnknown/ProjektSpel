using UnityEngine;

//Simon Voss
//Moves this bullet towards its target each frame, destroys the bullet if target dies

public class NerfBulletTrajectory : MonoBehaviour
{

    [SerializeField] internal float bulletSpeed = 1f;
    [SerializeField] float explosionRadius = 0f;
    GameObject targetObject;
    GameObject turretObject;
    Projectile projectileValues;
    private int damage;

    void Start()
    {
        projectileValues = gameObject.GetComponent<Projectile>();
        targetObject = projectileValues.TargetObject;
        turretObject = projectileValues.TurretObject;
        damage = projectileValues.Damage;
    }
    void Update()
    {
        Shoot();
    }

    void Shoot()
    {
        if (targetObject == null || targetObject.GetComponent<EnemyStats>().hp <= 0)
        {
            Destroy(gameObject);
            return;
        }
        transform.LookAt(targetObject.transform);

        transform.Translate(0, 0, bulletSpeed * Time.deltaTime * 100);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (explosionRadius > 0f)
        {
            Explode();
        }
        else
        {
            collision.gameObject.GetComponent<EnemyStats>().RemoveHP(damage);
        }
        Destroy(gameObject);
    }

    void Explode()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);
        foreach (Collider collider in colliders)
        {
            if (collider.tag == "enemy")
            {
                Damage(collider.transform);
            }
        }
    }
    void Damage(Transform enemy)
    {

        enemy.gameObject.GetComponent<EnemyStats>().RemoveHP(damage);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explosionRadius);
    }
}
