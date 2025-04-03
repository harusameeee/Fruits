using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{

    public int m_score=0;
    [SerializeField] TextMeshProUGUI m_scoreText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        m_scoreText.text = "�Ƃ��Ă�F" + m_score.ToString();
    }

    //�c�莞�ԁ���b�_
    public void SetScore(float limitTime, int score) { m_score += (score*(int)limitTime); }
}
