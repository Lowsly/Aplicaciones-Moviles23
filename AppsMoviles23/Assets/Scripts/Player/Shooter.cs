using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    // Start is called before the first frame update
    public float _cdShoot = 0.1f,_shootDelay =0.15f;

    public GameObject[] bulletPrefab,blips;

    public Transform[] firepoints;

    private float _angles, currentAngle, angleStep;

    public int _bullets = 1, power = 1;

    void Awake()
    {
        power = PlayerPrefs.GetInt("power", 1);
        if(power >=1 && power <=15)
        {
            _bullets = power;
        }
        if(power >=16 && power <=20)
        {
            _bullets = power - 4;
        }
    }
    void Update()
    {
        angleStep = 90f / (_bullets - 1); 
		if(_bullets == 2){
			currentAngle = -5;
			angleStep = 10; 
		}
		if(_bullets == 1){
			currentAngle = 0;
		}
		if(_bullets > 2){
			currentAngle = -45;
			angleStep = 90f / (_bullets - 1); 
		}
        
    }

    public void Shoot()
    {
        _bullets = power;
        if(power >=1 && power <=4){
            for (int i = 0; i < _bullets; i++)
            {
                var firedBullet = Instantiate(bulletPrefab[0], firepoints[2].position, Quaternion.Euler(0, 0, currentAngle));
                currentAngle += angleStep;
            }
        }
        if (power >= 5 && power <= 10)
        {
            int bulletsInMiddle = 1 + _bullets/3;
            int bulletsToSide = (_bullets- bulletsInMiddle)/2;
            for (int i = 0; i < bulletsToSide; i++)
            {
                int angle = -25;
                var firedBullet = Instantiate(bulletPrefab[0], firepoints[2].position, Quaternion.Euler(0, 0, angle+i*4));
                angle += 7;
            }
                for (int i = 0; i < bulletsInMiddle; i++)
                {
                    float xOffset = (i - (bulletsInMiddle - 1) / 2) * 0.15f;
                    var firedBullet = Instantiate(bulletPrefab[0], firepoints[2].position + new Vector3(xOffset, 0, 0), Quaternion.identity);
                }
            for (int i = 0; i < bulletsToSide; i++)
            {
                float angle = 25;
                var firedBullet = Instantiate(bulletPrefab[0], firepoints[2].position, Quaternion.Euler(0, 0, angle-i*4));
                angle -= 7;
            }
        }            
        if (power >= 11 && power <= 15)
        {
            _bullets = power;
            int bulletsToMiddle = 3;
            float spacingX = 0.15f; 

            for (int i = 0; i < bulletsToMiddle; i++)
            {
                float xOffset = (i - (bulletsToMiddle - 1) / 2) * spacingX;
                var bulletPrefabToUse = (i == (bulletsToMiddle - 1) / 2) ? bulletPrefab[1] : bulletPrefab[0];
                var firedBullet = Instantiate(bulletPrefabToUse, firepoints[2].position + new Vector3(xOffset, 0, 0), Quaternion.identity);
            }

            int bulletsToSide = (_bullets - bulletsToMiddle) / 2;

            for (int i = 0; i < bulletsToSide; i++)
            {
                float angle = -15;
                angle -= i * 4; 
                var firedBulletLeft = Instantiate(bulletPrefab[0], firepoints[1].position, Quaternion.Euler(0, 0, angle));
                var firedBulletRight = Instantiate(bulletPrefab[0], firepoints[3].position, Quaternion.Euler(0, 0, -angle));
            }
        }
        if (power >= 16 && power <= 20)
        {
            _bullets = power - 4;

            int bulletsToMiddle = _bullets/4; 
            int bulletsToSide = (_bullets - bulletsToMiddle) / 2;

            float spacingX = 0.15f; 

            for (int i = 0; i < bulletsToMiddle; i++)
            {
                float xOffset = (i - (bulletsToMiddle - 1) / 2) * spacingX;
                var firedBullet = Instantiate(bulletPrefab[1], firepoints[2].position + new Vector3(xOffset, 0, 0), Quaternion.identity);
            }

            for (int i = 0; i < bulletsToSide; i++)
            {
                float angle = -15 - (i * 4);
                var bulletPrefabToUse = (i >= (bulletsToSide - 1) / 2) ? bulletPrefab[1] : bulletPrefab[0];
                    var firedBulletLeft = Instantiate(bulletPrefabToUse, firepoints[1].position, Quaternion.Euler(0, 0, angle));
                    var firedBulletRight = Instantiate(bulletPrefabToUse, firepoints[3].position, Quaternion.Euler(0, 0, -angle));
            }
        }   
    }
    public void Blip()
    {
        if(power >=1 && power <=10)
        {
            blips[0].SetActive(true);
            for (int i = 1; i < 5; i++)
            {
                blips[i].SetActive(false);
            }
        }
        if(power>=11 && power <=20)
        {
            for (int i = 0; i < 3; i++)
            {
                blips[i].SetActive(true);
            }
            for (int i = 3; i < 5; i++)
            {
                blips[i].SetActive(false);
            }
        }
    }
}
