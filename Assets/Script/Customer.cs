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
        s = FindObjectOfType<SceneChange>(); // SceneChange�̃C���X�^���X���擾
        basket = FindObjectOfType<Basket>(); // Basket�̃C���X�^���X���擾
    }

    void Update()
    {
        //���Ԑ؂�ɂȂ�����
        if (Input.GetKeyDown(KeyCode.Space))
        {
            finishMask.gameObject.SetActive(true);

        }
        //�V�[���Ǘ��p�̃X�N���v�g�~���������߂�
        if (Input.GetMouseButtonDown(0))
            SceneManager.LoadScene("ResultScene");

        // rest.text="�c��" + customer.ToString()+"�l";
        //rest.text=customer.ToString();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Basket") && basket != null && basket.GetIsFinish()==true)
        {

            Debug.Log("����");
        }
    }
}
