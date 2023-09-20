using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class Player : MonoBehaviour
{
    public GameObject bulletPrefab;
    private Transform _firePoint;
    public float moveSpeed, alignmentThreshold = 0.1f; 

    public int currentHealth = 3;

    private Rigidbody2D rb;
    private Vector3 playerPosition;
    private bool isTouchingScreen = false;

    private float _cdShoot = 0.1f,_shootDelay =0.15f;

    private int _money;

    public TextMeshProUGUI text;
    public AudioSource coinSound;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerPosition = transform.position;
        _firePoint = transform.Find("firepoint");
        Application.targetFrameRate = 60;
        _money = 0;
    }

    private void Update()
    {
        text.text = string.Format("dinero = {0}", _money);
        if (Input.GetMouseButton(0))
        {
            isTouchingScreen = true;

            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            float moveDirection = Mathf.Sign(mousePosition.x - playerPosition.x);

            float positionDifference = Mathf.Abs(mousePosition.x - playerPosition.x);

            float adjustedSpeed = Mathf.Lerp(0f, moveSpeed, positionDifference / alignmentThreshold);

            rb.velocity = new Vector2(adjustedSpeed * moveDirection, 0f);

            playerPosition = transform.position; 
        }
        else
        {
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

    public void Money(int cash)
    {
        _money+=cash;
        
          Debug.Log("Moneda recogida, dinero: " + _money);

        if (coinSound != null)
        {
            coinSound.Play();
        }
    }
}