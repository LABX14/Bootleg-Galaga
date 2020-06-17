using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public int score;
    public float spawnDistance; // How far away we can spawn something in
    public GameObject player;
    public List<GameObject> enemyList;
    public List<GameObject> enemyPrefabList;
    public List<Transform> spawnPointList;
    

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            enemyList = new List<GameObject>();
        }
        else
        {
            Destroy(this.gameObject);
            Debug.LogWarning("[GameManager] Attempted to create a second game manager. " + this.gameObject.name);
        }
    }

    private void SpawnEnemy()
    {
        // Pick a random point to spawn 

        // Pick a random spawn point to spawn at.

        Transform spawnPoint = spawnPointList[Random.Range(0, spawnPointList.Count)];

        // Pick a point within distance of spawn point to spawn at.
        Vector3 randomVector = Random.insideUnitCircle;
        Vector3 newPosition = spawnPoint.position + (randomVector * spawnDistance);

        // Instantiate the seleced enemy at the selected position.
    }
}
