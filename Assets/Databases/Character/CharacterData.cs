using UnityEngine;

[System.Serializable]
[CreateAssetMenu(menuName = "DataBase/CreateCharacterData")]
public class CharacterData : ScriptableObject
{
    [Header("画像")]
    [SerializeField] private Sprite graph = null;

    [Space(5)]

    [Header("HP")]
    [SerializeField] private int maxHP = 0;
    [Header("移動加速度")]
    [SerializeField] private float acceleSpeed = 0.0f;
    [Header("移動最大速度")]
    [SerializeField] private float maxSpeed = 0.0f;
    [Header("移動摩擦度")]
    [SerializeField] private float friction = 0.0f;

    [Header("重力加速度")]
    [SerializeField] private float acceleGravity = 0.0f;

    public Sprite Graph => graph;
    public int MaxHP => maxHP;
    public float AcceleSpeed => acceleSpeed;
    public float MaxSpeed => maxSpeed;
    public float Friction => friction;

    public float AcceleGravity => acceleGravity;
}
