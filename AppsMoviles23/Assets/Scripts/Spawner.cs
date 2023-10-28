using System.Collections;
using UnityEngine;
using System;


public class Spawner : MonoBehaviour
{
    public GameObject Crab;

    private CrabMove crabMove;
    private float AC = 0.1f;

    private float[] time;


    void Update()
    {
        if(Time.time>AC)
        {
            System.Random random = new System.Random();
            int randomNumber = random.Next(1, 7);
            int resultado = (randomNumber <= 5) ? 10 : 20;
            AC = 3 + Time.time + resultado;
            StartCoroutine(P1(resultado));
        }
    }
    public IEnumerator P1(float time)
    {
        float timer = 0.0f;
        float cooldown = UnityEngine.Random.Range(0.5f, 1.2f); // Genera un valor aleatorio al principio

        while (timer < time)
        {
            yield return new WaitForSeconds(cooldown);

            GameObject Crab1 = Instantiate(Crab, transform.position, Quaternion.identity) as GameObject;
            CrabMove crabMove = Crab1.GetComponent<CrabMove>();
            crabMove.StartCoroutine(crabMove.Move1());

            timer += cooldown;
        }

        // Asegurarse de que timer sea igual a time al final
        if (timer < time)
        {
            yield return new WaitForSeconds(time - timer);
        }
    }
}