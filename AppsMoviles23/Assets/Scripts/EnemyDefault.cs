using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDefault : MonoBehaviour
{
    public GameObject[] objectsToSpawn;
    public float moveSpeed;

    public int currentHealth = 100;

    public float  luckFactor = 1;

    public float appearanceProbabilityOfNothing = 20f;


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
    
    float totalProbability = 0f;

    
    foreach (GameObject obj in objectsToSpawn)
    {
        Probability prob = obj.GetComponent<Probability>();
        if (prob != null)
        {
            totalProbability += prob.appearanceProbability;
        }
    }

    float randomValue = Random.Range(0f, 100f); // Usar rango de 0 a 100 para porcentajes

    // Verificar si se selecciona la opción "nada"
    if (randomValue <= appearanceProbabilityOfNothing)
    {
        // No hagas nada, simplemente destruye este objeto
        Destroy(this.gameObject);
        return; // Salir de la función para evitar la instanciación de objetos
    }

    foreach (GameObject obj in objectsToSpawn)
    {
        Probability prob = obj.GetComponent<Probability>();
        if (prob != null)
        {
            // Verificar si el objeto debe aparecer
            if (randomValue <= prob.appearanceProbability)
            {
                // Clonar el objeto
                Instantiate(obj, transform.position, Quaternion.identity);
                break;
            }

            // Restar la probabilidad del objeto actual
            randomValue -= prob.appearanceProbability;
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
