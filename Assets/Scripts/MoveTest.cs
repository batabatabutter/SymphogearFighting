using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MoveTest : MonoBehaviour
{
    //  �ړ����x
    [SerializeField] float m_moveSPD = 0.0f;

    //  �ړ����x
    private Vector3 m_velocity = Vector3.zero;

    private Vector2 readValue;

    // Update is called once per frame
    void Update()
    {
        //  �ړ����x
        m_velocity = readValue * m_moveSPD;

        //  �ړ����x���ړ�
        transform.position += m_velocity * Time.deltaTime;
    }

    //  �ړ��L�[������������
    public void OnMove(InputAction.CallbackContext context)
    {
        readValue = context.ReadValue<Vector2>();
    }
    
    //  �Z�L�[�������ꂽ��
    public void OnTechnical(InputAction.CallbackContext context)
    {
        // �����ꂽ�u�Ԃ�Performed�ƂȂ�
        if (!context.performed) return;

        Debug.Log("�Z");
    }
}
