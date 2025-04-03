using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class StageSelect : MonoBehaviour
{
    public float Speed = 5f; // 移動速度
    private Transform[] childObjects; // 子オブジェクトの参照リスト
    private Vector2 m_movement; // 移動したい量
    private Vector3[] targetPositions; // 移動先の座標
    private int currentIndex = 0; // 現在の位置インデックス
    private float centerThreshold = 0.4f; // 原点付近の閾値

    void Start()
    {
        int childCount = transform.childCount;
        childObjects = new Transform[childCount];
        targetPositions = new Vector3[childCount];

        for (int i = 0; i < childCount; i++)
        {
            childObjects[i] = transform.GetChild(i); // 全ての子オブジェクトを取得
            targetPositions[i] = childObjects[i].localPosition; // 初期位置を保存
        }

        if (childObjects.Length > 1)
        {
            m_movement = childObjects[1].localPosition - childObjects[0].localPosition;
        }
        else
        {
            m_movement = Vector2.zero; // 子オブジェクトが1つ以下なら移動量は0
        }
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // 左クリックしたら
        {
            Vector3 mousePos = Input.mousePosition;
            float screenMid = Screen.width / 2f; // 画面の中央X座標
            Vector3 worldMousePos = Camera.main.ScreenToWorldPoint(mousePos);

            // 原点付近を避けるための判定
            if (Mathf.Abs(worldMousePos.x) > centerThreshold)
            {
                if (mousePos.x < screenMid)
                {
                    Move(1); // 左へ移動（movement分）
                }
                else
                {
                    Move(-1); // 右へ移動（movement分）
                }
            }
        }

        // スムーズに移動
        for (int i = 0; i < childObjects.Length; i++)
        {
            childObjects[i].localPosition = Vector3.Lerp(childObjects[i].localPosition, targetPositions[i], Speed * Time.deltaTime);
        }
    }

    void Move(int direction)
    {
        int newIndex = currentIndex - direction;
        if (newIndex < 0 || newIndex >= childObjects.Length) return; // 範囲外なら移動しない

        currentIndex = newIndex;
        for (int i = 0; i < childObjects.Length; i++)
        {
            targetPositions[i] += (Vector3)(direction * m_movement);
        }
    }
}
