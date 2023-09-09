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
    float totalWeight = 0f;

    foreach (GameObject obj in objectsToSpawn)
    {
        Coin weightedObject = obj.GetComponent<Coin>();
        if (weightedObject != null)
        {
            totalWeight += weightedObject.weight;
        }
    }

    float randomValue = Random.Range(0f, totalWeight);

    foreach (GameObject obj in objectsToSpawn)
    {
        Coin weightedObject = obj.GetComponent<Coin>();
        if (weightedObject != null)
        {
            if (randomValue <= weightedObject.weight)
            {
                Instantiate(obj, transform.position, Quaternion.identity);
                break; 
            }

            randomValue -= weightedObject.weight;
        }
        else
        {
            if (randomValue <= 1f)
            {
                Instantiate(obj, transform.position, Quaternion.identity);
                break; 
            }

            randomValue -= 1f;
        }
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
