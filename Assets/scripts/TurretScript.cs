using UnityEngine;
using System.Collections.Generic;

public class TurretScript : MonoBehaviour
{
    //public GameObject[] enemyList;
    
    public List<GameObject> enemyList;
    public GameObject myGun;
    public GameObject bulletPrefab;
    public GameObject spawnPoint;

    float timer = 0.5f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        enemyList = EnemyManager.enemies;
        
        if (enemyList.Count > 0) myGun.transform.LookAt(enemyList[0].transform.position);

        timer -= Time.deltaTime;
        if (timer < 0)
        {
            Sort(enemyList);
            
            // shoot
            Shoot();

            // reset timer
            timer = 0.5f;
        }
    }

    void Shoot()
    {
        Instantiate(bulletPrefab, spawnPoint.transform.position, spawnPoint.transform.rotation);
        
    }

    void Sort(List<GameObject> list)
    {
        for (int i = 0; i < enemyList.Count; i++)
        {
            //Debug.Log("name of the first enemy is " + enemyList[i].transform.name);

            for (int j = 0; j < enemyList.Count - i - 1; j++)
            {
                // Compare at index i to j
                float firstObjectDistance = Vector3.Distance(enemyList[i].transform.position, transform.position);
                float secondObjectDistance = Vector3.Distance(enemyList[j + 1].transform.position, transform.position);

                //Debug.Log("distance between first ad second is " + firstObjectDistance + ", " + secondObjectDistance);

                if (secondObjectDistance < firstObjectDistance)
                {
                    GameObject tempGO = enemyList[j];
                    enemyList[j] = enemyList[j + 1];
                    enemyList[j + 1] = tempGO;
                }
            }
        }
    }
}
