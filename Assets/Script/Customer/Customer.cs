using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Customer : MonoBehaviour
{
<<<<<<< HEAD:Assets/Script/Customer/Customer.cs
    [SerializeField] GameObject finishMask;
=======
    // [SerializeField] int customer = 1;
    // 残り人数
    //[SerializeField] TextMeshProUGUI rest;
    // 終了したときに表示するキャンバス
    //[SerializeField] GameObject finishMask;
>>>>>>> komuro:Assets/Script/Customer.cs
    private SceneChange s;
    private Basket basket;
    // ステート


    // 追加
    // カスタマースポナー
    [SerializeField] CustomerSpowner spowner;
    
    void Start()
    {
        s = FindObjectOfType<SceneChange>(); // SceneChangeのインスタンスを取得
        basket = FindObjectOfType<Basket>(); // Basketのインスタンスを取得
    }

    void Update()
    {
<<<<<<< HEAD:Assets/Script/Customer/Customer.cs
        //時間切れになったら
        if (Input.GetKeyDown(KeyCode.Space))
        {
            finishMask.gameObject.SetActive(true);

        }
        //シーン管理用のスクリプト欲しいかもめも
        if (Input.GetMouseButtonDown(0) && finishMask.gameObject.active==true)
            SceneManager.LoadScene("ResultScene");
=======
        //if (customer <= 0)
        //{
        //    finishMask.gameObject.SetActive(true);
>>>>>>> komuro:Assets/Script/Customer.cs

        //    //シーン管理用のスクリプト欲しいかもめも
        //    if(Input.GetKeyDown(KeyCode.Space)) 
        //    SceneManager.LoadScene("ResultScene");
        //}
        // rest.text="残り" + customer.ToString()+"人";
        //rest.text=customer.ToString();
<<<<<<< HEAD:Assets/Script/Customer/Customer.cs
=======


        // 移動したら○秒待機

        // 画面外へ移動後、削除

>>>>>>> komuro:Assets/Script/Customer.cs
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Basket") && basket != null && basket.GetIsFinish()==true)
        {
<<<<<<< HEAD:Assets/Script/Customer/Customer.cs

=======
            //customer--;
>>>>>>> komuro:Assets/Script/Customer.cs
            Debug.Log("完了");
            // 新しくお客さんをスポーンさせる
            CustomerSpowner.Instance.SpownCustomer();
		}
    }

    // スポーンした後の動き
    private void SpownMovement()
    {

    }

	// フルーツをもらった後の動き

}
