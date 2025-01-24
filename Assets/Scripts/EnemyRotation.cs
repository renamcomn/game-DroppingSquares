using UnityEngine;

public class EnemyRotation : MonoBehaviour
{
    public float rotationSpeed = 360f;
    // Update is called once per frame
    void Update()
    {
        // Gira o objeto continuamente no eixo X
        transform.Rotate(Vector3.right * rotationSpeed * Time.deltaTime);
    }
}
