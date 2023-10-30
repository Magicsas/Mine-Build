using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Animator animator;
    private bool isRunning = false;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // ѕолучаем входные значени€ клавиш дл€ движени€ по горизонтали и вертикали
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // –ассчитываем новую позицию игрока
        Vector3 movement = new Vector3(horizontalInput, 0, verticalInput) * moveSpeed;

        // ѕримен€ем движение через Rigidbody
        rb.velocity = new Vector3(movement.x, rb.velocity.y, movement.z);

        // ”станавливаем значение isRunning в зависимости от скорости движени€
        isRunning = Mathf.Abs(horizontalInput) > 0 || Mathf.Abs(verticalInput) > 0;

        // ”станавливаем параметр анимации в аниматоре
        animator.SetBool("isRunning", isRunning);

        if (isRunning)
        {
            // ѕоворачиваем игрока в сторону движени€
            Vector3 direction = new Vector3(horizontalInput, 0, verticalInput);
            transform.forward = direction;
        }
    }
}
