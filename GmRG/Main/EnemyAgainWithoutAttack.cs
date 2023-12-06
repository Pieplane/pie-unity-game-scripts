using UnityEngine;
using UnityEngine.AI;

public class EnemyAgainWithoutAttack : MonoBehaviour
{
    public NavMeshAgent agent;

    public Transform player;

    public LayerMask whatIsGround, whatIsPlayer;

    public Animator anim;



    public float health;

    //Patroling
    public Vector3 walkPoint; //Точка обхода
    bool walkPointSet; //Установлена ли точка обхода
    public float walkPointRange; //Управление диапозоном точек обхода

    //Attacking


    //States
    public float sightRange; //Дальность видимости, видимость для аттаки
    public bool playerInSightRange; //Находится ли игрок в пределах досигаемости
    public bool playerStopDistance; //Находится игрок в зоне остановки врага
    public float stop;


    private void Awake()//Чтобы не устанавливать переменные в ручную
    {
        player = GameObject.Find("Player").transform;
        agent = GetComponent<NavMeshAgent>();

    }
    private void Update()
    {
        //Находится ли игрок в полезрения или на расстоянии атаки
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);//Проверь сферу (своя позиция как центр, дальность обзора как дальность, то что игрок в качестве маски слоя)
        playerStopDistance = Physics.CheckSphere(transform.position, stop, whatIsPlayer);

        if (!playerInSightRange && !playerStopDistance) Patroling(); //Если игрок не находится в поле зрения видимости или в поле зрения атаки выполнить: патрулинг.
        if (playerInSightRange && !playerStopDistance) ChasePlayer(); //Если игрок находится в пределах видимости, но не в пределах досягаемости атака: преследовать игрока.
                                                                      //Если игрок находится в пределах видимости и в пределах атаки: атаковать.
        if (playerInSightRange && playerStopDistance) Stoping();



    }
    private void Stoping()
    {
        agent.SetDestination(transform.position);
        Vector3 direction = player.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
        int combatEnemy = UnityEngine.Random.Range(0, 2);
        {
            anim.SetBool("Attack", true);
        }



    }


    private void Patroling()//Патрулинг
    {
        anim.SetBool("isRunning", false);
        anim.SetBool("Attack", false);
        if (!walkPointSet) SearchWalkPoint();//Если точка ходьбы не задана, найти точку ходьбы.

        if (walkPointSet)//Если точка доступа для ходьбы установлена. Агент установи точку доступа(назначение)
            agent.SetDestination(walkPoint);

        Vector3 distanceToWalkPoint = transform.position - walkPoint;//Расчитать растояние до своей точки доступа для ходьбы

        if (distanceToWalkPoint.magnitude < 1f)//Если расстояние меньше 1, то ты достинешь точки ходьбы и установленая точка ходьбы и установленая точка ходьбы снова должна быть ложной
        {
            walkPointSet = false;//После этого она автоматически должна искать новую точку.
        }
    }
    private void SearchWalkPoint()
    {
        //Вычислить случайно точку в диапозоне
        float randomZ = Random.Range(-walkPointRange, walkPointRange); //ДиапозонZ случайный диапозон(отрицательных точек прохождения, положительных точек прохождения)Вернет случайное значение в зависимости от того насколько велик диапозон точек вашей ходьбы.
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ); //Установить точку перехода в новый вектор3(ваша позиция х + случайное значение х, ваша позиция y, ваша позиция z + случайное значение z)

        if (Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround))//Чтобы проверить что это точка не за пределами карты: С помощью луча передачи действительно ли эта точка находится на земле
        {
            walkPointSet = true; //Если это так устоановить набор точек для ходьбы в тру.
        }
    }

    private void ChasePlayer()//Преследование игрока
    {
        agent.SetDestination(player.position);//Агент установи место назначения(позиция игрока)
        anim.SetBool("isRunning", true);
        anim.SetBool("Attack", false);
    }
    private void OnDrawGizmosSelected()//Для визуализации дальности атаки и обзора
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, stop);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, sightRange);

    }


}




