using Sirenix.OdinInspector;
using UnityEngine;


[RequireComponent(typeof(CharacterController),typeof(ThirdPersonController))]

public class CAnimatorController : MonoBehaviour
{
    [FoldoutGroup("References")]
    public InputSystem_Actions inputs;
    [FoldoutGroup("References")]
    public CharacterController controller;
    [FoldoutGroup("References")]
    public ThirdPersonController thirdPersonController;
    [FoldoutGroup("References")]
    public Animator animator;

    private void Awake()
    {
        inputs = new();
        thirdPersonController = GetComponent<ThirdPersonController>();
        controller = GetComponent<CharacterController>();
       
    }
    private void OnEnable()
    {
        inputs.Enable();

        inputs.Player.Move.performed += ctx =>
        {
            animator.SetFloat("MoveX", ctx.ReadValue<Vector2>().x);
            animator.SetFloat("MoveY", ctx.ReadValue<Vector2>().y);
        };

        inputs.Player.Move.canceled += ctx =>
        {
            animator.SetFloat("MoveX", 0);
            animator.SetFloat("MoveY", 0);
        };


        inputs.Player.Jump.started += ctx => animator.SetTrigger("OnJump");

        inputs.Player.Sprint.started += ctx => animator.SetBool("IsRunning",true);
        inputs.Player.Sprint.canceled += ctx => animator.SetBool("IsRunning", false);

        inputs.Player.Aim.started += ctx => animator.SetBool("IsAiming", true);
        inputs.Player.Aim.canceled += ctx => animator.SetBool("IsAiming", false);

    }
    void Update()
    {
        animator.SetBool("IsGrounded", controller.isGrounded);
       
    }
}
