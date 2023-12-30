using UnityEngine;

public interface IKeyboardCntrl
{
    void MoveForward();
    void MoveBackward();
    void MoveLeft();
    void MoveRight();
    
   
}

public interface IKeyboardCntrlNone
{
    void IdlePlayer();

}

public interface IGameOver
{ 
    void GameOver();

}

public interface IJumpAnim
{
    void Jump();

}



//public class KeyboardCntrl : IKeyboardCntrl
//{
//    public void Update()
//    {
//        HandleForwardInput();
//        HandleBackwardInput();
//        HandleLeftInput();
//        HandleRightInput();
//    }

//    public void HandleForwardInput()
//    {
//        if (Input.GetKey(KeyCode.W))
//        {
//            MoveForward();
//        }
//    }

//    public void HandleBackwardInput()
//    {
//        if (Input.GetKey(KeyCode.S))
//        {
//            MoveBackward();
//        }
//    }

//    public void HandleLeftInput()
//    {
//        if (Input.GetKey(KeyCode.A))
//        {
//            RotateLeft();
//        }
//    }

//    public void HandleRightInput()
//    {
//        if (Input.GetKey(KeyCode.D))
//        {
//            RotateRight();
//        }
//    }

//    public void MoveForward()
//    {

//    }

//    public void MoveBackward()
//    {

//    }

//    public void RotateLeft()
//    {

//    }

//    public void RotateRight()
//    {

//    }
//



//}