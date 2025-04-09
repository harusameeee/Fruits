using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    // �^�C�����~�b�g
    private float m_timeLimit;
    // �\������e�L�X�g�{�b�N�X
    [SerializeField] TextMeshProUGUI m_timerText;

    // �I�������Ƃ��ɕ\������L�����o�X
    [SerializeField] GameObject finishMask;

    // Start is called before the first frame update
    void Start()
    {
        // �萔������
        m_timeLimit = PlayOnlyData.TimeLimit;
    }

    // Update is called once per frame
    void Update()
    {
        // ���Ԍo��
        m_timeLimit -= Time.deltaTime;
        // �c�莞�Ԃ�\��
        m_timerText.text = "����"+m_timeLimit.ToString("f0");

        if(m_timeLimit<=0)
        {
            finishMask.SetActive(true);

            //���Ԃ�����ȏ�}�C�i�X���Ȃ��悤��
            m_timeLimit = 0;

            if (Input.GetKeyDown(KeyCode.Space))
            {
                //�V�[���ړ�
                //SceneManager.LoadScene("ResultScene");
            }

        }
    }
}
