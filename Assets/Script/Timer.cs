using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    // タイムリミット
    private float m_timeLimit;
    // 表示するテキストボックス
    [SerializeField] TextMeshProUGUI m_timerText;

    // Start is called before the first frame update
    void Start()
    {
        // 定数を入れる
        m_timeLimit = PlayOnlyData.TimeLimit;
        // テキストボックスのコンポーネントを取得
        //m_timerText = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        // 時間経過
        m_timeLimit -= Time.deltaTime;
        // 残り時間を表示
        m_timerText.text = "あと"+m_timeLimit.ToString("f0");
    }
}
