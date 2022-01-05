using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController CC;
    public Animator animator;

    public float WalkSpeed = 1.0f;
    public float RotationSpeed = 50.0f;
    // Start is called before the first frame update
    void Start()
    {
        CC = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        float hInput = Input.GetAxis("Horizontal");
        float vInput = Input.GetAxis("Vertical");

        float speed = WalkSpeed;

        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = WalkSpeed * 2.0f;
        }

        if (animator == null) return;

        transform.Rotate(0.0f, hInput * RotationSpeed * Time.deltaTime, 0.0f);

        Vector3 forward =
            transform.TransformDirection(Vector3.forward).normalized;
        forward.y = 0.0f;

        CC.Move(forward * vInput * speed * Time.deltaTime);


        animator.SetFloat("PosX", 0);
        animator.SetFloat("PosY", vInput * speed / 2.0f * WalkSpeed);

       

    }
}
