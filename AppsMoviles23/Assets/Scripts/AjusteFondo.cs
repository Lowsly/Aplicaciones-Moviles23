using UnityEngine;

public class AjusteFondo : MonoBehaviour
{

    private void Start()
    {
        AjustarFondo();
    }

    private void AjustarFondo()
    {
       float relacionDeAspectoPantalla = (float)Screen.width / Screen.height;

        // Calcula la relación de aspecto del fondo
        float relacionDeAspectoFondo = 6.0f / 15.0f; // Ajusta esto a la relación de aspecto de tu fondo

        // Calcula la escala en función de la relación de aspecto de la pantalla
        float escala = 1.0f;
        if (relacionDeAspectoPantalla > relacionDeAspectoFondo)
        {
            // La pantalla es más ancha que el fondo
            escala = relacionDeAspectoPantalla / relacionDeAspectoFondo;
        }

        // Aplica la escala al fondo
        this.transform.localScale = new Vector3(escala*5, escala*12.5f, 1.0f);
    }
}