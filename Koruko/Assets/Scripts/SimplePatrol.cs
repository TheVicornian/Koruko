using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimplePatrol : MonoBehaviour
{
    // Movement
    public float moveSpeed = 2f;

    // Raycasting/Ground Checking
    public Vector2 groundOffset = new Vector2(2, 0);
    public float groundDistance = 2f;
    public LayerMask groundMask;

    // Components/References
    public SpriteRenderer sprite;

    //health
    int _hp = 3;
    public int hp
    {
        get => _hp;
        set => _hp = Mathf.Clamp(value, 0, maxHP);
    }
    public int maxHP = 3;


    void Update()
    {
        Move();
        CheckForLedge();

    }

    private void Move()
    {
        transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
    }

    void CheckForLedge()
    {
        // Do a 2D raycast and check if NOTHING was hit i.e. edge of the platform
        Vector2 checkPos = new Vector2(transform.position.x + groundOffset.x, transform.position.y + groundOffset.y);
        RaycastHit2D hit;
        hit = Physics2D.Raycast(checkPos , Vector2.down, groundDistance);
        if(hit == false)
        {
            moveSpeed *= -1;
            groundOffset.x *= -1;
            sprite.flipX = !sprite.flipX;

            Debug.DrawLine(transform.position, checkPos, Color.red);
            Debug.DrawRay(checkPos, Vector2.down * groundDistance, Color.red);
        }
        else
        {
            Debug.DrawLine(transform.position, checkPos, Color.magenta);
            Debug.DrawLine(checkPos, hit.point, Color.magenta);
        }
    }

    void OnDrawGizmos()
    {
        Vector2 checkPos = new Vector2(transform.position.x + groundOffset.x, transform.position.y + groundOffset.y);
        Gizmos.DrawLine(transform.position, checkPos);
        Gizmos.DrawRay(checkPos, Vector2.down * groundDistance);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Projectile")
        {
            Destroy(other.gameObject);
            if (hp > 1)
                hp--;
            else
                Destroy(this.gameObject);
        }

        if (other.tag == "FireProjectile")
        {
            Destroy(other.gameObject);
            if (hp > 3)
                hp--;
            else
                Destroy(this.gameObject);
        }

    }
}
