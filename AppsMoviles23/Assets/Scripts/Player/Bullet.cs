using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
public GameObject splashEndPrefab, smallBulletPrefab;
    private Rigidbody2D _rigidbody;
  	private bool _isTouching;

	
    public LayerMask groundLayer;
	public float groundCheckRadius;
	public float speed = 2f;
	public Vector2 direction;
	public float livingTime = 3f;
	public Color initialColor = Color.white;
	public Color finalColor;
	public int damage = 10;

	private SpriteRenderer _renderer;
	private float _startingTime;


	void Awake()
	{
		_renderer = GetComponent<SpriteRenderer>();
        _rigidbody = GetComponent<Rigidbody2D>();
	}

	void Start()
    {
		//Health health = GetComponent<Health>();
		_startingTime = Time.time;
		Invoke ("DestroyBullet",1.5f);	
		
		
    }

    void Update()
    {
		Vector2 movement = Vector2.up * speed * Time.deltaTime;
		transform.Translate(movement);
		
		_isTouching = Physics2D.OverlapCircle(transform.position, groundCheckRadius, groundLayer);
		if (_isTouching == true){
			DestroyBullet();
		}
        
		// Change bullet's color over time
		/*float _timeSinceStarted = Time.time - _startingTime;
		float _percentageCompleted = _timeSinceStarted / livingTime;

		_renderer.color = Color.Lerp(initialColor, finalColor, _percentageCompleted);*/
		
    }

	void OnCollisionEnter2D(Collision2D collision)
    {
        EnemyDefault enemy = collision.gameObject.GetComponent<EnemyDefault>();

        if (enemy != null)
        {
            enemy.TakeDamage(damage);
			DestroyBullet();
        }

       
    }
	void DestroyBullet(){
		Destroy(this.gameObject);
	}
	
}