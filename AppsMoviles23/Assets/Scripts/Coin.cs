using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public int value;
    
    void Start()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.AddForce(Vector2.up * 5, ForceMode2D.Impulse);
        Invoke ("DestroyThis",5.5f);	
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Player player = collision.gameObject.GetComponent<Player>();
        if (player != null)
        {
            player.Money(value);
            Destroy(this.gameObject);
        }
    }
    void DestroyThis(){
		Destroy(this.gameObject);
	}
}
