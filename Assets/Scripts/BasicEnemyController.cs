using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemyController : MonoBehaviour {

    public List<Transform> path;
    public float velocity = 0.5f;

    int currentPathPoint;
    Vector3 goalPosition;
    float lookSpeed = 5.0f;

    void Start() {
        currentPathPoint = 0;
        goalPosition = path[currentPathPoint].position;
    }
	
	void Update () {
        transform.position = Vector3.MoveTowards(transform.position, goalPosition, Time.deltaTime * velocity);

        Vector3 targetDir = goalPosition - this.transform.GetChild(0).transform.position;
        float step = lookSpeed * Time.deltaTime;
        Vector3 newDir = Vector3.RotateTowards(this.transform.GetChild(0).transform.forward, targetDir, step, 0.0F);
        this.transform.GetChild(0).transform.rotation = Quaternion.LookRotation(newDir);

        if (Vector3.Distance(this.transform.position, goalPosition) < 0.05f)
        {
            currentPathPoint += 1;
            if (currentPathPoint >= path.Count)
            {
                Destroy(this.gameObject);
            }
            else
            {
                goalPosition = path[currentPathPoint].position;
            }
        }
	}
}
