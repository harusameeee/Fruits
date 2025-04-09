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
        select2D = FindObjectOfType<Select2D>(); // Select2Dを取得
    }

    void Update()
    {
        // 自分が選択されていて、まだタイマーが走ってなければ開始
        if (select2D?.selectedObject == gameObject && !isCounting)
        {
            StartDropTimer().Forget(); // タイマー処理を開始（非同期）
        }

        if (m_isActive)
        {
            //画面外に出るまで
            transform.position += Vector3.down * 5f * Time.deltaTime;

            if (transform.position.y < Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0)).y - 1f)
            {
                Destroy(gameObject); // 画面外に出たら消去
                m_isActive = false;
            }
        }

    }

    private async UniTaskVoid StartDropTimer()
    {
        isCounting = true;

        float timer = m_time;

        // タイマーが0より大きく、選択中である間ループ
        while (timer > 0f && select2D?.selectedObject == gameObject && select2D.isSelect)
        {
            timer -= Time.deltaTime;
            Debug.Log($"{gameObject.name} を持っています！ 残り時間: {timer:F2}");
            await UniTask.Yield(); // 毎フレーム待つ（Updateのように動く）
        }

        // 選択が解除されたか、タイマー切れたら処理実行
        if (select2D?.selectedObject != gameObject)
        {
            select2D.isSelect = false;
            select2D.selectedObject = null;
            m_isActive = true;

            Debug.Log($"{gameObject.name} を落とします");
        }

        isCounting = false;
    }

}
