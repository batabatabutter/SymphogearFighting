using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEditor.U2D.Animation;
using UnityEngine;

public class Character : MonoBehaviour
{
    [Header("キャラクター情報")]
    [SerializeField] private CharacterData m_characterData = null;
    [SerializeField] private Rigidbody2D m_rigidbody2D = null;

    [Space(30)]
    [Header("値閲覧用")]
    [Header("現在HP")]
    [SerializeField] private int m_hp = 0;
    [Header("現在ゲージ")]
    [SerializeField] private int m_gauge = 0;
    [Header("ガード状態")]
    [SerializeField] private bool m_guard = false;
    [Header("空中フラグ")]
    [SerializeField] private bool m_air = true;
    [Header("操作不能")]
    [SerializeField] private float m_uncntrollSec = 0.0f;

    //  次に出る技
    private AttackData m_nextAttaack = null;

    /// <summary>
    /// 最初の更新時
    /// </summary>
    private void Start()
    {
        Initialize();
    }

    /// <summary>
    /// 更新
    /// </summary>
    private void Update()
    {
        //  秒数減少
        if (m_uncntrollSec > 0.0f)
        {
            m_uncntrollSec = Mathf.Max(m_uncntrollSec - Time.deltaTime, 0.0f);

            if (m_nextAttaack && m_uncntrollSec <= m_nextAttaack.RecoverySec)
            {
                
                m_nextAttaack = null;
            }
        }
    }

    /// <summary>
    /// 一定フレームで更新
    /// </summary>
    private void FixedUpdate()
    {
        //  物理挙動
        //  移動量取得
        Vector2 velocity = m_rigidbody2D.velocity;
        //  重力加速度代入
        velocity.y -= m_characterData.AcceleGravity * Time.deltaTime;
        //  摩擦代入
        velocity.x = velocity.x * m_characterData.Friction;
        //  代入
        m_rigidbody2D.velocity = velocity;
    }

    /// <summary>
    /// 初期化
    /// </summary>
    private void Initialize()
    {
        //  初期パラメータ実装
        m_hp = m_characterData.MaxHP;

    }

    
    /// <summary>
    /// ダメージ
    /// </summary>
    /// <param name="val">値</param>
    public void Damage(int val)
    {
        m_hp = Mathf.Max(m_hp - val, 0);
    }

    /// <summary>
    /// 攻撃
    /// </summary>
    /// <param name="key">キー</param>
    public void Attack(HashSet<ControllKeyType> key)
    {
        //  移動不可ならスキップ
        if (m_uncntrollSec > 0.0f) return;

        foreach (var atk in m_characterData.AttackDataBase.AttackDataList)
        {
            //  キーがあっていたら
            if (key.SetEquals(atk.ControllKeyTypes))
            {
                //  指定の攻撃を実行する
                Attack(atk);
                return;
            }
        }
    }

    /// <summary>
    /// 攻撃
    /// </summary>
    /// <param name="atkData">データ</param>
    public void Attack(AttackData atkData)
    {
        //  移動不可ならスキップ
        if (m_uncntrollSec > 0.0f) return;

        //  行動不可時間調整
        m_uncntrollSec = atkData.StartupSec + atkData.RecoverySec;
        
        //  攻撃データ格納
        m_nextAttaack = atkData;
    }

    /// <summary>
    /// 移動
    /// </summary>
    /// <param name="x"></param>
    public void Move(float x)
    {
        //  移動不可ならスキップ
        if (m_uncntrollSec > 0.0f) return;

        //  最大移動速度以上のベクトルの場合か値が0なら処理しない
        if (Mathf.Abs(m_rigidbody2D.velocity.x) >= m_characterData.MaxSpeed || x == 0.0f) return;

        //  移動量取得
        Vector2 velocity = m_rigidbody2D.velocity;

        //  加速度代入
        velocity.x += x * m_characterData.AcceleSpeed * Time.deltaTime;
        //  最大速度チェック
        velocity.x = Mathf.Clamp(velocity.x, -m_characterData.MaxSpeed, m_characterData.MaxSpeed);

        //  代入
        m_rigidbody2D.velocity = velocity;
    }

    /// <summary>
    ///  ジャンプ
    /// </summary>
    public void Jump()
    {
        //  移動不可ならスキップ
        if (m_uncntrollSec > 0.0f) return;

        //  空中にいたら動作しない
        if (m_air) return;
        //  フラグ切り替え
        m_air = true;

        //  上方向にベクトル代入
        m_rigidbody2D.velocity += Vector2.up * m_characterData.JumpVelocity;
    }

    /// <summary>
    /// トリガー衝突時
    /// </summary>
    /// <param name="collision">衝突物</param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //  オブジェクトと衝突時
        if (collision.CompareTag("Attack"))
        {
            //  攻撃
            if (collision.TryGetComponent(out AttackBase atk))
            {
                
            }
        }
    }

    /// <summary>
    /// トリガー衝突中
    /// </summary>
    /// <param name="collision">衝突物</param>
    public void OnTriggerStay2D(Collider2D collision)
    {
        //  オブジェクトと衝突時
        if (collision.CompareTag("Objects"))
        {
            if (TryGetComponent(out Collider2D coll2D))
            {
                var dis = coll2D.Distance(collision);
                m_rigidbody2D.position += dis.distance * dis.normal;
                m_rigidbody2D.velocity += m_rigidbody2D.velocity * dis.normal;

                //  法線が上なら
                if (dis.normal == Vector2.down) m_air = false;
            }
        }
    }

    public CharacterData CharacterData => m_characterData; 
    public int HP => m_hp;
}
