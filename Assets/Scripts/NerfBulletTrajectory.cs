using UnityEngine;

//Simon Voss
//Moves this bullet towards its target each frame, destroys the bullet if target dies

public class NerfBulletTrajectory : MonoBehaviour
{

    [SerializeField] private float bulletSpeed = 1f;
    private GameObject targetObject;
	
    private void Update()
    {
        if (targetObject == null || targetObject.GetComponent<EnemyStats>().hp <= 0)
        {
            Destroy(gameObject);
            return;
        }
        transform.LookAt(targetObject.transform);

        transform.Translate(0, 0, bulletSpeed * Time.deltaTime*100);
    }

    public void AssignTarget(GameObject towersTarget)
    {
        targetObject = towersTarget;
    }

    
}
