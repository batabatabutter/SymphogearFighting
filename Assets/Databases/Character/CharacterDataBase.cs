using System.Collections.Generic;
using UnityEngine;

public class CharacterDataBase : ScriptableObject
{
    [Header("�L�������X�g")]
    [SerializeField] List<CharacterData> characterList = new List<CharacterData>();

    public List<CharacterData> CharacterList => characterList;
}
