using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.Windows;
/// <summary>
/// a computer paddle
/// </summary>
public class ComputerPaddle : Paddle
{
    GameObject target = null;
    /// <summary>
    /// Start is called before the first frame update
    /// </summary>
    public override void Start()
    {
        base.Start();
    }
    /// <summary>
    /// movement for a computer paddle
    /// </summary>
    /// <exception cref="System.NotImplementedException"></exception>
    protected override void UpdatePaddle()
    {
        GameObject[] balls = GameObject.FindGameObjectsWithTag("Ball");
        target = null;
        float distance = Mathf.Infinity;
        // finds the closest ball that is heading towards the computer paddle
        for (int i = 0; i < balls.Length; i++)
        {
            Vector3 diff = balls[i].transform.position - transform.position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance && balls[i].GetComponent<Rigidbody2D>().velocity.x > 0)
            {
                target = balls[i];
                distance = curDistance;
            }

        }
        if(target != null)
        {
            // passes the targets y location 
            if(transform.position.y != target.transform.position.y)
            {
                PaddleMove(target.transform.position.y);
            }
        }
    }
    /// <summary>
    /// move the computer paddle
    /// </summary>
    /// <param name="amount"></param>
    /// <exception cref="System.NotImplementedException"></exception>
    protected override void PaddleMove(float input)
    {
        if(input != 0)
        {
            // clamps the computer paddle
            input = CalculateClampedY(input);
            // moves the computer paddle to the target 
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(6.5f, input), (ConfigurationUtils.BallImpulseForce * Time.deltaTime));
        }
    }
}
