using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Bullet �̓����Ɋւ���X�N���v�g
/// Bullet �ɂ����� Prefab �ɃA�^�b�`���Ďg��
/// </summary>
public class BulletController : MonoBehaviour
{
    [Tooltip("���˂���e�̃X�s�[�h")]
    [SerializeField] float _speed = 3f;
    [Tooltip("���˂���e�̃��C�t�^�C��")]
    [SerializeField] float _lifeTime = 5f;

    public PlayerController a = null;
    void Start()
    {
        // Player �Ƃ������O�� Object ���� PlayerController �X�N���v�g�̏����擾
        a = GameObject.Find("Player").GetComponent<PlayerController>();
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        // Player �����������Ă���Ƃ�
        if (a.isreturn)
        {
            rb.velocity = Vector2.right * _speed * -1;
            Debug.Log("������");
        }
        // Player ���E�������Ă���Ƃ�
        else
        {
            rb.velocity = Vector2.right * _speed;
            Debug.Log("�E����");
        }
        // �������Ԃ��o�߂����玩�����g��j�󂷂�
        Destroy(this.gameObject, _lifeTime);
    }
}
