using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Takes care of the movement of one part of our machines. It takes two animations, forward and backward, which must be an exact mirror of each other and no looping.
/// The animator must NOT have ApplyRootMotion. You must call UpdateHandler every frame. Likewise, you must subscribe the MoveForward, MoveBackward and NoMove functions to your desired events.
/// Make sure that all the animations on each layer have a speed multiplier named LayerSpeedMult + layer.
/// Finally, be sure to update the isCollidingGround flag properly
/// </summary>
public class AnimationHandler
{
    public static string LAYER_SPEED_MULT_TEMPLATE = "LayerSpeedMult"; //Append the number of the layer at the end to get the name of the parameter
    public Animator animator;
    public string fwdAnim;
    public string backAnim;
    public int layer;
    public bool isCollidingGround;

    private float fwdAnimTime;
    private float backAnimTime;

    public bool isDebugging = true; //For debugging purposes
    private string debugOutput;


    //Without debug
    public AnimationHandler(Animator animator, string fwdAnim, string backAnim, int layer)
    {
        this.animator = animator;
        this.fwdAnim = fwdAnim;
        this.backAnim = backAnim;
        this.layer = layer;
        this.UpdateHandler();
    }

    public void UpdateHandler()
    {
        AnimationUtility.UpdateAnimationProgress(animator, layer, fwdAnim, backAnim, ref fwdAnimTime, ref backAnimTime);
    }

    public void MoveForward() 
    {

        animator.SetFloat(LAYER_SPEED_MULT_TEMPLATE + layer, 1);
        AnimationUtility.ChangeAnimatorState(animator, fwdAnim, layer, fwdAnimTime);
        
        
    }

    public void MoveBackward()
    {
        if (!isCollidingGround)
        {  
            animator.SetFloat(LAYER_SPEED_MULT_TEMPLATE + layer, 1);
            AnimationUtility.ChangeAnimatorState(animator, backAnim, layer, backAnimTime);
        }
        else
        {
            animator.SetFloat(LAYER_SPEED_MULT_TEMPLATE + layer, 0);
        }
      
    }

    public void NoMove()
    {
        animator.SetFloat(LAYER_SPEED_MULT_TEMPLATE + layer, 0);
    }

    public void Debug(ref string output)
    {
        output = $"Forward:{fwdAnimTime}\n" +
            $"Backward: {backAnimTime}\n" +
            $"Ground: {isCollidingGround}";
    }
}