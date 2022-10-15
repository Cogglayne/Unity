using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// An asteroid
/// </summary>
public class Asteroid : MonoBehaviour
{
    [SerializeField]
    Sprite asteroidSprite0;
    [SerializeField]
    Sprite asteroidSprite1;
    [SerializeField]
    Sprite asteroidSprite2;


	/// <summary>
	/// Start is called before the first frame update
	/// </summary>
	void Start()
	{
        // set random sprite for asteroid
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        int spriteNumber = Random.Range(0, 3);
        if (spriteNumber < 1)
        {
            spriteRenderer.sprite = asteroidSprite0;
        }
        else if (spriteNumber < 2)
        {
            spriteRenderer.sprite = asteroidSprite1;
        }
        else
        {
            spriteRenderer.sprite = asteroidSprite2;
        }
	}
    /// <summary>
    /// Controls movement and origin location of asteroid
    /// </summary>
    /// <param name="moveDirection"></param>
    public void Initialize(Direction direction, Vector3 location)
    {
        // sets the asteroids location to the vector parameter
        transform.position = location;
        float angle = 0;
        // sets the angle that asteroid will move in depending on the direction provided
        if (direction == Direction.Up)
        {
        angle = Random.Range(75*Mathf.Deg2Rad, 105*Mathf.Deg2Rad);
        }else if (direction == Direction.Down)
        {
        angle = Random.Range(255 * Mathf.Deg2Rad, 285 * Mathf.Deg2Rad);
        }
        else if (direction == Direction.Left)
        {
        angle = Random.Range(165 * Mathf.Deg2Rad, 195 * Mathf.Deg2Rad);
        }
        else
        {
        angle = Random.Range(-15 * Mathf.Deg2Rad, 15 * Mathf.Deg2Rad);
        }
        StartMoving(angle);
    }
    /// <summary>
    /// Applies force to asteroid
    /// </summary>
    /// <param name="angle"></param>
    public void StartMoving(float angle)
    {
        // apply impulse force to get game object moving
        const float MinImpulseForce = 1f;
        const float MaxImpulseForce = 1.5f;
        Vector2 moveDirection = new Vector2(
            Mathf.Cos(angle), Mathf.Sin(angle));
        float magnitude = Random.Range(MinImpulseForce, MaxImpulseForce);
        GetComponent<Rigidbody2D>().AddForce(
            moveDirection * magnitude,
            ForceMode2D.Impulse);
    }
    /// <summary>
    /// Asteroid collisions
    /// </summary>
    /// <param name="collision"></param>
    void OnCollisionEnter2D(Collision2D collision)
    {
       if (collision.gameObject.tag == "Bullet")
        {
            AudioManager.Play(AudioClipName.AsteroidHit);
            // destroys bullet
            Destroy(collision.gameObject);
            // checks if asteroids local scale is less than .5
            if (transform.localScale.x < .5)
            {
                // Destroys asteroid
                Destroy(this.gameObject);
            }
            else
            {
                // Makes asteroid half its current size
                float newRadius = GetComponent<CircleCollider2D>().radius / 2;
                GetComponent<CircleCollider2D>().radius = newRadius;
                float asteroidx = transform.localScale.x / 2;
                float asteroidy = transform.localScale.y / 2;
                transform.localScale = new Vector2(asteroidx, asteroidy);
                // Spawns two new asteroids and then makes them move in two random directions with random velocities
                GameObject asteroidOne = Instantiate(this.gameObject, transform.position, transform.rotation);
                asteroidOne.GetComponent<Asteroid>().StartMoving(Random.Range(0, 2 * Mathf.PI));
                GameObject asteroidTwo = Instantiate(this.gameObject, transform.position, transform.rotation);
                asteroidTwo.GetComponent<Asteroid>().StartMoving(Random.Range(0, 2 * Mathf.PI));
                // Destroys original asteroid
                Destroy(this.gameObject);
            }
        } 
    }
}
