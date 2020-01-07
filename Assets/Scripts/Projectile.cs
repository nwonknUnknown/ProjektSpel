using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public GameObject TargetObject { get; set; }
    public GameObject TurretObject { get; set; }
    public int Damage { get; set; }
    internal virtual void AssignTarget(GameObject towersTarget)
    {
        TargetObject = towersTarget;
    }

    public void AssignTurret(GameObject newTurretObject)
    {
        TurretObject = newTurretObject;
    }
}
