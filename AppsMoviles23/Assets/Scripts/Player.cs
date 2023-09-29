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


    private bool isMoving = false; // Variable para rastrear si el objeto está en movimiento
    private Vector3 targetPosition; 
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
            // Comienza a mover el objeto cuando se presiona el botón izquierdo del mouse
           Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            // Mantén la misma coordenada z
            mousePosition.y = transform.position.y;

            // Mueve el objeto solo en el eje X hacia la posición del mouse
            transform.position = Vector2.MoveTowards(transform.position, mousePosition, moveSpeed * Time.deltaTime);

            // Aplica la nueva posición
        }
        if (Input.GetMouseButton(0) == false)
        {
            
            transform.position = new Vector2(transform.position.x, transform.position.y);
            
            
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