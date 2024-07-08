using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;
    public float moveSpeed;
    private Rigidbody2D rig;
    private Vector2 moveDir;
    private Vector2 mousePos;
    private Animator anim;
    public WeaponSystem weapons;
    public bool cantMove;
    public float gameoverDelay;
    public float timeToSpawn;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        anim = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!cantMove)
        {
            moveDir.x = Input.GetAxisRaw("Horizontal");
            moveDir.y = Input.GetAxisRaw("Vertical");
            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            moveDir.Normalize();

            if (Input.GetButton("Fire1"))
            {
                Shoot();
            }
        }
    }

    private void FixedUpdate()
    {
        if (!cantMove)
        {
            Move();
            RotateToMousePos();
        }
    }

    public void Move()
    {
        anim.SetBool("RifMode", false);   
        anim.SetBool("PistolMode", false);     
        anim.SetBool("MSGunMode", false);
        if (moveDir != Vector2.zero)
        {
            anim.SetBool("Move", true);
        }
        else
        {
            anim.SetBool("Move", false);
        }
        rig.MovePosition(rig.position + moveDir * moveSpeed * Time.fixedDeltaTime);
    }

    public void RotateToMousePos()
    {
        Vector2 dirToMousePos = mousePos - rig.position;
        transform.up = new Vector2(dirToMousePos.x, dirToMousePos.y);
    }

    public void Shoot()
    {
        weapons.equippedWeapon.Shoot();
        weapons.UpdateWeaponUI();
    }

    public void Die()
    {
        anim.SetBool("IsDead", true);
        cantMove = true;
        GameOver();
    }

    public void GameOver()
    {
        StartCoroutine(GameOverCo());
    }

    public IEnumerator GameOverCo()
    {
        yield return new WaitForSeconds(gameoverDelay);
        yield return new WaitForSeconds(timeToSpawn);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
