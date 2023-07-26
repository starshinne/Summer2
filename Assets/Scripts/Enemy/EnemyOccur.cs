using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
public class EnemyOccur : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Enemy1;
    public GameObject NewEnemy;
    public Vector3 RandomPosotion;
    public Vector3 BeforePosition;
    public Transform Player;
    public float EveryTime;
    private void Awake()
    {
        Enemy1.GetComponent<GameObject>();
        Player.GetComponent<Transform>();
        InvokeRepeating("BornEnemy", 5.0f, EveryTime);
    }
    private void Update()
    {

        BeforePosition = new Vector3(Player.position.x + Random.insideUnitCircle.x * 40, Player.position.y + Random.insideUnitCircle.y * 40, 0);
        if (BeforePosition.x < 30)
        {
            BeforePosition.x = BeforePosition.x + 30;
        }
        if (BeforePosition.y < 25)
        {
            BeforePosition.y = BeforePosition.y + 25;
        }
        RandomPosotion = BeforePosition;
    }

    private void BornEnemy()
    {   Debug.Log(2);
        NewEnemy = Instantiate(Enemy1, RandomPosotion, Quaternion.identity);
        NewEnemy.transform.position = RandomPosotion;
        NewEnemy.GetComponent<Enemy1Data>().state = (int)((Random.value * 100) % 4 + 1);
        NewEnemy.GetComponent<AIPath>().enabled = true;
    }
}
