using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPBarkari : MonoBehaviour
{
    [SerializeField] private Character character;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var scale = this.transform.localScale;
        scale.x = (float)character.HP / character.CharacterData.MaxHP;
        this.transform.localScale = scale;
    }
}
