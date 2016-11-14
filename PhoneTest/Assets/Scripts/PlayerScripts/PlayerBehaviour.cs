using UnityEngine;
using System.Collections;

public class PlayerBehaviour : MonoBehaviour {

    // Use this for initialization

    Rigidbody2D rb;
    public Vector3 acceleration;
    public int jumpPower;
    bool isOnGround = true;
    public Vector3 speed;
    public int velocity;
    int jumpCounter = 0;
    public GameObject start;
    public int explosivePower = 3;
    public int explosiveRadius = 2;
    public ParticleSystem explosionFx;
    public Vector2 lastCheckPointPos;
    public ParticleSystem blooSplatter;
    SpriteRenderer renderer;
    
    
    void Start ()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(velocity, 0);
        lastCheckPointPos = start.transform.position;
        renderer = GetComponent<SpriteRenderer>();

    }
	
	// Update is called once per frame
	void Update ()
    {
        //transform.position += speed * Time.deltaTime;
        rb.velocity = new Vector2(velocity, rb.velocity.y);
        //rb.AddForce(new Vector2(velocity, 0));
        foreach (Touch touch in Input.touches)
        {
            if (touch.phase == TouchPhase.Began && isOnGround)
            {
                rb.AddForce(new Vector2(0, jumpPower));

                jumpCounter++;
                if (jumpCounter > 1)
                {
                    isOnGround = false;
                }
            }
        }
        //For KEYBOARD
        if (Input.GetButtonDown("Jump") && isOnGround)
        {
            rb.AddForce(new Vector2(0, jumpPower));
            jumpCounter++;
            if (jumpCounter > 1)
            {
                isOnGround = false;
            }
        }
        if (Input.GetButtonDown("Fire1"))
        {
            Explode();
            Instantiate(explosionFx, new Vector2(transform.position.x + 0.1f, transform.position.y + 0.1f), Quaternion.identity); //ParticleEffect for explosion
        }

    }
    /*Movable obj or floor to not get stuck on red squares*/
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Floor" || collision.gameObject.tag == "MovableObj")
        {
            jumpCounter = 0;
            isOnGround = true;
        }
        else if (collision.gameObject.tag == "KillBlock")
        {
            Instantiate(blooSplatter, transform.position, Quaternion.identity);
            StartCoroutine(Die());         
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "CheckPoint")
        {
            this.lastCheckPointPos = other.transform.position;
        }
    }
    void Explode()
    {
        Vector2 pos = transform.position;
        Collider2D[] colliders = Physics2D.OverlapCircleAll(pos, explosiveRadius);
        foreach (Collider2D hit in colliders)
        {
            if (hit.tag == "MovableObj")
            {
                Rigidbody2D rb = hit.GetComponent<Rigidbody2D>();
                if (hit.transform.position.x > transform.position.x)    //Är objektet framför?
                {
                    rb.AddForce(new Vector2(explosivePower, 0), ForceMode2D.Impulse);
                }
                else if(hit.transform.position.x > transform.position.x)    //Eller bakom?
                {
                    rb.AddForce(new Vector2(-explosivePower, 0), ForceMode2D.Impulse);
                }
                rb.AddTorque(1f, ForceMode2D.Impulse);
            }
        }

    }
    IEnumerator Die()
    {
        int temp = velocity; // Funkar inte?
        velocity = 0;
        renderer.enabled = false;
        yield return new WaitForSeconds(1);
        gameObject.transform.position = lastCheckPointPos;
        velocity = 5; //Bör vara temp här ist
        renderer.enabled = true;

    }

}
