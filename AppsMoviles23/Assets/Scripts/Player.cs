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

    public Collider2D backgroundCollider;
    
    public Collider2D[] blockCollider;

    public GameObject[] block;

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

        if (Input.GetMouseButton(0) && EventSystem.current.currentSelectedGameObject == null && backgroundCollider.OverlapPoint(mousePosition))
        {
            float distance1 = Mathf.Abs(block[0].transform.position.y-transform.position.y);
            float distance2 = Mathf.Abs(block[1].transform.position.y-transform.position.y);
            if(!blockCollider[0].OverlapPoint(mousePosition) && !blockCollider[1].OverlapPoint(mousePosition))
            transform.position = Vector2.MoveTowards(transform.position, mousePosition, moveSpeed * Time.deltaTime);

            else if(blockCollider[0].OverlapPoint(mousePosition) || mousePosition.y<=(block[0].transform.position.y+block[0].transform.localScale.y))
            {
                transform.position = Vector2.MoveTowards(transform.position, new Vector2(mousePosition.x,block[0].transform.position.y+block[0].transform.localScale.y/2), moveSpeed * Time.deltaTime);
            }
            
            else if(blockCollider[1].OverlapPoint(mousePosition) || mousePosition.y<=(block[1].transform.position.y-block[1].transform.localScale.y))
            {
                transform.position = Vector2.MoveTowards(transform.position, new Vector2(mousePosition.x,block[1].transform.position.y-block[1].transform.localScale.y/2), moveSpeed * Time.deltaTime);
            }
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