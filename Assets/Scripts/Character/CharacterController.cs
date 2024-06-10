using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Interactions;

public class CharacterController : MonoBehaviour
{
    [SerializeField] private Character m_character;
    [SerializeField] private PlayerInput m_input;

    //  �t���[���X�V
    private void FixedUpdate()
    {
        //  �ړ��L�[�m�F
        var moveInput = m_input.actions["Move"].ReadValue<Vector2>();
        //  X���̓���
        if (moveInput.x > 0) m_character.Move(1.0f);
        else if (moveInput.x < 0) m_character.Move(-1.0f);
        //  Y���̓���
        if (moveInput.y > 0) m_character.Jump();
        else if (moveInput.y < 0) ;
    }

    //  �Z�L�[�������ꂽ��
    public void OnJump(InputAction.CallbackContext context)
    {
        // �����ꂽ�u�Ԃ�Performed�ƂȂ�
        if (!context.performed) return;

        m_character.Jump();
    }

    //  �Z�L�[�������ꂽ��
    public void OnTechnical(InputAction.CallbackContext context)
    {
        // �����ꂽ�u�Ԃ�Performed�ƂȂ�
        if (!context.performed) return;

        Debug.Log("�Z");
    }
}
