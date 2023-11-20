using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Background : MonoBehaviour
{
    public float scrollSpeed, speed;
    private float offset;
    private Material material;
    private float distance = 0.0f, _time=1, _timer=1, speed2 = 1, GameOver=0;
    public float difficulty = 0; 
    public Player player;

    public GameObject GameOverScreen, Spawn;

    void Start()
    {
        material = GetComponent<Renderer>().material;
    }
    void Update()
    {
         if(player.dead)
        {
            Spawn.SetActive(false);
            speed2+=Time.deltaTime*4.5f;
            offset+= Time.deltaTime * (scrollSpeed+difficulty)/(10*speed2);
            distance+= speed/2 * Time.deltaTime;  
            GameOver+=Time.deltaTime;
            if(GameOver>1.82f)
                GameOverScreen.SetActive(true);

        }
        if(player._stunned)
        {
            offset+= Time.deltaTime * (scrollSpeed+difficulty)/20f;
            distance+= speed/2 * Time.deltaTime;    
        }
        else if(!player.dead)
        {
            offset+= Time.deltaTime * (scrollSpeed+difficulty)/10f;
            distance+= speed * Time.deltaTime;
        }

        int distanceInt = Mathf.RoundToInt(distance);
        material.SetTextureOffset("_MainTex", new Vector2(0,offset));
        if(Time.time > _time && difficulty<20){
            difficulty+=0.01f;
            _time = Time.time + _timer;
            //Debug.Log(difficulty);
        }
    }
}
