using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Customer : MonoBehaviour
{
    // [SerializeField] int customer = 1;
    // �c��l��
    //[SerializeField] TextMeshProUGUI rest;
    // �I�������Ƃ��ɕ\������L�����o�X
    //[SerializeField] GameObject finishMask;
    private SceneChange s;
    private Basket basket;
    // �X�e�[�g

    
    void Start()
    {
        s = FindObjectOfType<SceneChange>(); // SceneChange�̃C���X�^���X���擾
        basket = FindObjectOfType<Basket>(); // Basket�̃C���X�^���X���擾
    }

    void Update()
    {
        //if (customer <= 0)
        //{
        //    finishMask.gameObject.SetActive(true);

        //    //�V�[���Ǘ��p�̃X�N���v�g�~���������߂�
        //    if(Input.GetKeyDown(KeyCode.Space)) 
        //    SceneManager.LoadScene("ResultScene");
        //}
        // rest.text="�c��" + customer.ToString()+"�l";
        //rest.text=customer.ToString();


        // �ړ������灛�b�ҋ@

        // ��ʊO�ֈړ���A�폜

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Basket") && basket != null && basket.GetIsFinish()==true)
        {
            //customer--;
            Debug.Log("����");
            // �V�������q������X�|�[��������
            CustomerSpowner.Instance.SpownCustomer();
		}
    }

    // �X�|�[��������̓���
    private void SpownMovement()
    {

    }

	// �t���[�c�����������̓���

}
