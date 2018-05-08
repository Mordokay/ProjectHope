using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemySpawner : MonoBehaviour {

    [System.Serializable]
    public class EnemySpawnData
    {
        [SerializeField]
        public GameObject enemyPrefab;
        [SerializeField]
        public float spawnTime;
    }

    public List<EnemySpawnData> enemies;
    public Transform enemyHolder;
    public Transform spawnPos;
    public List<Transform> path;
    public GameObject enemyObject;

    void Update () {
        if(Input.touches.Length == 2 || Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(0);
        }
        else if (Input.touches.Length == 1 && (Input.touches[0].phase.Equals(TouchPhase.Began)) || Input.GetKeyDown(KeyCode.Space))
        {
            GameObject myEnemy = Instantiate(enemyObject) as GameObject;
            myEnemy.transform.parent = enemyHolder;
            myEnemy.transform.position = spawnPos.position;
            myEnemy.GetComponent<BasicEnemyController>().path = this.path;
            enemies.RemoveAt(0);
        }
        /*
        if (enemies.Count > 0 && enemies[0].spawnTime < Time.timeSinceLevelLoad)
        {
            GameObject myEnemy = Instantiate(enemies[0].enemyPrefab) as GameObject;
            myEnemy.transform.parent = enemyHolder;
            myEnemy.transform.position = spawnPos.position;
            myEnemy.GetComponent<BasicEnemyController>().path = this.path;
            enemies.RemoveAt(0);
        }*/
	}
}
