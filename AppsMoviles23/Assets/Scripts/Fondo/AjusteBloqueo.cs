using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AjusteBloqueo : MonoBehaviour
{
    public GameObject bloque, fondo; 


    private void Start()
    {
        AjustarFondo();
    }

    private void AjustarFondo()
    {
        bloque.transform.position = new Vector2(0, -fondo.transform.localScale.y/2*0.8f);
        float relacionDeAspectoPantalla = (float)Screen.width / Screen.height;

        
        float escala = relacionDeAspectoPantalla / 0.5f;
            
            bloque.transform.localScale = new Vector3(escala*6.07f, escala*2f, 1.0f);
    }
}
