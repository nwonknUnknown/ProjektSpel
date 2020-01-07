using UnityEngine;

//Simon Voss, Alexander Kourie
//Handles all actions of the turret, including: Targeting, Asking for ammo, Shooting bullets, deciding the bullets damage, and updating text of refill-cost of this turrets UI-panels

public class TurretActions : MonoBehaviour
{
    internal GameObject target;

    [SerializeField] internal Transform bulletSpawnposition;
    [SerializeField] internal Transform bulletSpawnrotation;
    [SerializeField] public Projectile bullet;

    [SerializeField] private float timeBetweenShots = 1f;
    [SerializeField] private int turretDamage = 1;
    [SerializeField] private float turnspeed = 10f;
    private float time = 0;

    public int startAmmo = 10;
    public int currentAmmo;
    public int bulletCost = 0;
    public int turretCost;

    private int targetsInTrigger;// UNUSED BOOL?
    private bool hasTarget = false;

    public void Start()
    {
        currentAmmo = startAmmo;
        transform.parent.Find("TurretUI").gameObject.SetActive(true);
        transform.parent.Find("TurretUI").Find("Choices").Find("CurrentAmmo").GetComponentInChildren<UpdateMyText>().UpdateMyTextAsInt(currentAmmo);
        transform.parent.Find("TurretUI").Find("Choices").Find("RefillAmmo").GetComponentInChildren<UpdateMyText>().UpdateRefillCostAsInt((startAmmo - currentAmmo) * bulletCost);
        transform.parent.Find("TurretUI").gameObject.SetActive(false);
    }

    internal virtual void Update()
    {
        //if (!HpManager.instance.CheckIfLost())
        //{
            if (target == null)
            {
                return;
            }

            if (hasTarget && currentAmmo > 0 && target.GetComponent<EnemyStats>().hp > 0)
            {
                Vector3 dir = target.transform.position - transform.position;
                Quaternion lookRotation = Quaternion.LookRotation(dir);
                Vector3 rotation = Quaternion.Lerp(transform.rotation, lookRotation, Time.deltaTime * turnspeed).eulerAngles;
                transform.rotation = Quaternion.Euler(0, rotation.y, 0);
                Shoot();
            }
            else if (currentAmmo <= 0)
            {
                RequestAmmo();
            }
        //}

        LockOnTarget();

        Shoot();
    }

    internal bool LockOnTarget()
    {
        if (hasTarget && currentAmmo > 0 && target.GetComponent<EnemyStats>().hp > 0)
        {
            Vector3 dir = target.transform.position - transform.position;
            Quaternion lookRotation = Quaternion.LookRotation(dir);
            Vector3 rotation = Quaternion.Lerp(transform.rotation, lookRotation, Time.deltaTime * turnspeed).eulerAngles;
            transform.rotation = Quaternion.Euler(0, rotation.y, 0);
            return true;

        }
        else if (currentAmmo <= 0)
        {
            RequestAmmo();
            return false;
        }
        else
        {
            return false;
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

    virtual internal void Shoot()
    {
        time += Time.deltaTime;
        if (time >= timeBetweenShots)
        {
            GetComponentInChildren<PlayMyAnimation>().PlayShoot();
            GetComponent<Soundcontroller>().PlaySound();
            Projectile thisBullet = Instantiate(bullet, bulletSpawnposition.position, bulletSpawnrotation.rotation);
            thisBullet.AssignTarget(target);
            thisBullet.AssignTurret(gameObject);
            thisBullet.Damage = turretDamage;
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
