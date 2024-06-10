using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Interactions;

public class CharacterController : MonoBehaviour
{
    [SerializeField] private Character m_character;
    [SerializeField] private PlayerInput m_input;

    //  フレーム更新
    private void FixedUpdate()
    {
        //  移動キー確認
        var moveInput = m_input.actions["Move"].ReadValue<Vector2>();
        //  X軸の動作
        if (moveInput.x > 0) m_character.Move(1.0f);
        else if (moveInput.x < 0) m_character.Move(-1.0f);
        //  Y軸の動作
        if (moveInput.y > 0) m_character.Jump();
        else if (moveInput.y < 0) ;
    }

    //  技キーが押されたら
    public void OnJump(InputAction.CallbackContext context)
    {
        // 押された瞬間でPerformedとなる
        if (!context.performed) return;

        m_character.Jump();
    }

    //  技キーが押されたら
    public void OnTechnical(InputAction.CallbackContext context)
    {
        // 押された瞬間でPerformedとなる
        if (!context.performed) return;

        Debug.Log("技");
    }
}
