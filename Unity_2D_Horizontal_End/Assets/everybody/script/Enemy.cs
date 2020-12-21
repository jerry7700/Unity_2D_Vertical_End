using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform wayPoint01, wayPoint02;
    private Transform wayPointTarget;
    [SerializeField] private float moveSpeed;

    [SerializeField] private float attackRang;

    private SpriteRenderer sp;

    private Transform target;

    private Animator anim;
    public GameObject projectile;
    public Transform firePoint;

    private void Start()
    {
        wayPointTarget = wayPoint01;
        sp = GetComponent<SpriteRenderer>();
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if(Vector2.Distance(transform.position, target.position) >= attackRang)
        {
            anim.SetBool("isAttack", false);
            patrol();
        }
        else
        {
            anim.SetBool("isAttack", true);
        }

        if(Input.GetKeyDown(KeyCode.Space))
        {
            GetComponentInChildren<HealthBar>().hp -= 20;
        }
    }

    //攻擊
    private void patrol()
    {
        transform.position = Vector2.MoveTowards(transform.position, wayPointTarget.position, moveSpeed* Time.deltaTime);
        if(Vector2.Distance(transform.position, wayPoint01.position)<= 0.01f)
        {
            wayPointTarget = wayPoint02;
            //sp.flipX = true;//怪物向左
            Vector3 localTemp = transform.localScale;
            localTemp.x *= -1;
            transform.localScale = localTemp;
        }
        if (Vector2.Distance(transform.position, wayPoint02.position) <= 0.01f)
         {
            wayPointTarget = wayPoint01;
            //sp.flipX = false;//怪物向右
            Vector3 localTemp = transform.localScale;
            localTemp.x *= -1;
            transform.localScale = localTemp;
        }
    }

    public void Shot()
    {
        Instantiate(projectile, firePoint.position, Quaternion.identity);
    }
}
