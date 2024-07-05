using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Interactions;

/// <summary>
/// コントロールキーのタイプ
/// </summary>
[System.Serializable]
public enum ControllKeyType
{
    [InspectorName("無(Nutoral)")] Nutoral,
    [InspectorName("前(Forword)")] Forword,
    [InspectorName("後(Back)")] Back,
    [InspectorName("上(Up)")] Up,
    [InspectorName("下(Down)")] Down,

    [InspectorName("弱(LowAttack)")] LowAttack,
    [InspectorName("強(HighAttack)")] HighAttack,
    [InspectorName("技(Technical)")] Technical
}

public class CharacterController : MonoBehaviour
{
    [Header("キャラクター")]
    [SerializeField] private Character m_character;

    [Space(10), Header("操作系")]
    [Header("インプット")]
    [SerializeField] private PlayerInput m_input;
    [Header("移動入力キー")]
    [SerializeField] private InputActionProperty m_move;
    [Header("技入力キー")]
    [SerializeField] private InputActionProperty m_technical;

    //  起動時
    private void Awake()
    {
        //  技
        // InputActionインスタンスを取得
        var action = m_technical.action;

        // Actionが無かったら何もしない
        if (action == null) return;

        // performedコールバックにOnPerformedメソッドを登録
        action.performed += OnTechnical;

        // Actionを有効化して入力を受け取れるようにする
        action.Enable();

    }

    //  フレーム更新
    private void Update()
    {
        //  移動キー確認
        var moveInput = m_move.action.ReadValue<Vector2>();
        //  X軸の動作
        m_character.Move(moveInput.x);
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

        //  移動の値
        var move = m_move.action.ReadValue<Vector2>();
        bool reverse = false;
        if (transform.right != Vector3.right) { reverse = true; }

        //  キー
        HashSet<ControllKeyType> keys = new HashSet<ControllKeyType>
        { ControllKeyType.Technical };
        if      (move.x > 0.0f && !reverse || move.x < 0.0f && reverse) keys.Add(ControllKeyType.Forword);
        else if (move.x < 0.0f && !reverse || move.x > 0.0f && reverse) keys.Add(ControllKeyType.Back);
        else                                                            keys.Add(ControllKeyType.Nutoral);


        //  攻撃
        m_character.Attack(keys);
    }
}
