using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Save : MonoBehaviour
{
    // Start is called before the first frame update
    public int SaveState;
    public Vector3 SavePosition;
    public Transform transform_Save;
    public Transform transform_Player;
    public GameObject SaveItself;

    private void Awake()
    {
        transform_Save.GetComponent<Transform>();
        transform_Player.GetComponent<Transform>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        SavePosition = transform_Save.position;
        SaveItself.SetActive(false);
    }
}
