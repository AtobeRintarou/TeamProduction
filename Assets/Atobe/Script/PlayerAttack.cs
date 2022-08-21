using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [Header("���˂���e�̃v���n�u")]
    [SerializeField] GameObject _bulletPrefab = default;
    [Header("�}�Y���̃v���n�u")]
    [SerializeField] Transform _muzzle = default;
    // ���E�𔽓]�����邩�ǂ����̃t���O
    bool _flipX = false;
    // ���������̓��͒l
    float m_h;
    float _scaleX;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // ���͂��󂯎��
        m_h = Input.GetAxisRaw("Horizontal");
        // ���N���b�N��������
        if (Input.GetButtonDown("Fire1"))
        {
            // �e�𔭎˂��鏈��
            GameObject bullet = Instantiate(_bulletPrefab);
            bullet.transform.position = _muzzle.position;
        }
        // �ݒ�ɉ����č��E�𔽓]������
        if (_flipX)
        {
            FlipX(m_h);
        }
    }
    void FlipX(float horizontal)
    {
        _scaleX = this.transform.localScale.x;


        if (horizontal > 0)
        {
            isreturn = false;
            this.transform.localScale = new Vector3(Mathf.Abs(this.transform.localScale.x), this.transform.localScale.y, this.transform.localScale.z);
        }
        else if (horizontal < 0)
        {
            isreturn = true;
            this.transform.localScale = new Vector3(-1 * Mathf.Abs(this.transform.localScale.x), this.transform.localScale.y, this.transform.localScale.z);
        }
    }
    public bool isreturn = false;
}
