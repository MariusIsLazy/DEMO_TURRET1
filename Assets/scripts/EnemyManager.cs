using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using TMPro;

public class EnemyManager : MonoBehaviour
{    
    public static EnemyManager instance;

    // tell enemy obj what turret is
    [SerializeField] GameObject turretBase;

    // create list
    public static List <GameObject> enemies;
    public GameObject[] enemyShow;

    public int enemyAmount;

    [Header("for money counter")]
    public float moneyAmount = 0;
    public TextMeshProUGUI moneyCounterTXT;

    public List<GameObject> GetEnemyTargets()
    {
        return enemies;
    }

    private void Start()
    {
       instance = this;
       enemies = new List<GameObject>();
    }

    public void Update()
    {
        enemyShow = enemies.ToArray();
        if (enemies.Count <= 0) StartCoroutine(instantiateEnemy());
    }

    public GameObject enemyPrefab;

    public IEnumerator instantiateEnemy()
    { 
        for (int i = 0; i < enemyAmount; i++)
        {
            GameObject enemy = Instantiate(enemyPrefab, new Vector3(Random.Range(50, -50), 1, Random.Range(50, -50)), Quaternion.identity);
            enemy.GetComponent<enemyScript>().EM = this;
            enemies.Add(enemy);
            yield return new WaitForSeconds(1f);
        }   
    }

    public void AddMoney()
    { 
        Debug.Log("money add");
        moneyAmount++;
        moneyCounterTXT.text = "$: " + moneyAmount.ToString();
    }
}