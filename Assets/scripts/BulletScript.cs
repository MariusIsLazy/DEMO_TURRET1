using UnityEngine;

public class BulletScript : MonoBehaviour
{
    float timer = 4.0f;
    public float speed;
    public float damage;

    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
        delBullets();
    }

    public void delBullets()
    {
        timer -= Time.deltaTime;
        if (timer < 0)
        {
            Destroy(gameObject);
        }
    }
    public void OnTriggerEnter(Collider otherOBJ)
    {
        //Debug.Log("Collision");
        if (otherOBJ.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }
    }
}
