using UnityEngine;
using System.Collections.Generic;


public class EnemyManager : MonoBehaviour
{    
    public static EnemyManager instance;

    // tell enemy obj what turret is
    [SerializeField] GameObject turretBase;

    // create array
    public static List <GameObject> enemies;
    public GameObject[] enemyShow;
    public List<GameObject> GetEnemyTargets()
    {
        return enemies;
    }

    private void Start()
    {
        instance = this;
        enemies = new List<GameObject>();
        instantiateEnemy();
    }
    public void Update()
    {
        enemyShow = enemies.ToArray();
    }

    public GameObject enemyPrefab;

    public float timer = 0.5f;
    
    public void instantiateEnemy()
    {
        for (int i = 0; i < 10;)
        {
            timer -= Time.deltaTime;
            if (timer < 0)
            {
                GameObject enemy = Instantiate(enemyPrefab, new Vector3(Random.Range(50, -50), 1, Random.Range(50, -50)), Quaternion.identity);
                enemies.Add(enemy);
                i++;

                timer = .5f;
            }
        }
    }
}