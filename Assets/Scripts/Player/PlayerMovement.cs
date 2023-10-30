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
        // �������� ������� �������� ������ ��� �������� �� ����������� � ���������
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // ������������ ����� ������� ������
        Vector3 movement = new Vector3(horizontalInput, 0, verticalInput) * moveSpeed;

        // ��������� �������� ����� Rigidbody
        rb.velocity = new Vector3(movement.x, rb.velocity.y, movement.z);

        // ������������� �������� isRunning � ����������� �� �������� ��������
        isRunning = Mathf.Abs(horizontalInput) > 0 || Mathf.Abs(verticalInput) > 0;

        // ������������� �������� �������� � ���������
        animator.SetBool("isRunning", isRunning);

        if (isRunning)
        {
            // ������������ ������ � ������� ��������
            Vector3 direction = new Vector3(horizontalInput, 0, verticalInput);
            transform.forward = direction;
        }
    }
}
