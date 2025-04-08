using Cysharp.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FruitsSpawner : MonoBehaviour
{
    [SerializeField] Transform[] spawnPositions;
    [SerializeField] GameObject[] fruitPrefabs;

    private Dictionary<Transform, GameObject> activeFruits = new Dictionary<Transform, GameObject>();
    private bool isRespawning = false;

    void Start()
    {
        for (int i = 0; i < spawnPositions.Length; i++)
        {
            if (fruitPrefabs.Length == 0) return;

            GameObject spawnedFruit = SpawnFruitAt(spawnPositions[i]);
            activeFruits[spawnPositions[i]] = spawnedFruit;
        }
    }

    void Update()
    {
        if (!isRespawning)
        {
            foreach (var pair in activeFruits)
            {
                if (pair.Value == null)
                {
                    isRespawning = true;
                    _ = RespawnFruitAsync(pair.Key); // �񓯊��^�X�N�����s�i�߂�l�͎g��Ȃ��̂� `_ =`�j
                    break; // ��x�Ɉ��������
                }
            }
        }
    }

    private GameObject SpawnFruitAt(Transform spawnPos)
    {
        GameObject selectedFruit = fruitPrefabs[Random.Range(0, fruitPrefabs.Length)];
        return Instantiate(selectedFruit, spawnPos.position, Quaternion.identity);
    }

    private async UniTaskVoid RespawnFruitAsync(Transform spawnPos)
    {
        await UniTask.Delay(3000); // 3�b�҂i�~���b�w��j

        GameObject newFruit = SpawnFruitAt(spawnPos);
        activeFruits[spawnPos] = newFruit;
        isRespawning = false;
    }
}
