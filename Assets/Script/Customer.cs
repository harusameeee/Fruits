using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Customer : MonoBehaviour
{
    [SerializeField] GameObject finishMask;
    private SceneChange s;
    private Basket basket;

    void Start()
    {
        s = FindObjectOfType<SceneChange>(); // SceneChangeのインスタンスを取得
        basket = FindObjectOfType<Basket>(); // Basketのインスタンスを取得
    }

    void Update()
    {
        //時間切れになったら
        if (Input.GetKeyDown(KeyCode.Space))
        {
            finishMask.gameObject.SetActive(true);

        }
        //シーン管理用のスクリプト欲しいかもめも
        if (Input.GetMouseButtonDown(0))
            SceneManager.LoadScene("ResultScene");

        // rest.text="残り" + customer.ToString()+"人";
        //rest.text=customer.ToString();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Basket") && basket != null && basket.GetIsFinish()==true)
        {

            Debug.Log("完了");
        }
    }
}
