using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : MonoBehaviour
{
    private bool m_isActive = false;
    Rigidbody2D rb ;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    m_isActive=true;
        //}

        rb.simulated = true;
    }

    public void SetisActive(bool active) { m_isActive = active; }
}
