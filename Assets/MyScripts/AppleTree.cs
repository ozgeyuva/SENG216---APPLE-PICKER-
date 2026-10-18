using System;
using UnityEngine;
using Random = System.Random;

public class AppleTree : MonoBehaviour
{
    [SerializeField] private Transform appleSpawnPoint;
    public float speed = 5f;
    public float leftAndRightEdge = 10f;
    public float changeDirChange = 0.1f;
    public GameObject applePrefab;
    public float appleDropDelay = 1f;
    

    private void Update()
    {
        Vector3 pos = transform.position;
        pos.x += speed * Time.deltaTime;
        transform.position = pos;

        if (pos.x > leftAndRightEdge)
        {
            speed = -Mathf.Abs(speed);
        }
        else if (pos.x < -leftAndRightEdge)
        {
            speed = Mathf.Abs(speed);
            
        }

        if (UnityEngine.Random.value < changeDirChange * Time.deltaTime)
        {
            speed *= -1;
        }
        
    }
    void Start()
    {
        InvokeRepeating(nameof(DropApple), appleDropDelay, appleDropDelay);
    }

    void DropApple()
    {
        if (applePrefab != null && appleSpawnPoint != null)
        {
            Instantiate(applePrefab, appleSpawnPoint.position, Quaternion.identity);
        }
    }
}
