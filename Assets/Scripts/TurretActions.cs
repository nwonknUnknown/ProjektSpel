using UnityEngine;

//Simon Voss, Alexander Kourie
//Handles all actions of the turret, including: Targeting, Asking for ammo, Shooting bullets, deciding the bullets damage, and updating text of refill-cost of this turrets UI-panels

public class TurretActions : MonoBehaviour
{
    private GameObject target;

    [SerializeField] private Transform bulletSpawnposition;
    [SerializeField] private Transform bulletSpawnrotation;
    [SerializeField] public NerfBulletTrajectory bullet;

    [SerializeField] private float timeBetweenShots = 1f;
    public int startAmmo = 10;
    public int bulletCost = 0;
    [SerializeField] private int turretDamage = 1;
    public int turretCost;

    //LaserStuff
    public bool isLaseron = false;
    public LineRenderer linerenderer;
    public float damageOT;
    public float slowDown;

    [SerializeField] private float turnspeed = 10f;

    public int currentAmmo;

    private int targetsInTrigger;
    private bool hasTarget = false;

    private float time = 0;

    public void Start()
    {
        currentAmmo = startAmmo;
        transform.parent.Find("TurretUI").gameObject.SetActive(true);
        transform.parent.Find("TurretUI").Find("Choices").Find("CurrentAmmo").GetComponentInChildren<UpdateMyText>().UpdateMyTextAsInt(currentAmmo);
        transform.parent.Find("TurretUI").Find("Choices").Find("RefillAmmo").GetComponentInChildren<UpdateMyText>().UpdateRefillCostAsInt((startAmmo - currentAmmo) * bulletCost);
        transform.parent.Find("TurretUI").gameObject.SetActive(false);
    }



    void Update()
    {
        if (!HpManager.instance.CheckIfLost())
        {
            if (target == null)
            {
                if (isLaseron)
                {
                    if (linerenderer.enabled)
                        linerenderer.enabled = false;
                }
                return;
            }
        }

        LockOnTarget();

        if (isLaseron)//LASERSTUFF
        {
            SlowLaserStuff();
        }
        else
        {
            Shoot();
        }
    }

    void LockOnTarget()
    {
        if (hasTarget && currentAmmo > 0 && target.GetComponent<EnemyStats>().hp > 0)
        {
            Vector3 dir = target.transform.position - transform.position;
            Quaternion lookRotation = Quaternion.LookRotation(dir);
            Vector3 rotation = Quaternion.Lerp(transform.rotation, lookRotation, Time.deltaTime * turnspeed).eulerAngles;
            transform.rotation = Quaternion.Euler(0, rotation.y, 0);

        }
        else if (currentAmmo <= 0)
        {
            RequestAmmo();
        }
    }


    void OnTriggerExit(Collider other)
    {
        if (other.gameObject == target)
        {
            hasTarget = false;
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (!hasTarget)
        {
            target = other.gameObject;
            hasTarget = true;
        }
    }

    void Shoot()
    {
        time += Time.deltaTime;
        if (time >= timeBetweenShots)
        {
            GetComponentInChildren<PlayMyAnimation>().PlayShoot();
            GetComponent<Soundcontroller>().PlaySound();
            NerfBulletTrajectory thisBullet = Instantiate(bullet, bulletSpawnposition.position, bulletSpawnrotation.rotation);
            thisBullet.AssignTarget(target);
            thisBullet.AssignTurret(gameObject);
            thisBullet.damage = turretDamage;
            currentAmmo--;
            if (transform.parent.Find("TurretUI").gameObject.activeSelf)
            {
                transform.parent.Find("TurretUI").Find("Choices").Find("CurrentAmmo").GetComponentInChildren<UpdateMyText>().UpdateMyTextAsInt(currentAmmo);
                transform.parent.Find("TurretUI").Find("Choices").Find("RefillAmmo").GetComponentInChildren<UpdateMyText>().UpdateRefillCostAsInt((startAmmo - currentAmmo) * bulletCost);
            }
            else
            {
                transform.parent.Find("TurretUI").gameObject.SetActive(true);
                transform.parent.Find("TurretUI").Find("Choices").Find("CurrentAmmo").GetComponentInChildren<UpdateMyText>().UpdateMyTextAsInt(currentAmmo);
                transform.parent.Find("TurretUI").Find("Choices").Find("RefillAmmo").GetComponentInChildren<UpdateMyText>().UpdateRefillCostAsInt((startAmmo - currentAmmo) * bulletCost);
                transform.parent.Find("TurretUI").gameObject.SetActive(false);
            }

            time -= timeBetweenShots;

        }
    }

    void SlowLaserStuff()
    {
        target.GetComponent<EnemyStats>().RemoveHP(damageOT * Time.deltaTime);
        target.GetComponent<EnemyMovement>().Slow(slowDown);


        if (!linerenderer.enabled)
            linerenderer.enabled = true;

        linerenderer.SetPosition(0, bulletSpawnposition.position);
        linerenderer.SetPosition(1, target.transform.position);
    }

    void RequestAmmo()
    {
        transform.parent.Find("NoAmmoUI").gameObject.SetActive(true);
        transform.parent.Find("TurretUI").gameObject.SetActive(false);
        transform.parent.Find("NoAmmoUI").GetComponentInChildren<UpdateMyText>().UpdateRefillCostAsInt((startAmmo - currentAmmo) * bulletCost);
    }

    public string GetTurretStats()
    {
        string allstats;

        allstats = "\n" + "Damage: " + turretDamage.ToString();
        allstats += "\n" + "Firerate: " + (1 / timeBetweenShots).ToString() + " shot(s)/s";
        allstats += "\n" + "Cost: " + turretCost.ToString() + " Gold";
        allstats += "\n" + "Ammo: " + startAmmo.ToString();
        allstats += "\n" + "Refill cost/bullet: " + bulletCost;
        return allstats;
    }
}
