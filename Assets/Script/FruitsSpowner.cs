using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitsSpowner : MonoBehaviour
{
    [SerializeField] Transform[] SpownPositions;
    [SerializeField] GameObject[] Fruit;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < SpownPositions.Length; i++)
        {
            if (Fruit.Length == 0) return; // Fruit が設定されていなかったら終了

            // ランダムなフルーツを選択
            GameObject selectedFruit = Fruit[Random.Range(0, Fruit.Length)];
            // 2Dのスポーン位置にフルーツを生成
            Instantiate(selectedFruit, SpownPositions[i].position, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        //再生成
        //フルーツがない場合ランダムに生成
    }
}
