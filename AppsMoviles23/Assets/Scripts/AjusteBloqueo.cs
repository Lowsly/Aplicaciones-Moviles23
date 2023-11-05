using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AjusteBloqueo : MonoBehaviour
{
    public GameObject fondo; // Asigna el GameObject del fondo desde el Inspector

    private void Start()
    {
        AjustarFondo();
    }

    private void AjustarFondo()
    {
        // Calcula la relación de aspecto de la pantalla (ancho / alto)
        float relacionDeAspectoPantalla = (float)Screen.width / Screen.height;

        
        float escala = relacionDeAspectoPantalla / 0.5f;
            
            fondo.transform.localScale = new Vector3(escala*6f, escala*0.9f, 1.0f);
    }
}
