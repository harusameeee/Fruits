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
    // �c��l��
    //[SerializeField] TextMeshProUGUI rest;
    // �I�������Ƃ��ɕ\������L�����o�X
    //[SerializeField] GameObject finishMask;
>>>>>>> komuro:Assets/Script/Customer.cs
    private SceneChange s;
    private Basket basket;
    // �X�e�[�g


    // �ǉ�
    // �J�X�^�}�[�X�|�i�[
    [SerializeField] CustomerSpowner spowner;
    
    void Start()
    {
        s = FindObjectOfType<SceneChange>(); // SceneChange�̃C���X�^���X���擾
        basket = FindObjectOfType<Basket>(); // Basket�̃C���X�^���X���擾
    }

    void Update()
    {
<<<<<<< HEAD:Assets/Script/Customer/Customer.cs
        //���Ԑ؂�ɂȂ�����
        if (Input.GetKeyDown(KeyCode.Space))
        {
            finishMask.gameObject.SetActive(true);

        }
        //�V�[���Ǘ��p�̃X�N���v�g�~���������߂�
        if (Input.GetMouseButtonDown(0) && finishMask.gameObject.active==true)
            SceneManager.LoadScene("ResultScene");
=======
        //if (customer <= 0)
        //{
        //    finishMask.gameObject.SetActive(true);
>>>>>>> komuro:Assets/Script/Customer.cs

        //    //�V�[���Ǘ��p�̃X�N���v�g�~���������߂�
        //    if(Input.GetKeyDown(KeyCode.Space)) 
        //    SceneManager.LoadScene("ResultScene");
        //}
        // rest.text="�c��" + customer.ToString()+"�l";
        //rest.text=customer.ToString();
<<<<<<< HEAD:Assets/Script/Customer/Customer.cs
=======


        // �ړ������灛�b�ҋ@

        // ��ʊO�ֈړ���A�폜

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
