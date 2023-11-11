using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrabMove : MonoBehaviour
{
    private GameObject background;

    private Background _background;
    private GameObject player;
    private Vector2 playerPosition, actualplayerPosition;
    private float _bh, _bw, difficult;

    private Rigidbody2D rb;
    void Start()
    {
        background = GameObject.FindGameObjectWithTag("Background");
        _bh = background.transform.localScale.y;
        _bw = background.transform.localScale.x;
        player = GameObject.FindGameObjectWithTag("Player");
        _background = background.GetComponent<Background>();
        rb = GetComponent<Rigidbody2D>();

        if  (player != null)
        playerPosition = player.transform.position;
       
    }

    void Update()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        difficult = _background.difficulty;
        if  (player != null)
            actualplayerPosition = player.transform.position;
    }

    public void Away(Vector2 direccion)
    {
        StopAllCoroutines();

rb.isKinematic = false;
rb.mass = 0.1f;
rb.constraints = RigidbodyConstraints2D.None;
    float fuerza = 1f;
    rb.AddForce(direccion * fuerza, ForceMode2D.Impulse);
    }


   public IEnumerator Move1()
    {
   
        float time = 2f;
        float timer = time/3;
        while (timer < time)
        {
            transform.position = Vector2.MoveTowards(transform.position, playerPosition, (difficult/2 + 3*time) * Time.deltaTime);
            timer += Time.deltaTime;
            yield return null;
        }
        timer = 0;
        while (timer < time*2)
        {
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(transform.position.x,_bh-_bh*2.2f), (difficult + 2*time) * Time.deltaTime);
            timer += Time.deltaTime;
            yield return null;
        }
    }

    public IEnumerator SupportMove1()
    {
        float time = 2f;
        float timer = 0;
        while (timer < time)
        {
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(transform.position.x,-_bh*3.2f), (difficult*2 + 5*time) * Time.deltaTime);
            timer += Time.deltaTime;
            yield return null;
        }
    }
    public IEnumerator SupportMove2()
    {
        float time = 2f;
        float timer = 0;
        bool x = false;
        float random = Random.Range(0.05f+difficult/10,0.15f+difficult/10);
        
        while (timer < 8 && x == false)
        {
            timer += Time.deltaTime;
            float randomPos = Random.Range(0,10+difficult);
        Vector2 actualPos = (randomPos<9) ? actualplayerPosition : playerPosition;
                transform.position = Vector2.MoveTowards(transform.position, new Vector2(transform.position.x,-_bh*3.2f), (1.4f*time + difficult/2) * Time.deltaTime);
                x = Mathf.Abs(transform.position.y - actualPos.y) <= random;
                yield return null;
        }
       
        int num = (actualplayerPosition.x-transform.position.x>=0) ? 1 : -1;
        timer = 0;
        while (timer < 8 && x == true)
        {
            timer += Time.deltaTime;
            
                transform.position = Vector2.MoveTowards(transform.position, new Vector2(num*15, transform.position.y), (time + difficult/1.6f) * Time.deltaTime);

            yield return null;
        }
    }

}
