using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject bulletPrefab;
    private Transform _firePoint;
    public float moveSpeed, alignmentThreshold = 0.1f; 

    public int currentHealth = 3;

    private Rigidbody2D rb;
    private Vector3 playerPosition;
    private bool isTouchingScreen = false;

    public float _cdShoot = 1f,_shootDelay =0.15f;

    Transform fire;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerPosition = transform.position;
        _firePoint = transform.Find("firepoint");
        Application.targetFrameRate = 60;
    }

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            isTouchingScreen = true;

            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            // Calcular la dirección del movimiento
            float moveDirection = Mathf.Sign(mousePosition.x - playerPosition.x);

            // Calcular la diferencia entre las posiciones del jugador y el mouse
            float positionDifference = Mathf.Abs(mousePosition.x - playerPosition.x);

            // Aplicar aceleración gradual cuando el mouse está cerca
            float adjustedSpeed = Mathf.Lerp(0f, moveSpeed, positionDifference / alignmentThreshold);

            // Establecer la velocidad
            rb.velocity = new Vector2(adjustedSpeed * moveDirection, 0f);

            playerPosition = transform.position; // Actualizar la posición del jugador
        }
        else
        {
            // Si no se toca la pantalla, detener el movimiento instantáneamente
            if (!isTouchingScreen)
            {
                rb.velocity = Vector2.zero;
            }
            isTouchingScreen = false;
        }
        if (Time.time > _cdShoot){
            _cdShoot = _shootDelay + Time.time;
            var fired = Instantiate(bulletPrefab, _firePoint.position, Quaternion.identity);
        }
		

    }
     public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}