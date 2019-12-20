using UnityEngine;


public class EnemyMovement : MonoBehaviour
{
    public float startMovementspeed;
    [HideInInspector]public float currentMovementspeed;

    public Checkpoints waypointPath;

    public Transform goal;
    private int wavePointIndex = 0;


    void Start()
    {
        goal = waypointPath.checkPoints[0];
        currentMovementspeed = startMovementspeed;
    }

    void Update()
    {
        Vector3 direction = goal.position - transform.position;
        transform.Translate(direction.normalized * currentMovementspeed * Time.deltaTime, Space.World);
        Quaternion tagetRotation = Quaternion.LookRotation(direction);
        this.transform.rotation = Quaternion.Lerp(this.transform.rotation, tagetRotation, Time.deltaTime * 5);

        if (Vector3.Distance(transform.position, goal.position) <= 0.2f)
        {
            GoToNextCheckpoint();
        }

        currentMovementspeed = startMovementspeed;

    }

    void GoToNextCheckpoint()
    {

        if (wavePointIndex >= waypointPath.checkPoints.Length - 1)
        {
            EndPath();
            return;
        }

        wavePointIndex++;
        goal = waypointPath.checkPoints[wavePointIndex];

    }

    void EndPath()
    {
        Destroy(gameObject);
    }

    public void Slow(float amount)//SLOOOOOOOOOOOOW
    {
        currentMovementspeed = startMovementspeed / (1f + amount);
    }
}

/*using UnityEngine;


public class EnemyMovement : MonoBehaviour
{
    public float movementspeed;

    public Checkpoints waypointPath;

    public Transform goal;
    private int wavePointIndex = 0;


    void Start()
    {
        goal = waypointPath.checkPoints[0];
        movementspeed = GetComponent<EnemyStats>().startEnemySpeed;
    }

    void Update()
    {
        Vector3 direction = goal.position - transform.position;
        transform.Translate(direction.normalized * movementspeed * Time.deltaTime, Space.World);
        Quaternion tagetRotation = Quaternion.LookRotation(direction);
        this.transform.rotation = Quaternion.Lerp(this.transform.rotation, tagetRotation, Time.deltaTime * 5);

        if (Vector3.Distance(transform.position, goal.position) <= 0.2f)
        {
            GoToNextCheckpoint();
        }

    }

    void GoToNextCheckpoint()
    {

        if (wavePointIndex >= waypointPath.checkPoints.Length - 1)
        {
            EndPath();
            return;
        }

        wavePointIndex++;
        goal = waypointPath.checkPoints[wavePointIndex];

    }

    void EndPath()
    {
        Destroy(gameObject);
    }
}*/
