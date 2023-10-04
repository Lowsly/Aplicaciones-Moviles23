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

    void Start()
    {
        
    }

    // Update is called once per frame
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
        if (Time.time > _cdShoot){
            _cdShoot = _shootDelay + Time.time;
            Shoot();

        }
        
    }

    public void Shoot()
    {
        if(power >=1 && power <=10){
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
                int bulletsToLeft = (power - 1) / 2;
                int bulletsToRight = (power - 1) / 2;
                int bulletsInMiddle = (power % 2 == 0) ? 2 : 1;

                // Disparar balas hacia la izquierda
                for (int i = 0; i < bulletsToLeft; i++)
                {
                    float angle = currentAngle * -1;
                    var firedBullet = Instantiate(bulletPrefab[0], firepoints[2].position, Quaternion.Euler(0, 0, angle));
                    angle += angleStep;
                }

                // Disparar balas en el medio
                for (int i = 0; i < bulletsInMiddle; i++)
                {
                    float mid = (i % 3 == 0) ? 0 : 1;
                    var firedBullet = Instantiate(bulletPrefab[0], firepoints[2].position + new Vector3(mid * (-0.05f + i * 0.05f), 0, 0), Quaternion.identity);
                }

                // Disparar balas hacia la derecha
                for (int i = 0; i < bulletsToRight; i++)
                {
                    float angle = currentAngle;
                    var firedBullet = Instantiate(bulletPrefab[0], firepoints[2].position, Quaternion.Euler(0, 0, angle));
                    angle += angleStep;
                }
            }
        }
        if(power>=11 && power <=20){
            _bullets = 1;
            for (int i = 0; i < _bullets; i++)
			{
				var firedBullet = Instantiate(bulletPrefab[0], firepoints[2].position, Quaternion.Euler(0, 0, currentAngle));
				currentAngle += angleStep;
			}
            var firedBullet1 = Instantiate(bulletPrefab[0], firepoints[1].position, Quaternion.identity);
            var firedBullet2 = Instantiate(bulletPrefab[0], firepoints[3].position, Quaternion.identity);
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
