using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Spawner : MonoBehaviour
{
    public GameObject Crab, CrabY;
    private GameObject background;
    private Background _background;
    private Player player;
    private CrabMove crabMove;
    private float AC = 0.1f;
    public GameManager game;

    public Shooter shoot;
    private float[] time;
    private float _bh, _bw;
    public int round;
    void Start()
    {
        background = GameObject.FindGameObjectWithTag("Background");
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        _background = background.GetComponent<Background>();
        _bh = background.transform.localScale.y;
        _bw = background.transform.localScale.x;
        round = PlayerPrefs.GetInt("round", 0);
    }
    void Update()
    {
        if(Time.time>AC && !player.dead)
        {
            game.Save(round, player.currentHealth, player.maxHealth, shoot.power);
            Debug.Log(round);
            int randomNumber = Random.Range(1,4);
            int resultado = (randomNumber <= 5) ? 2 : 2;
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
        float cooldown = Random.Range(0.5f,1.2f);

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
        round++;
    }
    public IEnumerator S1(float time)
    {
        float timer = 0.0f;
        float cooldown = Random.Range(0.5f,1.2f);
        float place = Random.Range(0.4f, _bw/2);

        while (timer < time)
        {
            yield return new WaitForSeconds(cooldown);

            GameObject Crab1 = Instantiate(CrabY, new Vector2(place, transform.position.y), Quaternion.identity) as GameObject;
            CrabMove crabMove = Crab1.GetComponent<CrabMove>();
            crabMove.StartCoroutine(crabMove.SupportMove2());
            GameObject Crab2 = Instantiate(CrabY, new Vector2(-place, transform.position.y), Quaternion.identity) as GameObject;
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