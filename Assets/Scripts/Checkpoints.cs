using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoints : MonoBehaviour
{
    public Transform[] checkPoints;

    void Awake()
    {
        checkPoints = new Transform[transform.childCount]; 
        int i = 0;
        while (i < checkPoints.Length) 
        {
            checkPoints[i] = transform.GetChild(i);
            i++;
        }
    }
}
