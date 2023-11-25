using UnityEngine;

public class AjusteFondo : MonoBehaviour
{
    public GameObject fondo; 
    public GameObject[] bloque; // Asigna el GameObject del fondo desde el Inspector

    private void Start()
    {
        AjustarFondo();
    }

    private void AjustarFondo()
    {
        // Calcula la relación de aspecto de la pantalla (ancho / alto)
        float relacionDeAspectoPantalla = (float)Screen.width / Screen.height;

        
        float escala = relacionDeAspectoPantalla / 0.5f;
            
        fondo.transform.localScale = new Vector3(escala*6.07f, escala*15f, 1.0f);

        bloque[0].transform.localScale = new Vector3(escala*6.07f, escala*2.9f, 1.0f);
        bloque[1].transform.localScale = new Vector3(escala*6.07f, escala*4.9f, 1.0f);
        
        //bloque.transform.position = new Vector2(0, -fondo.transform.localScale.y/2);
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