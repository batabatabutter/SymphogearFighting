using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using static Unity.VisualScripting.Dependencies.Sqlite.SQLite3;

[System.Serializable]
[CreateAssetMenu(menuName = "DataBase/Attack/CreateAttackData")]
public class AttackData : ScriptableObject
{
    [Header("技名")]
    [SerializeField] private string attackName = "";
    [Header("入力方法")]
    //[SerializeField] private List<ControllKeyType> controllKeyTypes = new List<ControllKeyType>();
    [SerializeField, CustomEnum(typeof(ControllKeyType))] private List<string> controllKeyTypeStrings = new List<string>();
    private HashSet<ControllKeyType> controllKeyTypes = new HashSet<ControllKeyType>();

    [Header("攻撃力")]
    [SerializeField] private int atk = 0;
    [Header("持続（判定）")]
    [SerializeField] private float activeSec = 0.0f;
    [Header("発生（前隙）")]
    [SerializeField] private float startupSec = 0.0f;
    [Header("硬直（後隙）")]
    [SerializeField] private float recoverySec = 0.0f;

    //  有効時
    public void OnEnable()
    {
        foreach (var typeStr in controllKeyTypeStrings)
            controllKeyTypes.Add(SerializeUtil.Restore<ControllKeyType>(typeStr));
    }

    public HashSet<ControllKeyType> ControllKeyTypes => controllKeyTypes;
    public string AttackName => attackName;
    public int ATK => atk;
    //  持続
    public float ActiveSec => activeSec;
    //  前隙
    public float StartupSec => startupSec;
    //  後隙
    public float RecoverySec => recoverySec;
}
