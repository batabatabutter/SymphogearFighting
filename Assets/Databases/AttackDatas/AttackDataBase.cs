using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu(menuName = "DataBase/Attack/CreateAttackDataBase")]
public class AttackDataBase : ScriptableObject
{
    [Header("ƒLƒƒƒ‰ƒŠƒXƒg")]
    [SerializeField] List<AttackData> attackDataList = new List<AttackData>();


    public List<AttackData> AttackDataList => attackDataList;
}
