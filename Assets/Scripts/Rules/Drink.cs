using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drink : MonoBehaviour
{
    // Start is called before the first frame update
    public bool isDoubleJump;
    public GameObject itself;

    private void OnTriggerEnter2D(Collider2D other)
    {
        isDoubleJump = true;
        Destroy(itself);
    }
}
