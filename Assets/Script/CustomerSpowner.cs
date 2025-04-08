using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CustomerSpowner : MonoBehaviour
{
	// �V���O���g���ɂ���
	public static CustomerSpowner Instance { get; private set; }
    // ���q����̃v���n�u
    [SerializeField] Customer m_customerPrefab;

	private void Awake()
	{
		if (Instance == null)
		{
			Instance = this;
			// �Q�[���I�u�W�F�N�g���폜����Ȃ��悤�ɂ���
			//DontDestroyOnLoad(gameObject); 
		}
		else
		{
			Destroy(gameObject);
		}
	}

	// �X�|�[��������
	public void SpownCustomer()
    {
        // ���q������X�|�[��������
		Instantiate(m_customerPrefab, this.transform.position, Quaternion.identity);
	}
}
