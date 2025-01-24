using UnityEngine;

public class Player : MonoBehaviour
{
    private Quaternion targetRotation;
    private Camera mainCamera;
    private float rotationSpeed = 430f;
    
    void Start()
    {
        mainCamera = Camera.main;
        targetRotation = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Detecta clique do botão esquerdo do mouse
        {
            // Obtém a posição do mouse na tela
            Vector3 mousePosition = Input.mousePosition;

            // Obtém a posição do objeto na tela
            Vector3 objectScreenPosition = mainCamera.WorldToScreenPoint(transform.position);

            // Verifica se o clique foi à direita ou à esquerda do objeto
            if (mousePosition.x > objectScreenPosition.x + 50)
            {
                // Clique à direita do objeto
                targetRotation *= Quaternion.Euler(0f, 0f, -90f);
            }
            else if(mousePosition.x < objectScreenPosition.x - 50)
            {
                // Clique à esquerda do objeto
                targetRotation *= Quaternion.Euler(0f, 0f, 90f);
            }
        }

        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }
}
