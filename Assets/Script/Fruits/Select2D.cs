using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Select2D : MonoBehaviour
{
    public GameObject selectedObject = null; // �I�����ꂽ�I�u�W�F�N�g
    [SerializeField] Transform limitA; // �����̍����I�u�W�F�N�g
    [SerializeField] Transform limitB; // �����̉E���I�u�W�F�N�g
    private float minX;
    private float maxX;
    private float objectCenter;


    public bool isSelect { get; set; }

    void Start()
    {
        // limitA �� limitB �� X ���W�����Ƃɔ͈͂�ۑ�
        minX = Mathf.Min(limitA.position.x, limitB.position.x);
        maxX = Mathf.Max(limitA.position.x, limitB.position.x);
        isSelect = false;
    }

    void Update()
    {
        // ���N���b�N������I�u�W�F�N�g��I��
        if (Input.GetMouseButtonDown(0))
        {
            SelectObject();
            
        }

        // �N���b�N�����I�u�W�F�N�g�������}�E�X�Ǐ]
        if (selectedObject != null)
        {
            Vector3 mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, 0));

            float halfRange = (maxX - minX) / 2f;
            float clampedX = Mathf.Clamp(mousePos.x, objectCenter - halfRange, objectCenter + halfRange);

            selectedObject.transform.position = new Vector3(clampedX, mousePos.y, 0);
        }

        // �}�E�X�𗣂�����I������
        if (Input.GetMouseButtonUp(0))
        {      
            selectedObject = null;
            isSelect = false;
            
        }
    }

    private void SelectObject()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
        RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero);

        if (hit.collider != null && hit.collider.CompareTag("Fruit")) // �����ɓ���������
        {
            selectedObject = hit.collider.gameObject; // ���̃I�u�W�F�N�g��I��
            objectCenter = selectedObject.transform.position.x; // �I�������u�Ԃɂ����擾
            Debug.Log("�I��������");
            isSelect = true;
        }
    }
}
