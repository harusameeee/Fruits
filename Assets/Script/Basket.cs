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
            Debug.Log("����������");
            Destroy(collision.gameObject); // Fruit�I�u�W�F�N�g������
            m_count++;
        }
    }

    //�K��l�ȏ�Ȃ炨�q����̂Ƃ��Ɏ����Ă�����悤�ɂ���
    //����ȏ�̂�Ȃ��悤�ɂ���
    private void Update()
    {
        //�K��l�ȏ�Ȃ�
        if (m_count>=3)
        {
            //�n����悤�ɂ���

            //���g�����Z�b�g(�Đݒ肷��)
            
        }
    }

    public bool GetIsFinish() { return m_isFinish; }
}
