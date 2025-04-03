using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class StageSelect : MonoBehaviour
{
    public float Speed = 5f; // �ړ����x
    private Transform[] childObjects; // �q�I�u�W�F�N�g�̎Q�ƃ��X�g
    private Vector2 m_movement; // �ړ���������
    private Vector3[] targetPositions; // �ړ���̍��W
    private int currentIndex = 0; // ���݂̈ʒu�C���f�b�N�X
    private float centerThreshold = 0.4f; // ���_�t�߂�臒l

    void Start()
    {
        int childCount = transform.childCount;
        childObjects = new Transform[childCount];
        targetPositions = new Vector3[childCount];

        for (int i = 0; i < childCount; i++)
        {
            childObjects[i] = transform.GetChild(i); // �S�Ă̎q�I�u�W�F�N�g���擾
            targetPositions[i] = childObjects[i].localPosition; // �����ʒu��ۑ�
        }

        if (childObjects.Length > 1)
        {
            m_movement = childObjects[1].localPosition - childObjects[0].localPosition;
        }
        else
        {
            m_movement = Vector2.zero; // �q�I�u�W�F�N�g��1�ȉ��Ȃ�ړ��ʂ�0
        }
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // ���N���b�N������
        {
            Vector3 mousePos = Input.mousePosition;
            float screenMid = Screen.width / 2f; // ��ʂ̒���X���W
            Vector3 worldMousePos = Camera.main.ScreenToWorldPoint(mousePos);

            // ���_�t�߂�����邽�߂̔���
            if (Mathf.Abs(worldMousePos.x) > centerThreshold)
            {
                if (mousePos.x < screenMid)
                {
                    Move(1); // ���ֈړ��imovement���j
                }
                else
                {
                    Move(-1); // �E�ֈړ��imovement���j
                }
            }
        }

        // �X���[�Y�Ɉړ�
        for (int i = 0; i < childObjects.Length; i++)
        {
            childObjects[i].localPosition = Vector3.Lerp(childObjects[i].localPosition, targetPositions[i], Speed * Time.deltaTime);
        }
    }

    void Move(int direction)
    {
        int newIndex = currentIndex - direction;
        if (newIndex < 0 || newIndex >= childObjects.Length) return; // �͈͊O�Ȃ�ړ����Ȃ�

        currentIndex = newIndex;
        for (int i = 0; i < childObjects.Length; i++)
        {
            targetPositions[i] += (Vector3)(direction * m_movement);
        }
    }
}
