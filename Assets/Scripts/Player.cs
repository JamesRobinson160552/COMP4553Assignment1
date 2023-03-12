using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField] GameManager gameManager;
    [SerializeField] GameObject door;
    [SerializeField] Rigidbody2D playerRb;
    [SerializeField] BoxCollider2D playerCollider;
    [SerializeField] Animator anim;
    [SerializeField] SpriteRenderer sprite;
    [SerializeField] float horizontalInput;
    [SerializeField] float speed = 8.0f;
    [SerializeField] float jumpForce = 16.0f;
    [SerializeField] LayerMask ground;
    [SerializeField] GameObject endScreen;
    [SerializeField] AudioSource playerAudio;
    [SerializeField] AudioClip jumpSound;
    [SerializeField] AudioClip hurtSound;
    [SerializeField] AudioClip keySound;
 
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
        playerCollider = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        playerAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.gameActive)
        {
            Run();
            Jump();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Obstacle"))
        {
            playerAudio.PlayOneShot(hurtSound, 1.0f);
            anim.SetBool("run", false);
            anim.SetBool("jump", false);
            anim.SetBool("idle", false);
            anim.SetBool("death", true);
            gameManager.GameOver();
        }

        else if (other.CompareTag("Treasure"))
        {
            gameManager.AddTreasure();
            Destroy(other.gameObject);
        }

        else if (other.CompareTag("Key"))
        {
            playerAudio.PlayOneShot(keySound, 1.0f);
            Destroy(door);
            Destroy(other.gameObject);
        }

        else if (other.CompareTag("Prince"))
        {
            gameManager.gameActive = false;
            endScreen.gameObject.SetActive(true);
        }
    }

    void Run()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        float horizontalMove = horizontalInput * speed * Time.deltaTime;
        gameObject.transform.position += new Vector3(horizontalMove, 0, 0);
        if (horizontalInput > 0)
        {
            anim.SetBool("idle", false);
            anim.SetBool("run", true);
            sprite.flipX = false;
        }

        else if (horizontalInput < 0)
        {
            anim.SetBool("idle", false);
            anim.SetBool("run", true);
            sprite.flipX = true;
        }

        else 
        {
            anim.SetBool("run", false);
            anim.SetBool("idle", true);
        }
    }

    void Jump()
    {
        if (Input.GetKeyDown("space") && checkGrounded())
        {
            playerAudio.PlayOneShot(jumpSound, 0.4f);
            playerRb.velocity = new Vector3(0, jumpForce, 0);
            anim.SetBool("run", false);
            anim.SetBool("idle", false);
            anim.SetBool("jump", true);
        }
        
        else 
        {
            anim.SetBool("jump", false);
        }
    }

    bool checkGrounded()
    {
        return Physics2D.BoxCast(playerCollider.bounds.center, playerCollider.bounds.size, 0, Vector2.down, 0.1f, ground);
    }
}
