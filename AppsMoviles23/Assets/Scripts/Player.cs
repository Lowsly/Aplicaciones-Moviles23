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

    public Collider2D backgroundCollider, blockCollider;

     private bool mouse_over = false;

bool isMousePressed = false; 

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerPosition = transform.position;
        Application.targetFrameRate = 60;
        _money = 0;
        transform.position = new Vector2(transform.position.x, transform.position.y);
    }
    private void Update()
    {

        text.text = string.Format("dinero = {0}", _money);
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (!UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject() && !EventSystem.current.IsPointerOverGameObject() && !mouse_over && Input.GetMouseButton(0) && EventSystem.current.currentSelectedGameObject == null && backgroundCollider.OverlapPoint(mousePosition) && blockCollider.OverlapPoint(mousePosition) == false)
        {
            transform.position = Vector2.MoveTowards(transform.position, mousePosition, moveSpeed * Time.deltaTime);
        }
        if (Input.GetMouseButton(0) == false)
        {
            
            transform.position = new Vector2(transform.position.x, transform.position.y);
            
            
        }	
        
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        mouse_over = true;
    }
     public void OnPointerExit(PointerEventData eventData)
    {
        mouse_over = false;
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