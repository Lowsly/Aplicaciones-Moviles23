using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CountdownScript : MonoBehaviour
{
     public TextMeshProUGUI countdownText;
    public float countdownTime = 3.0f;
    public string scene;

    private void Start()
    {
        StartCoroutine(StartCountdown());
    }

    private bool shouldStartCountdown = false;

    public void StartCountdownOnClick()
{
    shouldStartCountdown = true;
    StartCoroutine(StartCountdown());
}

    public IEnumerator StartCountdown()
    {
        if (!shouldStartCountdown)
    {
        yield break; // No ejecutar el contador si no se debe iniciar.
    }
    float currentTime = countdownTime;

        while (currentTime > 0)
        {
            countdownText.text = currentTime.ToString("0");
            Debug.Log("Countdown: " + currentTime); // Agrega esta línea para rastrear el valor de currentTime
            yield return new WaitForSeconds(1.0f);
            currentTime--;
        }

        countdownText.text = "¡YA!";
        yield return new WaitForSeconds(1.0f);

        Debug.Log("Iniciando el juego o la escena del juego"); // Agrega esta línea para rastrear cuando se inicia la escena

        // Iniciar el juego o la escena del juego aquí
        StartGame();
    }

    public void StartGame()
    {
        Debug.Log("Cargando la escena: " + scene); // Agrega esta línea para rastrear la escena que se carga
        SceneManager.LoadScene(scene);
    }
}