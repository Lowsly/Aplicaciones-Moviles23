using System.Collections;
using UnityEngine;
using System;


public class Spawner : MonoBehaviour
{
    public GameObject Crab, background;

    private CrabMove crabMove;
    private float AC = 0.1f;

    private float[] time;

    private float _bh, _bw;
    void Start()
    {
        _bh = background.transform.localScale.y;
        _bw = background.transform.localScale.x;
    }
    void Update()
    {
        if(Time.time>AC)
        {
            System.Random random = new System.Random();
            int randomNumber = random.Next(1, 4);
            int resultado = (randomNumber <= 5) ? 10 : 20;
            AC = 3 + Time.time + resultado;
            if(randomNumber >= 5)
            {
                StartCoroutine(P1(resultado));
            }
            if(randomNumber < 5)
            {
                StartCoroutine(P1(resultado));
                StartCoroutine(S1(resultado));
            }
        }
    }
    public IEnumerator P1(float time)
    {
        float timer = 0.0f;
        float cooldown = UnityEngine.Random.Range(0.5f, 1.2f); 

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
    public IEnumerator S1(float time)
    {
        float timer = 0.0f;
        float cooldown = UnityEngine.Random.Range(0.5f, 1.2f);
        float place = UnityEngine.Random.Range(-_bw/2, _bw/2);

        while (timer < time)
        {
            yield return new WaitForSeconds(cooldown);

            GameObject Crab1 = Instantiate(Crab, new Vector2(place, transform.position.y), Quaternion.identity) as GameObject;
            CrabMove crabMove = Crab1.GetComponent<CrabMove>();
            crabMove.StartCoroutine(crabMove.SupportMove2());
            GameObject Crab2 = Instantiate(Crab, new Vector2(-place, transform.position.y), Quaternion.identity) as GameObject;
            CrabMove crabMove2 = Crab2.GetComponent<CrabMove>();
            crabMove2.StartCoroutine(crabMove2.SupportMove2());

            timer += cooldown;
        }

        // Asegurarse de que timer sea igual a time al final
        if (timer < time)
        {
            yield return new WaitForSeconds(time - timer);
        }
    }
}