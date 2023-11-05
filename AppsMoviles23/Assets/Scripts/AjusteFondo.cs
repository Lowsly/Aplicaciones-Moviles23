using UnityEngine;

public class AjusteFondo : MonoBehaviour
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
            
            fondo.transform.localScale = new Vector3(escala*6f, escala*15f, 1.0f);
        /*if (relacionDeAspectoPantalla >= 0.405 && relacionDeAspectoPantalla < 0.5f)
        {
            // La pantalla es más ancha que el fondo
            escala = relacionDeAspectoPantalla / 0.5f;
            
            fondo.transform.localScale = new Vector3(escala*6f, escala*15f, 1.0f);
        }

        if (relacionDeAspectoPantalla < 0.405f)
        {
            // La pantalla es más ancha que el fondo
            escala = (Screen.height/(relacionDeAspectoPantalla*1000)) * 0.6f;
            
            fondo.transform.localScale = new Vector3(5, 12.5f, 1.0f);
        }

         if (relacionDeAspectoPantalla > 0.5f)
        {
            fondo.transform.localScale = new Vector3(6, 15, 1.0f);
        }*/
    }
}