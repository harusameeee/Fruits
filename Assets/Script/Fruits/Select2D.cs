using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Select2D : MonoBehaviour
{
    public GameObject selectedObject = null; // 選択されたオブジェクト
    [SerializeField] Transform limitA; // 制限の左側オブジェクト
    [SerializeField] Transform limitB; // 制限の右側オブジェクト
    private float minX;
    private float maxX;
    private float objectCenter;


    public bool isSelect { get; set; }

    void Start()
    {
        // limitA と limitB の X 座標をもとに範囲を保存
        minX = Mathf.Min(limitA.position.x, limitB.position.x);
        maxX = Mathf.Max(limitA.position.x, limitB.position.x);
        isSelect = false;
    }

    void Update()
    {
        // 左クリックしたらオブジェクトを選択
        if (Input.GetMouseButtonDown(0))
        {
            SelectObject();
            
        }

        // クリックしたオブジェクトだけをマウス追従
        if (selectedObject != null)
        {
            Vector3 mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, 0));

            float halfRange = (maxX - minX) / 2f;
            float clampedX = Mathf.Clamp(mousePos.x, objectCenter - halfRange, objectCenter + halfRange);

            selectedObject.transform.position = new Vector3(clampedX, mousePos.y, 0);
        }

        // マウスを離したら選択解除
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

        if (hit.collider != null && hit.collider.CompareTag("Fruit")) // 何かに当たったら
        {
            selectedObject = hit.collider.gameObject; // そのオブジェクトを選択
            objectCenter = selectedObject.transform.position.x; // 選択した瞬間にだけ取得
            Debug.Log("選択したよ");
            isSelect = true;
        }
    }
}
