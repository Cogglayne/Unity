using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
/// <summary>
/// player paddle
/// </summary>
public class HumanPaddle : Paddle
{
    /// <summary>
    /// Start is called before the first frame update
    /// </summary>
    public override void Start()
    {
        base.Start();
    }

    /// <summary>
    /// Human player paddle movement
    /// </summary>
    /// <exception cref="System.NotImplementedException"></exception>
    protected override void UpdatePaddle()
    {
        // paddle movement keys depend on which side of the screen the paddle is at
        float input;
        if (ss == ScreenSide.Left)
        {
            input = Input.GetAxis("LeftPaddle");
        }
        else
        {
            input = Input.GetAxis("RightPaddle");
        }
        PaddleMove(input);
    }
    /// <summary>
    /// moves the human paddle
    /// </summary>
    /// <param name="amount"></param>
    /// <exception cref="System.NotImplementedException"></exception>
    protected override void PaddleMove(float input)
    {
        if (input != 0)
        {
            paddleVector = paddleBody.position;
            paddleVector.y += input * ConfigurationUtils.PaddleMoveUnitsPerSecond * Time.deltaTime;
            paddleVector.y = CalculateClampedY(paddleVector.y);
            paddleBody.MovePosition(paddleVector);
        }
    }
}
