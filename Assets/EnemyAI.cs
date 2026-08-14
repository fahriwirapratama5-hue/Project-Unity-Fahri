using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [Header("References")]
    public Transform player;
    public Transform[] patrolPoints; // ganti dari pointA/pointB jadi array

    [Header("Settings")]
    public float moveSpeed = 2f;
    public float chaseRange = 5f;
    public float attackRange = 1f;

    private StateMachine stateMachine;

    public PatrolState patrolState;
    public ChaseState chaseState;
    public AttackState attackState;

    void Awake()
    {
        stateMachine = new StateMachine();

        patrolState = new PatrolState(this);
        chaseState = new ChaseState(this);
        attackState = new AttackState(this);
    }

    void Start()
    {
        stateMachine.ChangeState(patrolState);
    }

    void Update()
    {
        stateMachine.Update();

        float distance = Vector2.Distance(transform.position, player.position);

        if (distance <= attackRange)
        {
            stateMachine.ChangeState(attackState);
        }
        else if (distance <= chaseRange)
        {
            stateMachine.ChangeState(chaseState);
        }
        else
        {
            stateMachine.ChangeState(patrolState);
        }
    }

    public void MoveTowards(Vector3 target)
    {
        transform.position = Vector3.MoveTowards(transform.position, target, moveSpeed * Time.deltaTime);
    }
}