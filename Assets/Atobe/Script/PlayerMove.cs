using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [Tooltip("プレイヤーの移動速度")]
    [SerializeField] float _speed = 5.0f;
    // speedの制御
    public float Speed => _speed;
    [Tooltip("プレイヤーのジャンプ力")]
    [SerializeField] private float _force = 250.0f;
    // プレイヤーのRigidbody
    Rigidbody2D m_rb = default;
    // 二段ジャンプの真偽
    bool _doubleJump = false;
    // 地面に立っているかの真偽
    bool _isGround = true;
    // 水平方向の入力値
    float m_h;
    // 最初に出現した座標
    Vector3 m_initialPosition;

    private void Start()
    {
        m_rb = GetComponent<Rigidbody2D>();
        // 初期位置を覚えておく
        m_initialPosition = this.transform.position;
    }

    void Update()
    {
        // 入力を受け取る
        m_h = Input.GetAxisRaw("Horizontal");
        // スペースキーでジャンプ
        if (Input.GetButtonDown("Jump"))
        {
            if (_isGround)
            {
                _isGround = false;
                _doubleJump = true;

                m_rb.AddForce(Vector2.up * _force, ForceMode2D.Impulse);
                Debug.Log("さらば大地");
            }
            // 2段ジャンプしてたらジャンプできない
            else if (_doubleJump)
            {
                _doubleJump = false;
                m_rb.AddForce(Vector2.up * _force, ForceMode2D.Impulse);
                Debug.Log("跳べない豚");
            }
        }
        // 下に行きすぎたら初期位置に戻す
        if (this.transform.position.y < -10f)
        {
            this.transform.position = m_initialPosition;
        }
    }
    private void FixedUpdate()
    {
        // 力を加えるのは FixedUpdate で行う
        m_rb.AddForce(Vector2.right * m_h * _speed, ForceMode2D.Force);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            _isGround = true;
            Debug.Log("地面にこんにちは");
        }
    }
}
