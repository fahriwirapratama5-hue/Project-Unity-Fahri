using UnityEngine;

public class AttackState : IState
{
    private EnemyAI enemy;
    private float attackTimer;
    private float attackCooldown = 1f;

    public AttackState(EnemyAI enemy)
    {
        this.enemy = enemy;
    }

    public void Enter()
    {
        Debug.Log("Enemy: Masuk Attack State");
        attackTimer = 0f;
    }

    public void Execute()
    {
        // Musuh berhenti (tidak bergerak), cuma menyerang berkala
        attackTimer += Time.deltaTime;
        if (attackTimer >= attackCooldown)
        {
            Debug.Log("Enemy menyerang Player!");
            attackTimer = 0f;
            // nanti bisa tambahkan logic damage ke PlayerHealth di sini
        }
    }

    public void Exit()
    {
        Debug.Log("Enemy: Keluar dari Attack State");
    }
}