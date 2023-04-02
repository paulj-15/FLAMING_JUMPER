using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Player_CTRL : MonoBehaviour
{

    public Vector3 Respawnpoi;

    public float speed = 4f;
    private float movem = 0f;
    private Rigidbody2D rigbod;

    //jump
    public float jumpForce = 4;

    // making the layer to stop up.
    public Transform groundCheckPoint;//pisition
    public float groundCheckRadius;//radius
    public LayerMask groundLayer;//anything specified by u.
    private bool istouchingGrond;// bool true/fals

    private TMP_Text scoreText;
    // animation
    public Animator animator;

    float score;

    // Start is called before the first frame update
    void Start()
    {
        rigbod = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        Respawnpoi = transform.position;

        if (GameObject.FindObjectOfType<TMP_Text>())
        {
            scoreText = GameObject.FindObjectOfType<TMP_Text>();
            scoreText.text = "Score : " + score;
        }

    }

    // Update is called once per frame
    void Update()
    {

        istouchingGrond = Physics2D.OverlapCircle(groundCheckPoint.position, groundCheckRadius, groundLayer);

        movem = Input.GetAxis("Horizontal");

        animator.SetFloat("speed", Mathf.Abs(movem));
        if (movem > 0f)
        {
            rigbod.velocity = new Vector2(movem * speed, rigbod.velocity.y);
            transform.eulerAngles = new Vector3(0,0,0);
            //transform.localScale = new Vector2(1.1037f, 1.1037f);

        }
        else if (movem < 0f)
        {
            rigbod.velocity = new Vector2(movem * speed, rigbod.velocity.y);
            transform.eulerAngles = new Vector3(0, 180f, 0);
            //transform.localScale = new Vector2(-1.1037f, 1.1037f);
        }
        else
        {
            //it will simply keep movementa in x-axis 0/zero.
            //rigbod.velocity = new Vector2(0, rigbod.velocity.y);
        }

        // at last after movem apply jump
        if (Input.GetButtonDown("Jump") && istouchingGrond)
        {
            //jumpsp = for space key
            rigbod.velocity = new Vector2(rigbod.velocity.x, jumpForce);
            //animator.SetBool("isJumping", true);
        }
        //animation
        //animator.SetBool("OnGround", istouchingGrond);



    }

    public void OnLanding()
    {
        animator.SetBool("isJumping", false);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "FallDetector")
        {
            Debug.Log("Detected");
            transform.position = Respawnpoi;
        }
        if (other.tag == "Checkpoint")
        {
            Respawnpoi = other.transform.position;
        }

        if (other.tag == "Door")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

        if (other.tag == "Lava")
        {
            Debug.Log("Lava Detection");
            transform.position = Respawnpoi;
        }
        if(other.tag == "Coin")
        {
            scoreText.text = "Score : " + (++score);
            Destroy(other.gameObject);
        }


    }
}








