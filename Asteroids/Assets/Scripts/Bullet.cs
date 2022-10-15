using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Controls bullet movment
/// </summary>
public class Bullet : MonoBehaviour
{
    Timer timer;
    float bulletLifeTime = 2f;
    /// <summary>
    /// Start is called before the first frame update
    /// </summary>
    void Start()
    {
        timer = this.gameObject.AddComponent<Timer>();
        timer.Duration = bulletLifeTime;
        timer.Run();
    }
    /// <summary>
    /// Update is called once per frame
    /// </summary>
    void Update()
    {
        // destroys bullet after 2 seconds
        if (timer.Finished)
        {
            Destroy(this.gameObject);
        }
    }
    /// <summary>
    /// Applies force to bullet
    /// </summary>
    /// <param name="vector"></param>
    public void ApplyForce(Vector2 vector)
    {
        const float bulletMagnitude = 10;
        GetComponent<Rigidbody2D>().AddForce(vector * bulletMagnitude, ForceMode2D.Impulse);
    }
}
