using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Player : MonoBehaviour
{
   public float minX = -5f; // Límite mínimo en el eje X
    public float maxX = 5f;  // Límite máximo en el eje X

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3 newPosition = transform.position;
            newPosition.x = Mathf.Clamp(mousePosition.x, minX, maxX); // Aplica límites en el eje X
            transform.position = newPosition;
        }
    }
}
