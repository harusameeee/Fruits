using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Basket : MonoBehaviour
{
    private int m_count=0;
    public bool m_isFinish = false; 

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Fluit")&& m_isFinish==false)
        {
            Debug.Log("当たったよ");
            Destroy(collision.gameObject); // Fruitオブジェクトを消す
            m_count++;
        }
    }

    //規定値以上ならお客さんのとこに持っていけるようにする
    //それ以上のらないようにする
    private void Update()
    {
        //規定値以上なら
        if (m_count>=3)
        {
            //渡せるようにする

            //中身をリセット(再設定する)
            
        }
    }

    public bool GetIsFinish() { return m_isFinish; }
}
