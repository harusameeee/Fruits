using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class Player : MonoBehaviour
{
    //èâä˙ç¿ïW
    static Vector2 FirstPosition = new Vector2(-8, -4);

    //à⁄ìÆîÕàÕêßå¿
    [SerializeField] GameObject leftLimit,rightLimit;
    float m_positionX = 0.0f;

    float speed = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = FirstPosition;
        m_positionX=transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        m_positionX = transform.position.x;
        PositionLimit();

        if (Input.GetKey(KeyCode.A))
        {
            transform.position -= speed * transform.right * Time.deltaTime;
        }
        else if(Input.GetKey(KeyCode.D))
        {
           transform.position += speed * transform.right * Time.deltaTime;
        }
    }

    private void PositionLimit()
    {
        float leftPos = leftLimit.transform.position.x;
        float rightPos = rightLimit.transform.position.x;

        if (m_positionX <= leftPos)
        {
            m_positionX = leftPos;
        }
        if (m_positionX >= rightPos)
        {
            m_positionX = rightPos;
        }
        transform.position = new Vector2(m_positionX, -4);
    }
}
