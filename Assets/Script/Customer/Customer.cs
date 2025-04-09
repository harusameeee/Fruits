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
    // �X�e�[�g
    private string m_state = "SpawnState";  // �X�|�[������̓���
    private float MOVESPEED = 5f;     // �������ւ̃X�s�[�h
    private float AMPLITUDE = 2f;     // �㉺�̐U�ꕝ
    private float FREQUENCY = 5f;     // �㉺�̑���

    private float STATEY = -4;            // �ŏ���Y���W
    private float m_time = 0;              // ����

    private int m_customerNum = 0;    // ���q����̐l��

    void Start()
    {
        s = FindObjectOfType<SceneChange>(); // SceneChange�̃C���X�^���X���擾
        basket = FindObjectOfType<Basket>(); // Basket�̃C���X�^���X���擾
    }

    void Update()
    {
        ////���Ԑ؂�ɂȂ�����
        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    finishMask.gameObject.SetActive(true);

        //}
        //�V�[���Ǘ��p�̃X�N���v�g�~���������߂�
        //if (Input.GetMouseButtonDown(0) && finishMask.gameObject.active==true)
        //    SceneManager.LoadScene("ResultScene");
        //if (customer <= 0)
        //{
        //    finishMask.gameObject.SetActive(true);

        //    //�V�[���Ǘ��p�̃X�N���v�g�~���������߂�
        //    if(Input.GetKeyDown(KeyCode.Space)) 
        //    SceneManager.LoadScene("ResultScene");
        //}
        // rest.text="�c��" + customer.ToString()+"�l";
        //rest.text=customer.ToString();

        // ����
        State(m_state);
        // ��ʊO�֏o�������
        if (!GetComponent<Renderer>().isVisible && m_state == "ExitState")
        {
            Destroy(this.gameObject);
        }

    }

    // �X�e�[�g
    private void State(string state)
    {
        switch (state)
        {
            // �X�|�[������
            case "SpawnState":
                // �o�ߎ���
                m_time += Time.deltaTime;
                // �������Ɉړ�
                float x = transform.position.x - MOVESPEED * Time.deltaTime;
                // sin�g�ɂ��㉺�ړ�
                float y = STATEY + Mathf.Abs(Mathf.Sin(m_time * FREQUENCY) * AMPLITUDE);
                // �V�����ʒu���Z�b�g
                transform.position = new Vector3(x, y, transform.position.z);
                // ����̈ʒu�܂ňړ�������X�e�[�g�ύX
                if(this.transform.position.x < 4) 
                {
                    // �ҋ@��Ԃɂ���
                    ChangeState("WaitingState");
                    transform.position = new Vector3(x, STATEY, transform.position.z); ;
                }
                break;

            // �ҋ@
            case "WaitingState":
                // �O�b�ҋ@
                AwaitWaitingState();
                break;

            // �ޏ�
            case "ExitState":
                // �o�ߎ���
                m_time += Time.deltaTime;
                // �������Ɉړ�
                float Exitx= transform.position.x + MOVESPEED * Time.deltaTime;
                // sin�g�ɂ��㉺�ړ�
                float Exity = STATEY - Mathf.Abs(Mathf.Sin(m_time * FREQUENCY) * AMPLITUDE);
                // �V�����ʒu���Z�b�g
                transform.position = new Vector3(Exitx, Exity, transform.position.z);
                break;
        }
    }

    // �ҋ@����
    async void AwaitWaitingState()
    {
        // �O�b�ҋ@
        await UniTask.Delay(TimeSpan.FromSeconds(3f));
        // �ޏꂳ����
        ChangeState("ExitState");
        // �V�������q������X�|�[��������
        if(m_customerNum == 0)
        {
            CustomerSpawner.Instance.SpawnCustomer();
            m_customerNum++;
        }

    }
    // �X�e�[�g�ύX���Ɏ��s����
    private void ChangeState(string state)
    {
        // �^�C����������
        m_time = 0;
        // �X�e�[�g�̕ύX
        m_state = state;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Basket") && basket != null && basket.GetIsFinish() == true)
        {
            //customer--;
            Debug.Log("����");
            // �ޏꂳ����
            ChangeState("ExitState");
            // �V�������q������X�|�[��������
            CustomerSpawner.Instance.SpawnCustomer();
        }
    }

}
