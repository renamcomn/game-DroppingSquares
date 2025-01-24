using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public TextMeshProUGUI scoreText;
    public int points = 0;

     private void Awake()
    {
        // Garante que só existe um GameManager ativo
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Mantém o GameManager entre cenas
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Método para destruir inimigos com base na tag
    public void DestroyEnemyIfTagMatches(GameObject enemy, GameObject colliderObject)
    {
        if (enemy.CompareTag(colliderObject.tag))
        {
            Destroy(enemy);
            IncrementPoints(1);
        } else {
            GameOver();
        }
    }

    public void IncrementPoints(int pointsToAdd) {
        // Incrementa os pontos
        points += pointsToAdd; 
        scoreText.text = points.ToString();
    }

    public void GameOver() {
        // Exibe a mensagem de Game Over
        Debug.Log("Game Over! Pontuação: " + points);
    }
}
