using UnityEngine;

public class enemyScript : MonoBehaviour
{
    public EnemyManager EM;
    
    float Health = 5;

    private void Update()
    {
        moveEnemy();
    }

    public void moveEnemy()
    {
        transform.position = Vector3.MoveTowards(transform.position, Vector3.up, 1 * Time.deltaTime);
    }

    public void OnTriggerEnter(Collider otherOBj)
    {
        Health = Health - otherOBj.gameObject.GetComponent<BulletScript>().damage;
        if (Health <= 0)
        {
            //Debug.Log(Health);
            Destroy(gameObject);
            EnemyManager.enemies.Remove(gameObject);
            EM.AddMoney();
        }
    }
}
