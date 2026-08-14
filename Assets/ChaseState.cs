using UnityEngine;

public class ChaseState : IState
{
    private EnemyAI enemy;

    public ChaseState(EnemyAI enemy)
    {
        this.enemy = enemy;
    }

    public void Enter()
    {
        Debug.Log("Enemy: Masuk Chase State");
    }

    public void Execute()
    {
        enemy.MoveTowards(enemy.player.position);
    }

    public void Exit()
    {
        Debug.Log("Enemy: Keluar dari Chase State");
    }
}