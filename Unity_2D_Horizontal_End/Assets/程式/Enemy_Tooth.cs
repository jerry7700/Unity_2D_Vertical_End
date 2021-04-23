using UnityEngine;
using System.Collections;

public class Enemy_Tooth : MonoBehaviour
{
    #region 欄位
    [Header("移動速度"),Range(1f,100f)]
    public float Speed = 10.5f;
    [Header("追擊速度"),Range(0f,100f)]
    public float ChaseSpeed = 3.5f;
 
    private Rigidbody2D rb;
    private Animator anim;
    private player player;

    #endregion

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        player = FindObjectOfType<player>();
    }

    private void Update()
    {
        
    }

    private void LateUpdate()
    {
        Move();
    }

    private void OnDrawGizmosSelected()
    {
        
    }

    public void Move()
    {
        //float y =  transform.position.x > player.transform.position.x ? 180 : 0;
        //transform.eulerAngles = new Vector3(0, y, 0);

        Vector3 posA = player.transform.position;                                //取得玩家座標
        Vector3 posB = transform.position;                                       //取得自身座標
        posA.z = -10;

        posB = Vector3.Lerp(posB, posA, 0.5f * ChaseSpeed);
        transform.position = posB;
    }
}
