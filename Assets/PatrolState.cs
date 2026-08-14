using UnityEngine;

public class PatrolState : IState
{
    private EnemyAI enemy;
    private int currentPointIndex = 0;

    public PatrolState(EnemyAI enemy)
    {
        this.enemy = enemy;
    }

    public void Enter()
    {
        Debug.Log("Enemy: Masuk Patrol State");
        // Lanjutkan dari titik terdekat, tidak reset ke titik 0 tiap masuk state lagi
    }

    public void Execute()
    {
        if (enemy.patrolPoints == null || enemy.patrolPoints.Length == 0) return;

        Transform target = enemy.patrolPoints[currentPointIndex];
        enemy.MoveTowards(target.position);

        // Kalau sudah sampai titik ini, pindah ke titik berikutnya
        if (Vector2.Distance(enemy.transform.position, target.position) < 0.1f)
        {
            currentPointIndex = (currentPointIndex + 1) % enemy.patrolPoints.Length;
            // %  (modulo) bikin index otomatis balik ke 0 setelah titik terakhir
        }
    }

    public void Exit()
    {
        Debug.Log("Enemy: Keluar dari Patrol State");
    }
}