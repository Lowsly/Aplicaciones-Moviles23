using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrabMove : MonoBehaviour
{
    public GameObject background;

    private float _bh, _bw;
    void Start()
    {
        _bh = background.transform.localScale.y;
        _bw = background.transform.localScale.x;
    }
   public IEnumerator Move1()
    {
        float time = 2f;
        GameObject player = GameObject.FindWithTag("Player");
        float timer = time/3;
        while (timer < time)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, 6 * Time.deltaTime);
            timer += Time.deltaTime;
            yield return null;
        }
        timer = 0;
        while (timer < time)
        {
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(transform.position.x,_bh-_bh*2.2f), 4 * Time.deltaTime);
            timer += Time.deltaTime;
            yield return null;
        }
    }
}
