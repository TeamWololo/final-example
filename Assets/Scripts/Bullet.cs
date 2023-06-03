using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody rigidbody;
    
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision other)
    {
        float randomForce = Random.Range(1.0f, 20.0f);
        float randomRadius = Random.Range(1.0f, 10.0f);
        float randomUpperWeight = Random.Range(1.0f, 3.0f);
        
        rigidbody.AddExplosionForce(randomForce, transform.position, randomRadius, randomUpperWeight, ForceMode.Impulse);
    }
}
