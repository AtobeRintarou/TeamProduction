using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [Header("発射する弾のプレハブ")]
    [SerializeField] GameObject _bulletPrefab = default;
    [Header("マズルのプレハブ")]
    [SerializeField] Transform _muzzle = default;
    // 左右を反転させるかどうかのフラグ
    bool _flipX = false;
    // 水平方向の入力値
    float m_h;
    float _scaleX;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // 入力を受け取る
        m_h = Input.GetAxisRaw("Horizontal");
        // 左クリックをしたら
        if (Input.GetButtonDown("Fire1"))
        {
            // 弾を発射する処理
            GameObject bullet = Instantiate(_bulletPrefab);
            bullet.transform.position = _muzzle.position;
        }
        // 設定に応じて左右を反転させる
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
