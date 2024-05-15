using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MoveTest : MonoBehaviour
{
    //  移動速度
    [SerializeField] float m_moveSPD = 0.0f;

    //  移動速度
    private Vector3 m_velocity = Vector3.zero;

    private Vector2 readValue;

    // Update is called once per frame
    void Update()
    {
        //  移動速度
        m_velocity = readValue * m_moveSPD;

        //  移動速度分移動
        transform.position += m_velocity * Time.deltaTime;
    }

    //  移動キーが反応したら
    public void OnMove(InputAction.CallbackContext context)
    {
        readValue = context.ReadValue<Vector2>();
    }
    
    //  技キーが押されたら
    public void OnTechnical(InputAction.CallbackContext context)
    {
        // 押された瞬間でPerformedとなる
        if (!context.performed) return;

        Debug.Log("技");
    }
}
