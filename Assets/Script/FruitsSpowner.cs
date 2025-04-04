using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitsSpowner : MonoBehaviour
{
    [SerializeField] Transform[] spawnPositions;
    [SerializeField] GameObject[] fruitPrefabs;

    private Dictionary<Transform, GameObject> activeFruits = new Dictionary<Transform, GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < spawnPositions.Length; i++)
        {
            if (fruitPrefabs.Length == 0) return; // Fruit が設定されていなかったら終了

            // ランダムなフルーツを選択してスポーン
            GameObject spawnedFruit = SpawnFruitAt(spawnPositions[i]);
            activeFruits[spawnPositions[i]] = spawnedFruit;
        }
    }

    void Update()
    {
    }

    // 指定位置にフルーツをスポーン
    private GameObject SpawnFruitAt(Transform spawnPos)
    {
        GameObject selectedFruit = fruitPrefabs[Random.Range(0, fruitPrefabs.Length)];
        return Instantiate(selectedFruit, spawnPos.position, Quaternion.identity);
    }

    
}
