using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    [Header("発射する弾のスピード")]
    [SerializeField] float _speed = 3f;
    [Header("発射する弾のライフタイム")]
    [SerializeField] float _lifeTime = 5f;

    public PlayerAttack a = null;
    void Start()
    {
        a = GameObject.Find("Player").GetComponent<PlayerAttack>();
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        if (a.isreturn)
        {
            rb.velocity = Vector2.right * _speed * -1;
        }
        else
        {
            rb.velocity = Vector2.right * _speed;
        }
        // 右方向に飛ばす
        //  Rigidbody2D rb = GetComponent<Rigidbody2D>();
        // rb.velocity = Vector2.right * m_speed;
        // 生存期間が経過したら自分自身を破棄する
        Destroy(this.gameObject, _lifeTime);
    }
}
