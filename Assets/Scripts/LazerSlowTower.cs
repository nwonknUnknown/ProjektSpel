using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LazerSlowTower : TurretActions
{
    [SerializeField] LineRenderer linerenderer;
    [SerializeField] float damageOT;
    [SerializeField] float slowDown;

    internal override void Update()
    {
        if (!HpManager.instance.CheckIfLost())
        {
            if (target == null)
            {

                if (linerenderer.enabled)
                    linerenderer.enabled = false;
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
            linerenderer.enabled = true;

        linerenderer.SetPosition(0, bulletSpawnposition.position);
        linerenderer.SetPosition(1, target.transform.position);
    }
}
