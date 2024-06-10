using UnityEngine;

[System.Serializable]
[CreateAssetMenu(menuName = "DataBase/CreateCharacterData")]
public class CharacterData : ScriptableObject
{
    [Header("�摜")]
    [SerializeField] private Sprite graph = null;

    [Space(5)]

    [Header("HP")]
    [SerializeField] private int maxHP = 0;
    [Header("�ړ������x")]
    [SerializeField] private float acceleSpeed = 0.0f;
    [Header("�ړ��ő呬�x")]
    [SerializeField] private float maxSpeed = 0.0f;
    [Header("�ړ����C�x")]
    [SerializeField] private float friction = 0.0f;

    [Header("�d�͉����x")]
    [SerializeField] private float acceleGravity = 0.0f;

    public Sprite Graph => graph;
    public int MaxHP => maxHP;
    public float AcceleSpeed => acceleSpeed;
    public float MaxSpeed => maxSpeed;
    public float Friction => friction;

    public float AcceleGravity => acceleGravity;
}
