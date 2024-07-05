using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackBase : MonoBehaviour
{
    //  攻撃情報
    private AttackData attackData;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //  キャラクターと衝突したら
        if (collision.CompareTag("Character"))
        {
            //  攻撃
            if (collision.TryGetComponent(out Character chara))
            {
                chara.Damage(attackData.ATK);
            }
        }
    }
}
