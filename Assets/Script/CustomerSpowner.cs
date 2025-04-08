using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CustomerSpowner : MonoBehaviour
{
	// シングルトンにする
	public static CustomerSpowner Instance { get; private set; }
    // お客さんのプレハブ
    [SerializeField] Customer m_customerPrefab;

	private void Awake()
	{
		if (Instance == null)
		{
			Instance = this;
			// ゲームオブジェクトが削除されないようにする
			//DontDestroyOnLoad(gameObject); 
		}
		else
		{
			Destroy(gameObject);
		}
	}

	// スポーンさせる
	public void SpownCustomer()
    {
        // お客さんをスポーンさせる
		Instantiate(m_customerPrefab, this.transform.position, Quaternion.identity);
	}
}
