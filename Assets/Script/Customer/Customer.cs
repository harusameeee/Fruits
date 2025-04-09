using Cysharp.Threading.Tasks;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Customer : MonoBehaviour
{
    private SceneChange s;
    private Basket basket;
    // ステート
    private string m_state = "SpawnState";  // スポーン直後の動き
    private float MOVESPEED = 5f;     // 左方向へのスピード
    private float AMPLITUDE = 2f;     // 上下の振れ幅
    private float FREQUENCY = 5f;     // 上下の速さ

    private float STATEY = -4;            // 最初のY座標
    private float m_time = 0;              // 時間

    private int m_customerNum = 0;    // お客さんの人数

    void Start()
    {
        s = FindObjectOfType<SceneChange>(); // SceneChangeのインスタンスを取得
        basket = FindObjectOfType<Basket>(); // Basketのインスタンスを取得
    }

    void Update()
    {
        ////時間切れになったら
        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    finishMask.gameObject.SetActive(true);

        //}
        //シーン管理用のスクリプト欲しいかもめも
        //if (Input.GetMouseButtonDown(0) && finishMask.gameObject.active==true)
        //    SceneManager.LoadScene("ResultScene");
        //if (customer <= 0)
        //{
        //    finishMask.gameObject.SetActive(true);

        //    //シーン管理用のスクリプト欲しいかもめも
        //    if(Input.GetKeyDown(KeyCode.Space)) 
        //    SceneManager.LoadScene("ResultScene");
        //}
        // rest.text="残り" + customer.ToString()+"人";
        //rest.text=customer.ToString();

        // 動き
        State(m_state);
        // 画面外へ出たら消去
        if (!GetComponent<Renderer>().isVisible && m_state == "ExitState")
        {
            Destroy(this.gameObject);
        }

    }

    // ステート
    private void State(string state)
    {
        switch (state)
        {
            // スポーン直後
            case "SpawnState":
                // 経過時間
                m_time += Time.deltaTime;
                // 左方向に移動
                float x = transform.position.x - MOVESPEED * Time.deltaTime;
                // sin波による上下移動
                float y = STATEY + Mathf.Abs(Mathf.Sin(m_time * FREQUENCY) * AMPLITUDE);
                // 新しい位置をセット
                transform.position = new Vector3(x, y, transform.position.z);
                // 特定の位置まで移動したらステート変更
                if(this.transform.position.x < 4) 
                {
                    // 待機状態にする
                    ChangeState("WaitingState");
                    transform.position = new Vector3(x, STATEY, transform.position.z); ;
                }
                break;

            // 待機
            case "WaitingState":
                // 三秒待機
                AwaitWaitingState();
                break;

            // 退場
            case "ExitState":
                // 経過時間
                m_time += Time.deltaTime;
                // 左方向に移動
                float Exitx= transform.position.x + MOVESPEED * Time.deltaTime;
                // sin波による上下移動
                float Exity = STATEY - Mathf.Abs(Mathf.Sin(m_time * FREQUENCY) * AMPLITUDE);
                // 新しい位置をセット
                transform.position = new Vector3(Exitx, Exity, transform.position.z);
                break;
        }
    }

    // 待機時間
    async void AwaitWaitingState()
    {
        // 三秒待機
        await UniTask.Delay(TimeSpan.FromSeconds(3f));
        // 退場させる
        ChangeState("ExitState");
        // 新しくお客さんをスポーンさせる
        if(m_customerNum == 0)
        {
            CustomerSpawner.Instance.SpawnCustomer();
            m_customerNum++;
        }

    }
    // ステート変更時に実行する
    private void ChangeState(string state)
    {
        // タイムを初期化
        m_time = 0;
        // ステートの変更
        m_state = state;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Basket") && basket != null && basket.GetIsFinish() == true)
        {
            //customer--;
            Debug.Log("完了");
            // 退場させる
            ChangeState("ExitState");
            // 新しくお客さんをスポーンさせる
            CustomerSpawner.Instance.SpawnCustomer();
        }
    }

}
