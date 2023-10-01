using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    // Start is called before the first frame update
    public float _cdShoot = 0.1f,_shootDelay =0.15f;

    public GameObject bulletPrefab;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > _cdShoot){
            _cdShoot = _shootDelay + Time.time;
            var fired = Instantiate(bulletPrefab, transform.position, Quaternion.identity);

        }
    }
}
