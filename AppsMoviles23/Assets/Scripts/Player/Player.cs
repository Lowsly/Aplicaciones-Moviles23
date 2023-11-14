using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using System.Collections;
public class Player : MonoBehaviour
{
    public MainMenu mainMenu;
    public float moveSpeed; 
    public int currentHealth = 3;
    public Image[] healthBars;

    public Sprite fullBar, emptyBar;
    public int maxHealth = 5; 
    private Vector3 playerPosition;
    private int _money;
    public TextMeshProUGUI text;
    public AudioSource coinSound;
    public Collider2D backgroundCollider;
    public Collider2D[] blockCollider;
    public GameObject background, player, energyShield;
    public GameObject[] block;
    private bool mouse_over = false; 
    public bool _stunned, _immune, returning;
    private Animator _animator;
    public SpriteRenderer Energy;
    bool isMousePressed = false; 
    public MainMenu menu;
    private void Start()
    {
        playerPosition = transform.position;
        Application.targetFrameRate = 60;
        _money = 0;
        UpdateHealthUI();
        _animator = GetComponent<Animator>();
    }
    private void Update()
    {
        text.text = string.Format("dinero = {0}", _money);
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetMouseButton(0) && EventSystem.current.currentSelectedGameObject == null && backgroundCollider.OverlapPoint(mousePosition) && !_stunned)
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

        if (Input.GetMouseButton(0) == false && !_stunned)
        {
            transform.position = new Vector2(transform.position.x, transform.position.y);  
        }	

        if (_stunned)
        {
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(transform.position.x, -background.transform.localScale.y/1.3f), moveSpeed/4 * Time.deltaTime);
        }
        if (returning)
        {
            transform.position = Vector2.MoveTowards(transform.position, mousePosition, moveSpeed/1.3f * Time.deltaTime);
        }    
        if(transform.position.y>0+background.transform.localScale.y/10)
        {
            _animator.SetFloat("Speed", 1.5f);
        }
        else
        {
            _animator.SetFloat("Speed", 1f);
        }
    }
    public void TakeDamage(int damage)
    {
        if(!_immune){
            currentHealth -= damage;
            UpdateHealthUI();
            _animator.SetTrigger("Fall");
            if (currentHealth <= 0)
                Destroy(gameObject);       
        }
    }
    public void Stunned()
    {
		_stunned=!_stunned;
    }

    public void Returning()
    {
		returning =! returning;
    }
     public void Immune()
    {
        _immune=!_immune;
        if (_immune == true){
            player.layer = LayerMask.NameToLayer("Immune");}
        else {
            player.layer = LayerMask.NameToLayer("Player"); }
    }

    public void EnergyAct()
    {
        StartCoroutine(EnergyShield());
    }
    public void Money(int cash)
    {
        _money+=cash;

        if (coinSound != null)
        {
            coinSound.Play();
        }
    }
    void UpdateHealthUI()
    {
        for (int i = 0; i < healthBars.Length; i++)
        {
            if (i < maxHealth)
            {
                healthBars[i].enabled = true; // Activa la barra de vida
            }
            else
            {
                healthBars[i].enabled = false; // Desactiva barras de vida adicionales
            }
        }
        for (int i = 0; i <maxHealth; i++)
        {
            if (i < currentHealth)
            {
                healthBars[i].sprite = fullBar; // Activa la barra de vida
            }
            else
            {
                healthBars[i].sprite = emptyBar; // Desactiva barras de vida adicionales
            }
        }
    }

    IEnumerator EnergyShield()
    {
        energyShield.SetActive(true); 
        float timer = 0;
        float time = 4;
        yield return new WaitForSeconds(timer);
        while (timer<time/2)
        {
            timer+=Time.deltaTime;
            yield return null;
        }
        timer = 0;
        while(timer<time/4)
        {
            float times;
            if(timer<1)
            { 
                times = timer;
            }
            else
            {
                times = 1;
            }
            timer+=0.15f;
            Energy.enabled = false;
            yield return new WaitForSeconds(0.2f-times/10);
            Energy.enabled = true;
            yield return new WaitForSeconds(0.2f-times/10);
        }
        Energy.enabled = true;
        energyShield.SetActive(false); 
        Immune();
        yield return null;
    }
     public void Heal(int healing)
    {
        currentHealth += healing;

        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }

        // Actualiza las barras de vida
        UpdateHealthUI();
    }
}