using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDefault : MonoBehaviour
{
    public GameObject[] objectsToSpawn;

    public GameObject explosion;
    public float moveSpeed;

    public int currentHealth = 100;

    public float  luckFactor = 1;

    public float appearanceProbabilityOfNothing = 20f;

    private Animator _animator;

    public CrabMove crabmove;

    void Start()
    {
        Invoke("Destroytotal",10.5f);
        _animator = GetComponent<Animator>();
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
    crabmove.StopAllCoroutines();
    this.gameObject.layer = LayerMask.NameToLayer("Crabless");
    float totalProbability = 0f;

    foreach (GameObject obj in objectsToSpawn)
    {
        Probability prob = obj.GetComponent<Probability>();
        if (prob != null)
        {
            totalProbability += prob.appearanceProbability;
        }
    }
    float randomValue = Random.Range(0f, 100f); 

    // Verificar si se selecciona la opción "nada"
    if (randomValue <= appearanceProbabilityOfNothing)
    {
        _animator.SetTrigger("Death");
        return;
    }

    foreach (GameObject obj in objectsToSpawn)
    {
        Probability prob = obj.GetComponent<Probability>();
        if (prob != null)
        {
            if (randomValue <= prob.appearanceProbability)
            {
                Instantiate(obj, transform.position, Quaternion.identity);
                break;
            }
            randomValue -= prob.appearanceProbability;
        }
    }

    _animator.SetTrigger("Death");
    }
    public void Destroytotal()
    {
        Destroy(this.gameObject);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Player player = collision.gameObject.GetComponent<Player>();
        if (player != null)
        {
            if(!player._immune)
            {
                player.TakeDamage(1);
                player.Immune();
                Instantiate(explosion, transform.position, Quaternion.identity);
            }
            Destroy(this.gameObject);
        }
    }
    
}
