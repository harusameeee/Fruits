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
        select2D = FindObjectOfType<Select2D>(); // Select2Dを取得
    }

    void Update()
    {
        // 自分が選択されているか判定
        if (select2D?.selectedObject == gameObject)
        {
            m_time -= Time.deltaTime;
            Debug.Log(gameObject.name + " を持っています！ 残り時間: " + m_time);

            // 落とす
            if (m_time <= 0)
            {
                select2D.isSelect = false; // 選択解除
                select2D.selectedObject = null; // 選択オブジェクトリセット
                m_isActive = true;
            }
        }
        else if(!select2D.isSelect)
        {
            m_time = 3.0f; // 選択されていないときは時間リセット
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

}
