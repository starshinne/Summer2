using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DownBorder : MonoBehaviour
{
    // Start is called before the first frame update
    public Save save;
    public Vector3 SavePositionl;
    private void OnCollisionEnter2D(Collision2D other)
    {
        save.transform_Player.position = SavePositionl;
    }
}
