using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MonsterController : MonoBehaviour
{
    public Transform central_point;
    public int random_range_move;
    public AudioClip hit_sfx;
    Animator animator;
    NavMeshAgent agent;

    public float hp;

    [SerializeField] float view_angle = 0f;
    [SerializeField] float view_distance = 0f;
    [SerializeField] float attack_distance = 0f;
    [SerializeField] LayerMask view_layermask = 0;


    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        central_point = transform;
        
    }


    public void Attack()
    {

        animator.SetTrigger("Attack");
        
        agent.isStopped = true;



    }

    public void TakeDamage(float damage) {

        hp -= damage;
        hp=Mathf.Clamp(hp, 0, 100);

        Debug.Log($"좀비피격{hp}");
        if (hp <= 0) {
            agent.isStopped = true;
            animator.SetBool("IsDead", true);
        }

    }
    private void Update()
    {
        Sight();
    }

    public void Patrol()
    {

        animator.SetBool("IsMove", true);
        agent.isStopped = false;
        if (agent.remainingDistance <= agent.stoppingDistance)
        {

            Vector3 point;

            if (RandomPoint(central_point.position, random_range_move, out point))
            {
                Debug.Log("랜덤 위치 탐색 성공");
                agent.SetDestination(point);
                animator.SetBool("IsMove", true);
            }
            else
            {
                Debug.Log("랜덤 위치 탐색 실패");

                animator.SetBool("IsMove", false);
            }
        }
    }

    bool RandomPoint(Vector3 center, float range, out Vector3 result)
    {

        Vector3 randomPoint = central_point.position + Random.insideUnitSphere * range;
        NavMeshHit hit;

        if (NavMesh.SamplePosition(randomPoint, out hit, 5.0f, NavMesh.GetAreaFromName("walkable")))
        {

            result = hit.position;
            return true;
        }

        result = Vector3.zero;
        return false;


    }

    void Sight()
    {
        Collider[] cols = Physics.OverlapSphere(transform.position, view_distance, view_layermask);


        if (cols.Length == 0)//순환움직임 
        {
           
            Patrol();
           
          
        }

        if (cols.Length > 0)//플레이어 탐지 
        {
            Debug.Log("플레이어 탐지중");

            Transform spotted_player = cols[0].transform;

            Vector3 spotted_direction = (spotted_player.position - transform.position).normalized;
            float spotted_angle = Vector3.Angle(spotted_direction, transform.forward);

            if (spotted_angle < view_angle * 0.5f)
            {
                if (Physics.Raycast(transform.position, spotted_direction, out RaycastHit hit, view_distance))
                {
                    if (hit.transform.gameObject.tag == "Player")//추적시작
                    {

                       
                       
                        

                        agent.SetDestination(hit.transform.position);

                        if (Vector3.Distance(transform.position, hit.transform.position) <= attack_distance)
                        {
                            Attack();
                        }


                    }
                }

            }
            else
            {
                Patrol();
               
                
            }
        }
    }
}
