using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public Animator Koruko;
    public CharacterController2D controller;
    public float runSpeed = 40f;
    float horizontalMove = 0f;
    public bool jump = false;

    public int diamonds = 0;
    public int totem = 0;
    public int currentWeapon = 1;
    public int ammo = 0;
    public int fireAmmo = 5;
    public Transform projectileSpawnPoint;
    public GameObject projectile;
    public GameObject fireProjectile;
    public bool isGoingRight;
    bool respawning = false;

    int _hp = 3;
    public int hp
    {
        get => _hp;
        set => _hp = Mathf.Clamp(value, 0, maxHP);
    }
    public int maxHP = 3;

    int _shield = 0;
    public int shield
    {
        get => _shield;
        set => _shield = Mathf.Clamp(value, 0, maxSHIELD);
    }
    public int maxSHIELD = 3;

    public bool isDead;

    public Text livesText;
    public GameObject gameoverScreen;
    public GameObject retryScreen;
    public GameObject endLevel;

    public bool isInvincible => Time.time < invulnEnd;
    [Header("Invincibility")]
    public int invulnTime = 20;
    public float invulnEnd;

    private Vector3 initialPosition;

    public static class GameState
    {
        public static int Lives = 3;
    }

    void Start()
    {
        Koruko = GetComponent<Animator>();
        UpdateLivesText();
        initialPosition = transform.position; // Save the initial position
    }

    void Update()
    {
        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Joystick1Button1)) && ammo > 0 && currentWeapon == 1)
        {
            ammo--;
            Projectile newProjectile = Instantiate(projectile, projectileSpawnPoint.position, this.transform.rotation).GetComponent<Projectile>();

            if (!isGoingRight)
            {
                newProjectile.speed *= -1;
            }
        }

        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Joystick1Button1)) && fireAmmo > 0 && currentWeapon == 2)
        {
            fireAmmo--;
            Projectile newProjectile = Instantiate(fireProjectile, projectileSpawnPoint.position, this.transform.rotation).GetComponent<Projectile>();

            if (!isGoingRight)
            {
                newProjectile.speed *= -1;
                newProjectile.GetComponent<SpriteRenderer>().flipX = true;
            }
            else
            {
                newProjectile.GetComponent<SpriteRenderer>().flipX = false;
            }
        }

        if (!isDead)
        {
            horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        }
        else
        {
            horizontalMove = 0;
        }

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
        }

        if (Input.GetKeyDown(KeyCode.F) || Input.GetKeyDown(KeyCode.Joystick1Button3))
        {
            currentWeapon = currentWeapon == 1 ? 2 : 1;
        }

        if (!isInvincible)
        {
            Koruko.SetBool("DoInvincible", false);
        }
    }

    void FixedUpdate()
    {
        if (horizontalMove < 0)
        {
            isGoingRight = false;
        }
        else if (horizontalMove > 0)
        {
            isGoingRight = true;
        }

        controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);
        jump = false;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        jump = false;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (isDead) return;

        if (other.tag == "Enemy" || other.tag == "Boss")
        { 
           if (isInvincible)
                Destroy(other.gameObject);
           else
                HandleDamage();
        }

        if (other.tag == "Killzone")
        {
            HandleKillzone();
        }

        if (other.tag == "Invincibilty")
        {
            invulnEnd = Time.time + invulnTime;
            Destroy(other.gameObject);
            Koruko.SetBool("DoInvincible", true);
        }

        if (other.tag == "Ammo")
        {
            ammo += 5;
            Destroy(other.gameObject);
        }

        if (other.tag == "FireAmmo")
        {
            fireAmmo += 2;
            Destroy(other.gameObject);
        }

        if (other.tag == "HealthPack")
        {
            hp++;
            Destroy(other.gameObject);
        }

        if (other.tag == "Shield")
        {
            shield += 3;
            Destroy(other.gameObject);
        }

        if (other.tag == "Totem")
        {
            totem++;
            Destroy(other.gameObject);
        }
    }

    void HandleDamage()
    {
        if (isInvincible || isDead) return;

        if (shield > 0)
        {
            shield--;
        }
        else if (hp > 1)
        {
            hp--;
        }
        else
        {
            GameState.Lives--;

            if (GameState.Lives <= 0)
            {
               // GameState.Lives = 0;
                StartCoroutine(GameOverSequence());
            }
            else if (GameState.Lives >= 0)
            {
                StartCoroutine(RespawnSequence());
            }
        }
        UpdateLivesText();
    }

    void HandleKillzone()
    {
        if (isDead) return;

        GameState.Lives--;
        if (GameState.Lives <= 0)
        {
            GameState.Lives = 0;
            StartCoroutine(GameOverSequence());
        }
         else if (GameState.Lives > 0)      
            StartCoroutine(RespawnSequence());
       
        UpdateLivesText();
    }

    IEnumerator RespawnSequence()
    {
        if (respawning) yield break;
        respawning = true;
        isDead = true;

        yield return new WaitForSeconds(1);

        if (retryScreen != null)
        {
            retryScreen.SetActive(true);
        }
        while (!Input.GetKeyDown(KeyCode.Space) && !Input.GetButton("Continue"))
            yield return null;

        // Instead of reloading the scene, reset the player's position and state
        transform.position = initialPosition;
        ResetPlayerState();

        respawning = false;
    }

    IEnumerator GameOverSequence()
    {
        if (respawning) yield break;
        respawning = true;
        isDead = true;

        if (gameoverScreen != null)
            gameoverScreen.SetActive(true);

        runSpeed = 0;

        while (!Input.GetKeyDown(KeyCode.Space) && !Input.GetButton("Continue"))
            yield return null;

        ResetGame();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        respawning = false;
    }

    void UpdateLivesText()
    {
        if (livesText != null)
            ;
    }

    void ResetPlayerState()
    {
        hp = maxHP;
        isDead = false;
        isGoingRight = true;
        ammo = 10;
        fireAmmo = 0;
        UpdateLivesText();

        if (retryScreen != null)
            retryScreen.SetActive(false);

        if (gameoverScreen != null)
            gameoverScreen.SetActive(false);
    }

    void ResetGame()
    {
        GameState.Lives = 3; // Reset the lives count
    }
}


