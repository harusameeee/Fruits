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

        m_scoreText.text = "とくてん：" + m_score.ToString();
    }

    //残り時間＊基礎点
    public void SetScore(float limitTime, int score) { m_score += (score*(int)limitTime); }
}
