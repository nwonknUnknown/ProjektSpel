using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveBulletOutOfTrigger : MonoBehaviour
{
    

    void OnTriggerExit(Collider other)//for range
    {
        if (other.GetComponent<NerfBulletTrajectory>())
        {
            Destroy(other.gameObject);
        }
    }
}
