using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed, alignmentThreshold = 0.1f;

    private Rigidbody2D rb;
    private Vector3 playerPosition;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerPosition = transform.position;
    }

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            // Definir un umbral pequeño para considerar que están alineados
           

            // Comparar las posiciones en el eje X con el umbral
            if (Mathf.Abs(mousePosition.x - playerPosition.x) < alignmentThreshold)
            {
                // El mouse está lo suficientemente cerca del jugador en el eje X
                rb.velocity = Vector2.zero;
            }
            else if (mousePosition.x < playerPosition.x)
            {
                // El mouse está a la izquierda del jugador
                rb.velocity = new Vector2(-1 * moveSpeed, 0);
            }
            else if (mousePosition.x > playerPosition.x)
            {
                // El mouse está a la derecha del jugador
                rb.velocity = new Vector2(1 * moveSpeed, 0);
            }

            playerPosition = transform.position; // Actualizar la posición del jugador
        }
        else   
            rb.velocity = Vector2.zero;
    }
}