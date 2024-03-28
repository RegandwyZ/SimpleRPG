using UnityEngine;
using UnityEngine.AI;

public class EnemyTestMoving : MonoBehaviour
{
    [SerializeField] private Collider _collider;
    
    private NavMeshAgent _agent;
    private AttackLogic _attackLogic;
    private Player _player;
    private AttackAnimation _animation;
    private Canvas _canvas;

    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
        _attackLogic = GetComponent<AttackLogic>();
        _animation = GetComponent<AttackAnimation>();
        _player = FindObjectOfType<Player>();
        _canvas = GetComponentInChildren<Canvas>();
    }

    private void Update()
    {
        if (_agent.enabled)
        {
            _animation.IsRunning(true);
            _agent.SetDestination(_player.transform.position);
            if (!_agent.pathPending && _agent.remainingDistance <= _agent.stoppingDistance)
            {
                _attackLogic.Attack();
            }
        }
    }

    public void Defeat()
    {
        _collider.enabled = false;
        _agent.enabled = false;
        _canvas.enabled = false;
    }
}
