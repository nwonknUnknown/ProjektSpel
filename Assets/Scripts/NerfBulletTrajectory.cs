using UnityEngine;

//Simon Voss
//Moves this bullet towards its target each frame, destroys the bullet if target dies

public class NerfBulletTrajectory : MonoBehaviour
{

    [SerializeField] internal float bulletSpeed = 1f;
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
        collision.gameObject.GetComponent<EnemyStats>().RemoveHP(damage);
        Destroy(gameObject);
    }
}
