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

    // Start is called before the first frame update
    void Start()
    {
        // �萔������
        m_timeLimit = PlayOnlyData.TimeLimit;
        // �e�L�X�g�{�b�N�X�̃R���|�[�l���g���擾
        //m_timerText = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        // ���Ԍo��
        m_timeLimit -= Time.deltaTime;
        // �c�莞�Ԃ�\��
        m_timerText.text = "����"+m_timeLimit.ToString("f0");
    }
}
