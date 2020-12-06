using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace playerController
{
    public class PlayerAnimator : PlayerMotor
    {
        #region Variables                
        //Init players attributes
        public const float walkSpeed = 0.5f;
        public const float runningSpeed = 1f;
        public const float sprintSpeed = 1.5f;
        public GameObject camera;

        #endregion

        public virtual void UpdateAnimator()
        {
            GameObject gs = GameObject.FindGameObjectWithTag("GS");

            if (animator == null || !animator.enabled) return;

            //Set parameters to state machine
            animator.SetBool(AnimatorParameters.IsStrafing, camera.GetComponent<TPSCamera>().isAiming);
            animator.SetBool(AnimatorParameters.IsSprinting, isSprinting);
            animator.SetBool(AnimatorParameters.IsGrounded, isGrounded);
            animator.SetFloat(AnimatorParameters.GroundDistance, groundDistance);
            animator.SetBool(AnimatorParameters.IsDead, gs.GetComponent<GameSystem>().IsDead);

            if (isStrafing)
            {
                animator.SetFloat(AnimatorParameters.InputHorizontal, stopMove ? 0 : horizontalSpeed, strafeSpeed.animationSmooth, Time.deltaTime);
                animator.SetFloat(AnimatorParameters.InputVertical, stopMove ? 0 : verticalSpeed, strafeSpeed.animationSmooth, Time.deltaTime);
            }
            else
            {
                animator.SetFloat(AnimatorParameters.InputVertical, stopMove ? 0 : verticalSpeed, freeSpeed.animationSmooth, Time.deltaTime);
            }

            animator.SetFloat(AnimatorParameters.InputMagnitude, stopMove ? 0f : inputMagnitude, isStrafing ? strafeSpeed.animationSmooth : freeSpeed.animationSmooth, Time.deltaTime);
        }

        // Set speed to animation
        public virtual void SetAnimatorMoveSpeed(MovementSpeed speed)
        {
            Vector3 relativeInput = transform.InverseTransformDirection(moveDirection);
            verticalSpeed = relativeInput.z;
            horizontalSpeed = relativeInput.x;

            var newInput = new Vector2(verticalSpeed, horizontalSpeed);

            if (speed.walkByDefault)
                inputMagnitude = Mathf.Clamp(newInput.magnitude, 0, isSprinting ? runningSpeed : walkSpeed);
            else
                inputMagnitude = Mathf.Clamp(isSprinting ? newInput.magnitude + 0.5f : newInput.magnitude, 0, isSprinting ? sprintSpeed : runningSpeed);
        }
    }

    // Used to store Animator's parameters
    public static partial class AnimatorParameters
    {
        public static int InputHorizontal = Animator.StringToHash("InputHorizontal");
        public static int InputVertical = Animator.StringToHash("InputVertical");
        public static int InputMagnitude = Animator.StringToHash("InputMagnitude");
        public static int IsGrounded = Animator.StringToHash("IsGrounded");
        public static int IsStrafing = Animator.StringToHash("IsStrafing");
        public static int IsSprinting = Animator.StringToHash("IsSprinting");
        public static int GroundDistance = Animator.StringToHash("GroundDistance");
        public static int IsDead = Animator.StringToHash("IsDead");
    }
}

