using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Background : MonoBehaviour
{

    [Range(-10f,10f)]
    public float scrollSpeed;
    private float offset;
    private Material material;
    private float distance = 0.0f;
    void Start()
    {
        material = GetComponent<Renderer>().material;
    }
    void Update()
    {
        offset+= Time.deltaTime * scrollSpeed/10f;
        distance += scrollSpeed * Time.deltaTime;
         int distanceInt = Mathf.RoundToInt(distance);
        material.SetTextureOffset("_MainTex", new Vector2(0,offset));
    }
}
