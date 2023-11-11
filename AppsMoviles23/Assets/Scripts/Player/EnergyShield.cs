using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyShield : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        CrabMove crab = collision.gameObject.GetComponent<CrabMove>();
       Vector2 direccionImpacto = (collision.GetContact(0).point - (Vector2)transform.position).normalized;
        crab.Away(direccionImpacto);
        
    }
}
