using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class Player : MonoBehaviour
{
    public MainMenu mainMenu;
    public float moveSpeed; 

    public int currentHealth = 3;

    private Rigidbody2D rb;
    private Vector3 playerPosition;
    private int _money;

    public TextMeshProUGUI text;
    public AudioSource coinSound;

bool isMousePressed = false; 
    public GameObject nonSafeArea;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerPosition = transform.position;
        Application.targetFrameRate = 60;
        _money = 0;
    }

    private void Update()
    {
        text.text = string.Format("dinero = {0}", _money);
         Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (Input.GetMouseButton(0) == true && EventSystem.current.currentSelectedGameObject == null)
        {
            // Comienza a mover el objeto cuando se presiona el botón izquierdo del mouse

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

        if (coinSound != null)
        {
            coinSound.Play();
        }
    }
}