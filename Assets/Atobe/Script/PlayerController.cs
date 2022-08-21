using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Player �̓����Ɋւ���X�N���v�g
/// Player �ɂȂ� Object �ɃA�^�b�`���Ďg��
/// </summary>
public class PlayerController : MonoBehaviour
{
    [Header("���˂���e�̃v���n�u")]
    [SerializeField] GameObject _bulletPrefab = default;
    [Header("�}�Y���̃v���n�u")]
    [SerializeField] Transform _muzzle = default;
    [Header("�v���C���[�̈ړ����x")]
    [SerializeField] float _speed = 5.0f;
    [Header("�v���C���[�̃W�����v��")]
    [SerializeField] private float _force = 250.0f;

    public float Speed => _speed; // speed �̐���
    // �v���C���[�� Rigidbody
    Rigidbody2D m_rb = default;
    // ��i�W�����v�̐^�U
    bool _doubleJump = false;
    // �n�ʂɗ����Ă��邩�̐^�U
    bool _isGround = true;
    // �ŏ��ɏo���������W
    Vector3 m_initialPosition;
    // ���E�𔽓]�����邩�̐^�U
    bool _flipX = true;
    // ���������̓��͒l
    float m_h;
    float _scaleX;

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
            // Ground �ɐG��Ă���Ƃ�
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
            Debug.Log("�����A�n���s��");
        }
        // ���N���b�N��������
        if (Input.GetButtonDown("Fire1"))
        {
            // �e�𔭎˂��鏈��
            GameObject bullet = Instantiate(_bulletPrefab);
            bullet.transform.position = _muzzle.position;
            Debug.Log("�u�΁`��v");
        }
        // �ݒ�ɉ����č��E�𔽓]������
        if (_flipX)
        {
            FlipX(m_h);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Ground �ɐG��Ă���Ƃ�
        if (collision.gameObject.tag == "Ground")
        {
            _isGround = true;
            Debug.Log("�n�ʂɂ���ɂ���");
        }
    }
    private void FixedUpdate()
    {
        // �͂�������̂� FixedUpdate �ōs��
        m_rb.AddForce(Vector2.right * m_h * _speed, ForceMode2D.Force);
    }

    // Player �̌����Ɋւ���u���b�N
    void FlipX(float horizontal)
    {
        _scaleX = this.transform.localScale.x;


        // Player ���E�������Ă���Ƃ�
        if (horizontal > 0)
        {
            isreturn = false;
            this.transform.localScale = new Vector3(Mathf.Abs(this.transform.localScale.x), this.transform.localScale.y, this.transform.localScale.z);
        }
        // Player �����������Ă���Ƃ�
        else if (horizontal < 0)
        {
            isreturn = true;
            this.transform.localScale = new Vector3(-1 * Mathf.Abs(this.transform.localScale.x), this.transform.localScale.y, this.transform.localScale.z);
        }
    }
    public bool isreturn = false;
}
