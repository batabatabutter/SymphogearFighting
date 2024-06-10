using System.Collections.Generic;
using UnityEngine;

public class CharacterDataBase : ScriptableObject
{
    [Header("キャラリスト")]
    [SerializeField] List<CharacterData> characterList = new List<CharacterData>();

    public List<CharacterData> CharacterList => characterList;
}
