using UnityEngine;

public class Gravity_One : MonoBehaviour
{

    float health = 10f;
    bool Togglegravity = true;
    float gravityScale;
    Rigidbody gravitybody;
    static float globalGravity = -9.81f;

    void Start()
    {
        gravitybody = GetComponent<Rigidbody>();
        gravitybody.useGravity = true;
    }

    void Update()
    {
        Vector3 gravity = globalGravity * gravityScale * Vector3.up;
        gravitybody.AddForce(gravity, ForceMode.Acceleration);
    }

    public void TakeDamage(float amount)
    {
        health -= amount;
        if (health <= 0f)
        {
            GravityGun();
        }
    }

    void GravityGun()
    {
        if (Togglegravity == true)
        {
            gravityScale = -5.0f;
            Togglegravity = false;
        }
        else
        {
            gravityScale = 5.0f;
            Togglegravity = true;
        }

    }
}