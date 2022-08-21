using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    [Header("���˂���e�̃X�s�[�h")]
    [SerializeField] float _speed = 3f;
    [Header("���˂���e�̃��C�t�^�C��")]
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
        // �E�����ɔ�΂�
        //  Rigidbody2D rb = GetComponent<Rigidbody2D>();
        // rb.velocity = Vector2.right * m_speed;
        // �������Ԃ��o�߂����玩�����g��j������
        Destroy(this.gameObject, _lifeTime);
    }
}
