using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class Character : MonoBehaviour
{
    [Header("�L�����N�^�[���")]
    [SerializeField] private CharacterData m_characterData = null;
    [SerializeField] private Rigidbody2D m_rigidbody2D = null;

    [Space(30)]
    [Header("�l�{���p")]
    [Header("����HP")]
    [SerializeField] private int m_hp = 0;
    [Header("���݃Q�[�W")]
    [SerializeField] private int m_gauge = 0;
    [Header("�K�[�h���")]
    [SerializeField] private bool m_guard = false;
    [Header("�󒆃t���O")]
    [SerializeField] private bool m_air = true;


    /// <summary>
    /// �ŏ��̍X�V��
    /// </summary>
    private void Start()
    {
        Initialize();
    }

    /// <summary>
    /// �X�V
    /// </summary>
    private void Update()
    {
        
    }

    /// <summary>
    /// ���t���[���ōX�V
    /// </summary>
    private void FixedUpdate()
    {
        //  �ړ��ʎ擾
        Vector2 velocity = m_rigidbody2D.velocity;

        //  �d�͉����x���
        velocity.y -= m_characterData.AcceleGravity * Time.deltaTime;

        //  ���C���
        velocity.x = velocity.x * m_characterData.Friction;

        //  ���
        m_rigidbody2D.velocity = velocity;
    }

    /// <summary>
    /// ������
    /// </summary>
    private void Initialize()
    {
        //  �����p�����[�^����
        m_hp = m_characterData.MaxHP;

    }

    /// <summary>
    /// �ړ�
    /// </summary>
    /// <param name="x"></param>
    public void Move(float x)
    {
        //  �ő�ړ����x�ȏ�̃x�N�g���̏ꍇ�͏������Ȃ�
        if (Mathf.Abs(m_rigidbody2D.velocity.x) >= m_characterData.MaxSpeed) return;

        //  �ړ��ʎ擾
        Vector2 velocity = m_rigidbody2D.velocity;

        //  �����x���
        velocity.x += x * m_characterData.AcceleSpeed * Time.deltaTime;
        //  �ő呬�x�`�F�b�N
        velocity.x = Mathf.Clamp(velocity.x, -m_characterData.MaxSpeed, m_characterData.MaxSpeed);

        //  ���
        m_rigidbody2D.velocity = velocity;
    }

    /// <summary>
    ///  �W�����v
    /// </summary>
    public void Jump()
    {
        //  �󒆂ɂ����瓮�삵�Ȃ�
        if (m_air) return;

        m_air = true;

        //  ������Ƀx�N�g�����
        m_rigidbody2D.velocity += Vector2.up * 5.0f;
    }

    /// <summary>
    /// �g���K�[�Փˎ�
    /// </summary>
    /// <param name="collision">�Փ˕�</param>
    public void OnTriggerStay2D(Collider2D collision)
    {
        //  �I�u�W�F�N�g�ƏՓˎ�
        if (collision.CompareTag("Objects"))
        {
            if (TryGetComponent(out Collider2D coll2D))
            {
                var dis = coll2D.Distance(collision);
                m_rigidbody2D.position += dis.distance * dis.normal;
                m_rigidbody2D.velocity += m_rigidbody2D.velocity * dis.normal;

                //  �@������Ȃ�
                if (dis.normal == Vector2.down) m_air = false;
            }
        }
    }

    public int HP => m_hp;
}
