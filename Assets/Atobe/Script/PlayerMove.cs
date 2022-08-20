using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [Tooltip("�v���C���[�̈ړ����x")]
    [SerializeField] float _speed = 5.0f;
    // speed�̐���
    public float Speed => _speed;
    [Tooltip("�v���C���[�̃W�����v��")]
    [SerializeField] private float _force = 250.0f;
    // �v���C���[��Rigidbody
    Rigidbody2D m_rb = default;
    // ��i�W�����v�̐^�U
    bool _doubleJump = false;
    // �n�ʂɗ����Ă��邩�̐^�U
    bool _isGround = true;
    // ���������̓��͒l
    float m_h;
    // �ŏ��ɏo���������W
    Vector3 m_initialPosition;

    private void Start()
    {
        m_rb = GetComponent<Rigidbody2D>();
        // �����ʒu���o���Ă���
        m_initialPosition = this.transform.position;
    }

    void Update()
    {
        // ���͂��󂯎��
        m_h = Input.GetAxisRaw("Horizontal");
        // �X�y�[�X�L�[�ŃW�����v
        if (Input.GetButtonDown("Jump"))
        {
            if (_isGround)
            {
                _isGround = false;
                _doubleJump = true;

                m_rb.AddForce(Vector2.up * _force, ForceMode2D.Impulse);
                Debug.Log("����Α�n");
            }
            // 2�i�W�����v���Ă���W�����v�ł��Ȃ�
            else if (_doubleJump)
            {
                _doubleJump = false;
                m_rb.AddForce(Vector2.up * _force, ForceMode2D.Impulse);
                Debug.Log("���ׂȂ���");
            }
        }
        // ���ɍs���������珉���ʒu�ɖ߂�
        if (this.transform.position.y < -10f)
        {
            this.transform.position = m_initialPosition;
        }
    }
    private void FixedUpdate()
    {
        // �͂�������̂� FixedUpdate �ōs��
        m_rb.AddForce(Vector2.right * m_h * _speed, ForceMode2D.Force);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            _isGround = true;
            Debug.Log("�n�ʂɂ���ɂ���");
        }
    }
}
