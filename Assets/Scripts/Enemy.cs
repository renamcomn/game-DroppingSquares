using UnityEngine;

public class Enemy : MonoBehaviour
{

    public GameManager gameManager;
    void Start() {
        if (gameManager == null) {
            gameManager = FindFirstObjectByType<GameManager>();  // Atribui automaticamente o GameManager se não estiver atribuído
        }
    }

    void OnMouseDown() {
        if(gameObject.CompareTag("special")) {
            Destroy(gameObject);
            gameManager.IncrementPoints(5);
        }
        
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        // Chama o método do GameManager para verificar e destruir
        GameManager.Instance.DestroyEnemyIfTagMatches(gameObject, collision.gameObject);
    }
    
}
