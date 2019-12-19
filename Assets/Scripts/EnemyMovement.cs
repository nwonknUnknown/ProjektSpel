using System.Collections;
using UnityEngine;

//Simon Voss, Alexander Kourie, Rasmus Tukia
//Constantly moves the enemy in it's forward direction, also enables the rotation of the enemy from input from "Change Enemy Directions" -script

public enum Rotation { Continue, Right, Left }


public class EnemyMovement : MonoBehaviour
{
    public float startMovementspeed;//AND THIS
    [HideInInspector] public float movementspeed;//AND THIS

    public Rotation currentRotating = Rotation.Continue;
    float startingRotation;
    float totalRotation = 0;
    bool startingToRotate = true;

    private void Start()// FOR THE SLOWMENT
    {
        movementspeed = startMovementspeed;
    }

    void FixedUpdate()
    {
        transform.Translate(0, 0, movementspeed / 100);

        if (currentRotating == Rotation.Left)
        {
            if (startingToRotate)
            {
                startingRotation = totalRotation;
                startingToRotate = false;
            }
            transform.Rotate(0, -movementspeed, 0);
            totalRotation -= movementspeed;
            if (totalRotation <= startingRotation - 90)
            {
                transform.Rotate(0, (totalRotation + startingRotation + 90), 0);
                totalRotation = 0;
                startingRotation = 0;
                startingToRotate = true;
                currentRotating = Rotation.Continue;
            }
        }
        else if (currentRotating == Rotation.Right)
        {
            if (startingToRotate)
            {
                startingRotation = totalRotation;
                startingToRotate = false;
            }
            transform.Rotate(0, movementspeed, 0);
            totalRotation += movementspeed;
            if (totalRotation >= startingRotation + 90)
            {
                transform.Rotate(0, -(totalRotation - startingRotation - 90), 0);
                totalRotation = 0;
                startingRotation = 0;
                startingToRotate = true;
                currentRotating = Rotation.Continue;
            }
        }
        else
        {
            currentRotating = Rotation.Continue;
        }

        movementspeed = startMovementspeed;// TO REGAIN SPEEEED
    }
    public void Slow(float amount)//SLOOOOOOOOOOOOW
    {
        movementspeed = startMovementspeed / (1f + amount);
    }
}
