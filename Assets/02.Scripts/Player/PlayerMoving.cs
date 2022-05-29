using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoving : MonoBehaviour
{
    // 오브젝트와 이 스크립트에서 사용하는 함수
    private CharacterController controller; // 캐릭터의 움직임 컨트롤러 컴포넌트
    private Animator animator;  // 캐릭터 애니메이션 컴포넌트
    private Vector3 moveDirection;  // 움직이는 방향 저장용 벡터
    private float mouseSpeed;   // 마우스 회전 속도

    void Start()
    {
        // 기본 값 설정
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        moveDirection = Vector3.zero;
        mouseSpeed = 6f; 
    }

    void Update()
    {
        if(Setting.GameIsPaused == false)
        {
            mouseSpeed = 0f;
            // 마우스 회전 설정
            transform.Rotate(0f, Input.GetAxis("Mouse X") * mouseSpeed, 0f, Space.World);
        }
        
        else
        {
            mouseSpeed = 6f;
            // 마우스 회전 설정
            transform.Rotate(0f, Input.GetAxis("Mouse X") * mouseSpeed, 0f, Space.World);
        }

        // x, z 움직임 Input
        float x = Input.GetAxis("Horizontal");
        float y = -300f * Time.deltaTime; 
        float z = Input.GetAxis("Vertical");

        // 벡터 형식으로 변환 및 걷는 속도 곱
        moveDirection = (transform.right * x + transform.up * y + transform.forward * z) * PlayerStats.walkSpeed;

        // 최종 컨트롤러로 움직임
        controller.Move(moveDirection * Time.deltaTime);

        // 애니메이션 모션 설정
        if (z > 0)  // 앞으로
            animator.SetInteger("MoveType", 1);
        else if (z < 0) // 뒤로
            animator.SetInteger("MoveType", 2);
        else if (x < 0) // 왼쪽으로
            animator.SetInteger("MoveType", 3);
        else if (x > 0) // 오른쪽으로
            animator.SetInteger("MoveType", 4);
        else    // 멈춤
            animator.SetInteger("MoveType", 0);
    }
}
