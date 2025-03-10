using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]

public class ScreenWrap : MonoBehaviour
{
    public Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        Vector3 ScreenPosition = Camera.main.WorldToScreenPoint(transform.position);
        float RightSideOfScreenInWorld = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height)).x;
        float LeftSideOfScreenInWorld = Camera.main.ScreenToWorldPoint(new Vector2(0f, 0f)).x;
        float TopSideOfScreenInWorld = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height)).y;
        float BottomSideOfScreenInWorld = Camera.main.ScreenToWorldPoint(new Vector2(0f, 0f)).y;
        if (transform.position.y <=BottomSideOfScreenInWorld -16.0f &&rb.tag == "Left")
        {
            transform.position = new Vector3(LeftSideOfScreenInWorld, TopSideOfScreenInWorld + 8.0f,0);
        }
        if (transform.position.y <= BottomSideOfScreenInWorld - 16.0f && rb.tag == "Right")
        {
            transform.position = new Vector3(RightSideOfScreenInWorld, TopSideOfScreenInWorld + 8.0f, 0);
        }
        if (rb.tag == "Left")
        {
            transform.position = new Vector3(LeftSideOfScreenInWorld+0.2f,transform.position.y,0);
        }
        if (rb.tag == "Right")
        {
            transform.position = new Vector3(RightSideOfScreenInWorld-0.2f, transform.position.y, 0);
        }
        rb.velocity = new Vector2(0f, -5f);

    }

  
}
