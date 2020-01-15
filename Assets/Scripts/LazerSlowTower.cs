using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LazerSlowTower : TurretActions
{
    [SerializeField] LineRenderer linerenderer;
    [SerializeField] float damageOT;
    [SerializeField] float slowDown;
    [SerializeField]ParticleSystem enemyHitEffect;

    internal override void Update()
    {
        if (!LockOnTarget() && !hasTarget)
        {
            linerenderer.enabled = false;
            enemyHitEffect.Stop();
        }

        Shoot();
    }
    internal override void Shoot()
    {

        if (!linerenderer.enabled && hasTarget)
        {
            linerenderer.enabled = true;
            enemyHitEffect.Play();
        }

        target.GetComponent<EnemyStats>().RemoveHP(damageOT * Time.deltaTime);
        target.GetComponent<EnemyMovement>().Slow(slowDown);
        linerenderer.SetPosition(0, bulletSpawnposition.position);
        linerenderer.SetPosition(1, target.transform.position);
        Vector3 dir = bulletSpawnposition.position - target.transform.position;
        enemyHitEffect.transform.position = target.transform.position + dir.normalized * .5f;
        enemyHitEffect.transform.rotation = Quaternion.LookRotation(dir);

    }
}
