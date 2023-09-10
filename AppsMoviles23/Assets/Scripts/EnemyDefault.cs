using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDefault : MonoBehaviour
{
    public GameObject[] objectsToSpawn;
    public float moveSpeed;

    public int currentHealth = 100;

    public float weightOfNothing = 10f, luckFactor = 1;


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

    // Calcula el peso total
    foreach (GameObject obj in objectsToSpawn)
    {
        Coin weightedObject = obj.GetComponent<Coin>();
        if (weightedObject != null)
        {
            totalWeight += weightedObject.weight;
        }
    }

    totalWeight += weightOfNothing; // Agregar el peso de la opción "nada"

    float randomValue = Random.Range(0f, totalWeight);

    // Verificar si se selecciona la opción "nada"
    if (randomValue <= weightOfNothing)
    {
        // No hagas nada, simplemente destruye este objeto
        Destroy(this.gameObject);
        return; // Salir de la función para evitar la instanciación de objetos
    }

    foreach (GameObject obj in objectsToSpawn)
    {
        Coin weightedObject = obj.GetComponent<Coin>();
        if (weightedObject != null)
        {
            // Afecta las probabilidades utilizando el "luck factor"
            float adjustedWeight = weightedObject.weight * (1f - luckFactor);

            if (randomValue <= (adjustedWeight + weightOfNothing))
            {
                // Clonar el objeto
                Instantiate(obj, transform.position, Quaternion.identity);
                break;
            }

            randomValue -= (adjustedWeight + weightOfNothing);
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
