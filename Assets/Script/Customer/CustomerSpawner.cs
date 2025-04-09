using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CustomerSpawner : MonoBehaviour
{
	// シングルトンにする
	public static CustomerSpawner Instance { get; private set; }
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
	public void SpawnCustomer()
    {
        // お客さんをスポーンさせる
		Instantiate(m_customerPrefab, this.transform.position, Quaternion.identity);
	}
}
