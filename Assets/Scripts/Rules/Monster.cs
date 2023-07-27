using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    // Start is called before the first frame update
    public PlayerMove playerMove;
    public GameObject Itself;
    private void Awake()
    {
        playerMove.GetComponent<PlayerMove>();
        Itself.GetComponent<GameObject>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        playerMove.RushAble = true;
        Destroy(Itself);
    }
}
