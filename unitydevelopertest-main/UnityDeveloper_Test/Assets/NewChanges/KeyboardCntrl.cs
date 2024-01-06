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

public interface IGameStart
{
    void GameStart();
}

public interface IRayDetection
{
   bool DistanceCheck();
  

}
public interface ICasualJump
{
   bool EmptySpaceJump();
}


public interface IMidAir
{
   void AnimationJump();
    void StopJumpAnim();
}

public interface IJumpAnim
{
    void Jump();

  

}

public interface IStopPlayer
    {
    void StopPlayer();

    }


