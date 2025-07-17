using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Enemy Settings")]
    public string enemyName = "Slime";
    public int maxHP = 4;

    private int currentHP;

    private void Start()
    {
        currentHP = maxHP;
        Debug.Log($"{enemyName} spawned with {maxHP} HP.");
    }

    public void TakeDamage(int amount)
    {
        currentHP -= amount;
        Debug.Log($"{enemyName} took {amount} damage. Remaining HP: {currentHP}");

        if (currentHP <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Debug.Log($"{enemyName} has been defeated!");

        BattleManager battleManager = FindObjectOfType<BattleManager>();
        if (battleManager != null)
        {
            battleManager.OnEnemyDefeated();
        }

        // Instead of destroying, disable visuals or hide
        gameObject.SetActive(false);
    }

    public void Respawn()
    {
        maxHP += 4;
        currentHP = maxHP;
        gameObject.SetActive(true);

        Debug.Log($"{enemyName} respawned with {maxHP} HP.");
    }


}
