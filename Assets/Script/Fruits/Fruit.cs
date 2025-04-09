using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;

public class Fruit : MonoBehaviour
{
    private bool m_isActive = false;
    private static float m_time = 3.0f;
    private Select2D select2D = null;
    private bool isCounting = false;

    private void Start()
    {
        select2D = FindObjectOfType<Select2D>(); // Select2D���擾
    }

    void Update()
    {
        // �������I������Ă��āA�܂��^�C�}�[�������ĂȂ���ΊJ�n
        if (select2D?.selectedObject == gameObject && !isCounting)
        {
            StartDropTimer().Forget(); // �^�C�}�[�������J�n�i�񓯊��j
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

    private async UniTaskVoid StartDropTimer()
    {
        isCounting = true;

        float timer = m_time;

        // �^�C�}�[��0���傫���A�I�𒆂ł���ԃ��[�v
        while (timer > 0f && select2D?.selectedObject == gameObject && select2D.isSelect)
        {
            timer -= Time.deltaTime;
            Debug.Log($"{gameObject.name} �������Ă��܂��I �c�莞��: {timer:F2}");
            await UniTask.Yield(); // ���t���[���҂iUpdate�̂悤�ɓ����j
        }

        // �I�����������ꂽ���A�^�C�}�[�؂ꂽ�珈�����s
        if (select2D?.selectedObject != gameObject)
        {
            select2D.isSelect = false;
            select2D.selectedObject = null;
            m_isActive = true;

            Debug.Log($"{gameObject.name} �𗎂Ƃ��܂�");
        }

        isCounting = false;
    }

}
