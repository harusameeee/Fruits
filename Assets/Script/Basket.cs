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

    //3つ以上ならお客さんのとこに持っていけるようにする
    //それ以上のらないようにする
    private void Update()
    {
        if(m_count>=3)
        {
            m_isFinish=true;
            //画像いい感じにしてもいいかも
        }
    }

    public bool GetIsFinish() { return m_isFinish; }
}
