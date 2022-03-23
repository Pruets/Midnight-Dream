using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 5f;
    public float jump = 5f;
    public int hp = 3;
    private int check = 2;
    [SerializeField] private Transform checks;
    [SerializeField] private bool isFlash = false;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Animator anime;
    [SerializeField] private SpriteRenderer sr;
    [SerializeField] private GameObject win;
    
    [SerializeField] private bool isGround;
    [SerializeField] private bool isMove;
    [SerializeField] LayerMask groundLayer;

    public static Player instance;

    private void Awake()
    {
        instance = this;
        rb = GetComponent<Rigidbody2D>();
        anime = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Run();
        
        CheckGround();
        Jump();
        AnimePlayer();
    }
    void Run()
    {
       
        float inputX = Input.GetAxis("Horizontal");

        // Swap direction of sprite depending on walk direction
        if (inputX > 0)
        {
            GetComponent<SpriteRenderer>().flipX = false;
            isMove = true;
        }

        else if (inputX < 0)
        {
            GetComponent<SpriteRenderer>().flipX = true;
            isMove = true;
        }
        else if (inputX == 0) { isMove = false; }
        rb.velocity = new Vector2(inputX * speed, rb.velocity.y);
        
    }
   
    void CheckGround()
    {
        isGround = Physics2D.OverlapCircle(checks.transform.position,0.55f,groundLayer);

    }

    void Jump()
    {
        if (isGround)
        {
            check = 2;
        }
        if (Input.GetButtonDown("Jump") && check != 0)
        {
            check -= 1;
            if (!isGround)
            {
                check -= 1;
            }
            rb.velocity = new Vector2(rb.velocity.x, jump);
        }
    }
    void AnimePlayer()
    {
        anime.SetBool("isMove",isMove);
        
    }

    void getDamage()
    {
        hp--;
        isFlash = true;
        rb.bodyType = RigidbodyType2D.Static;
        GetComponent<Collider2D>().enabled = false;
        StartCoroutine(Flash());
        if (hp <= 0)
        {
            gameObject.SetActive(false);
        }
    }
    public void addHp()
    {
        hp++;
        if (hp > GamePlay.instance.maxHp)
            hp = GamePlay.instance.maxHp;
    }

    IEnumerator Flash()
    {
        for(int n = 0; n < 6; n++)
        {
            sr.color = new Color(1f, 1f, 1f, 0.5f);
            yield return new WaitForSeconds(0.1f);
            sr.color = new Color(1f, 1f, 1f, 1f);
            yield return new WaitForSeconds(0.1f);
        }
        rb.bodyType = RigidbodyType2D.Dynamic;
        GetComponent<Collider2D>().enabled = true;
        isFlash = false;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Enemy" && !isFlash)
        {
            getDamage();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Finish"))
        {
            win.SetActive(true);
        }
    }
}
