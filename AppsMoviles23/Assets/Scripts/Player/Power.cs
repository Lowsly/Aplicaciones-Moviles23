using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Power : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        Shooter shoot = collision.gameObject.GetComponent<Shooter>();

        if (shoot != null)
        {
            shoot.power+=1;
            shoot.Blip();
			Destroy(this.gameObject);
        }

       
    }
}
