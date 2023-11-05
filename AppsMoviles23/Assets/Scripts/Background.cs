using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Background : MonoBehaviour
{
    public float scrollSpeed, speed;
    private float offset;
    private Material material;
    private float distance = 0.0f, _time=1, _timer=1;
    public float difficulty = 0; 

    void Start()
    {
        material = GetComponent<Renderer>().material;
    }
    void Update()
    {
        offset+= Time.deltaTime * (scrollSpeed+difficulty)/10f;
        distance += speed * Time.deltaTime;
        int distanceInt = Mathf.RoundToInt(distance);
        material.SetTextureOffset("_MainTex", new Vector2(0,offset));
        if(Time.time > _time && difficulty<20){
            difficulty+=0.01f;
            _time = Time.time + _timer;
            Debug.Log(difficulty);
        }
    }
}
