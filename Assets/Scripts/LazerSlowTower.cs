using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LazerSlowTower : TurretActions
{
    [SerializeField] LineRenderer linerenderer;
    [SerializeField] float damageOT;
    [SerializeField] float slowDown;
    public ParticleSystem enemyHitEffect;

    internal override void Update()
    {
        if (!HpManager.instance.CheckIfLost())
        {
            if (target == null)
            {

                if (linerenderer.enabled)
                {

                    linerenderer.enabled = false;
                    enemyHitEffect.Stop();
                }
                   
                return;
            }
        }

        if (!LockOnTarget())
        {
            linerenderer.enabled = false;
        }

        Shoot();
    }
    internal override void Shoot()
    {

        target.GetComponent<EnemyStats>().RemoveHP(damageOT * Time.deltaTime);
        target.GetComponent<EnemyMovement>().Slow(slowDown);

        if (!linerenderer.enabled)
        {
            linerenderer.enabled = true;
            enemyHitEffect.Play();
        }
            

        linerenderer.SetPosition(0, bulletSpawnposition.position);
        linerenderer.SetPosition(1, target.transform.position);

        Vector3 dir = bulletSpawnposition.position - target.transform.position;

        enemyHitEffect.transform.position = target.transform.position + dir.normalized * .5f;
        
        enemyHitEffect.transform.rotation = Quaternion.LookRotation(dir);

    }
}
