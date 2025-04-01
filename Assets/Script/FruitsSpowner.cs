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
            if (Fruit.Length == 0) return; // Fruit ���ݒ肳��Ă��Ȃ�������I��

            // �����_���ȃt���[�c��I��
            GameObject selectedFruit = Fruit[Random.Range(0, Fruit.Length)];
            // 2D�̃X�|�[���ʒu�Ƀt���[�c�𐶐�
            Instantiate(selectedFruit, SpownPositions[i].position, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        //�Đ���
        //�t���[�c���Ȃ��ꍇ�����_���ɐ���
    }
}
