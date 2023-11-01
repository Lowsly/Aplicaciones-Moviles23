using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrabMove : MonoBehaviour
{
    public GameObject background;
    private GameObject player;
    private Vector2 playerPosition;
    private float _bh, _bw;
    void Start()
    {
        _bh = background.transform.localScale.y;
        _bw = background.transform.localScale.x;
        player = GameObject.FindGameObjectWithTag("Player");
        playerPosition = player.transform.position;
    }

   public IEnumerator Move1()
    {
        
        float time = 2f;
        float timer = time/3;
        while (timer < time)
        {
            transform.position = Vector2.MoveTowards(transform.position, playerPosition, 3*time * Time.deltaTime);
            timer += Time.deltaTime;
            yield return null;
        }
        timer = 0;
        while (timer < time)
        {
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(transform.position.x,_bh-_bh*2.2f), 2*time * Time.deltaTime);
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
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(transform.position.x,-_bh*3.2f), 5*time * Time.deltaTime);
            timer += Time.deltaTime;
            yield return null;
        }
    }
    public IEnumerator SupportMove2()
    {
        float time = 2f;
        float timer = 0;
        bool x = false;
        while (timer < time && x == false)
        {
            timer += Time.deltaTime;
            
                transform.position = Vector2.MoveTowards(transform.position, new Vector2(transform.position.x,-_bh*3.2f), 5*time * Time.deltaTime);
                x = (transform.position.y+0.06 >= playerPosition.y && transform.position.y-0.06 <= playerPosition.y) ? true : false;
                yield return null;
        }
        int num = (playerPosition.x-transform.position.x>=0) ? 1 : -1;
        while (timer < time*2 && x == true)
        {
            timer += Time.deltaTime;
            
                transform.position = Vector2.MoveTowards(transform.position, new Vector2(num*15, transform.position.y), 2*time * Time.deltaTime);
            
            
            yield return null;
        }
    }

}
