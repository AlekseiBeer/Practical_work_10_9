using UnityEngine;

public class RandomForce : MonoBehaviour
{
    public float minForce = 5f;
    public float maxForce = 15f;

    private void OnCollisionEnter(Collision collision)
    {
        Rigidbody rb = collision.collider.GetComponent<Rigidbody>();

        if (rb != null)
        {
            float randomForce = Random.Range(minForce, maxForce);
            Vector3 normalDirection = collision.contacts[0].normal;
            rb.AddForce(normalDirection * randomForce, ForceMode.Impulse);
        }
    }
}