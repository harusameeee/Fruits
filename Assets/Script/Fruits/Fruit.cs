using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : MonoBehaviour
{
    private bool m_isActive = false;
    private static float m_time = 3.0f;
    private Select2D select2D = null;

    private void Start()
    {
        select2D = FindObjectOfType<Select2D>(); // Select2D���擾
    }

    void Update()
    {
        // �������I������Ă��邩����
        if (select2D?.selectedObject == gameObject)
        {
            m_time -= Time.deltaTime;
            Debug.Log(gameObject.name + " �������Ă��܂��I �c�莞��: " + m_time);

            // ���Ƃ�
            if (m_time <= 0)
            {
                select2D.isSelect = false; // �I������
                select2D.selectedObject = null; // �I���I�u�W�F�N�g���Z�b�g
                m_isActive = true;
            }
        }
        else if(!select2D.isSelect)
        {
            m_time = 3.0f; // �I������Ă��Ȃ��Ƃ��͎��ԃ��Z�b�g
        }

        if (m_isActive)
        {
            //��ʊO�ɏo��܂�
            transform.position += Vector3.down * 5f * Time.deltaTime;

            if (transform.position.y < Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0)).y - 1f)
            {
                Destroy(gameObject); // ��ʊO�ɏo�������
                m_isActive = false;
            }
        }
    }

}
