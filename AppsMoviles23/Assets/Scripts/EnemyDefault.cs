using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDefault : MonoBehaviour
{
    public GameObject[] objectsToSpawn;
    public float moveSpeed;

    public int currentHealth = 100;


    void Start()
    {
        Invoke("Destroytotal",4.5f);
    }

    void Update()
    {
        Vector3 movement = Vector3.down * moveSpeed * Time.deltaTime;
        transform.Translate(movement);
    }
   
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            Destroy();
        }
    }
    void Destroy()
    {
        int randomValue = Random.Range(0, objectsToSpawn.Length);
        if (randomValue >= 0 && randomValue < objectsToSpawn.Length)
        {
            Instantiate(objectsToSpawn[randomValue], transform.position, Quaternion.identity);
        }
        Destroy(this.gameObject);
    }

    void Destroytotal()
    {
        Destroy(this.gameObject);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Player player = collision.gameObject.GetComponent<Player>();
        if (player != null)
        {
            player.TakeDamage(1);
            Destroy(this.gameObject);
        }
    }
    
}
