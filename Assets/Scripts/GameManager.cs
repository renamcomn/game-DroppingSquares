using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public TextMeshProUGUI scoreText;
    public AudioSource audioSource; 
    public AudioClip pointSound;    // Som ao marcar ponto
    public AudioClip gameOverSound; // Som de Game Over
    public float basePitch = 1f; // Pitch inicial do som
    public float pitchIncrement = 0.1f; // Quanto o tom aumenta por ponto
    public float maxPitch = 2f; // Limite máximo do pitch
    private float currentPitch; // Pitch atual
    public int points = 0;

     private void Awake()
    {
        currentPitch = basePitch;
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
            currentPitch += pitchIncrement;
            if (currentPitch > maxPitch)
            {
                currentPitch = basePitch; // Reseta o pitch para o inicial
            }

            audioSource.pitch = currentPitch;
            PlaySound(pointSound);
        } else {
            currentPitch = basePitch;
            audioSource.pitch = basePitch;
            PlaySound(gameOverSound);
            GameOver();
        }
    }

    private void PlaySound(AudioClip clip)
    {
        if (audioSource != null && clip != null)
        {
            audioSource.clip = clip; // Define o som desejado
            audioSource.Play();      // Reproduz o som
        }
    }

    public void IncrementPoints(int pointsToAdd) {
        // Incrementa os pontos
        points += pointsToAdd; 
        scoreText.text = points.ToString();
        if(pointsToAdd == 5) {
            currentPitch = basePitch;
        }
        // if(points % 10 == 0) {
        //     // Aumenta a velocidade de spawn a cada 10 pontos
        //     SpawnEnemies.Instance.DecreaseSpawnerTime();
        // }
    }

    public void GameOver() {
        // Exibe a mensagem de Game Over
        Debug.Log("Game Over! Pontuação: " + points);
    }
}
