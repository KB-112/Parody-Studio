using UnityEngine;

public class PlayerAnimationController : MonoBehaviour, IKeyboardCntrl,IKeyboardCntrlNone, IJumpAnim
{
    [SerializeField] private Animator spaceBoy;
   
    
    public void MoveForward()
    {
        spaceBoy.SetBool("isRunning", true);
    }

    public void MoveBackward()
    {
        spaceBoy.SetBool("isRunning", true);
    }

    public void MoveLeft()
    {
        spaceBoy.SetBool("isRunning", true);
    }

    public void MoveRight()
    {
        spaceBoy.SetBool("isRunning", true);
    }

    public void IdlePlayer()
    {
        if (!Input.anyKey)
        {
            spaceBoy.SetBool("isRunning", false);
           
        }
        if (!Input.anyKey || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D)|| Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.W))
        {
            spaceBoy.SetBool("isRunning", false);
            spaceBoy.SetBool("isJump", false);
        }

    }
    public void Jump()
    {
        spaceBoy.SetBool("isJump", true);
    }
}
