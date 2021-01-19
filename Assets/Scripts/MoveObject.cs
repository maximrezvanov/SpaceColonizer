using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]//запрет на одинаковые компоненты
public class MoveObject : MonoBehaviour
{

    [SerializeField] Vector3 movePosition;
    [SerializeField][Range(0, 1)]float moveProgress;//шкала движения объекта от 0 до 1
    [SerializeField] float moveSpeed;
    public bool isRotate = false;
    Vector3 startPosition;



    void Start()
    {
        startPosition = transform.position; 
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        RotateObject();
    }

    private void Move()
    {
        Vector3 offset = movePosition * moveProgress;
        transform.position = startPosition + offset;
        moveProgress = Mathf.PingPong(Time.time * moveSpeed, 1);
    }

    private void RotateObject()
    {
        if (isRotate)
        {
            transform.Rotate(0.15f, 0.08f, 0.1f);
        }
    }

    
}
