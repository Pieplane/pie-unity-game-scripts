using UnityEngine;
using UnityEngine.AI;

public class EnemyAgain : MonoBehaviour
{
    public NavMeshAgent agent;

    public Transform player;

    public LayerMask whatIsGround, whatIsPlayer;

    public GameObject projectile;

    public float health;

    //Patroling
    public Vector3 walkPoint; //Точка обхода
    bool walkPointSet; //Установлена ли точка обхода
    public float walkPointRange; //Управление диапозоном точек обхода

    //Attacking
    public float timeBetweenAttacks; //Время между атаками
    bool alreadyAttacked; //Уже атаковал 

    //States
    public float sightRange, attackRange; //Дальность видимости, видимость для аттаки
    public bool playerInSightRange, playerInAttackRange; //Находится ли игрок в пределах досигаемости

    private void Awake()//Чтобы не устанавливать переменные в ручную
    {
        player = GameObject.Find("Player111").transform;
        agent = GetComponent<NavMeshAgent>();
    }
    private void Update()
    {
        //Находится ли игрок в полезрения или на расстоянии атаки
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);//Проверь сферу (своя позиция как центр, дальность обзора как дальность, то что игрок в качестве маски слоя)
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);//То же самое только для атаки.

        if (!playerInSightRange && !playerInAttackRange) Patroling(); //Если игрок не находится в поле зрения видимости или в поле зрения атаки выполнить: патрулинг.
        if (playerInSightRange && !playerInAttackRange) ChasePlayer(); //Если игрок находится в пределах видимости, но не в пределах досягаемости атака: преследовать игрока.
        if (playerInSightRange && playerInAttackRange) AttackPlayer(); //Если игрок находится в пределах видимости и в пределах атаки: атаковать.
  
    }

    private void Patroling()//Патрулинг
    {
        if (!walkPointSet) SearchWalkPoint();//Если точка ходьбы не задана, найти точку ходьбы.

        if (walkPointSet)//Если точка доступа для ходьбы установлена. Агент установи точку доступа(назначение)
            agent.SetDestination(walkPoint);

        Vector3 distanceToWalkPoint = transform.position - walkPoint;//Расчитать растояние до своей точки доступа для ходьбы

        if(distanceToWalkPoint.magnitude < 1f)//Если расстояние меньше 1, то ты достинешь точки ходьбы и установленая точка ходьбы и установленая точка ходьбы снова должна быть ложной
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

        if(Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround))//Чтобы проверить что это точка не за пределами карты: С помощью луча передачи действительно ли эта точка находится на земле
        {
            walkPointSet = true; //Если это так устоановить набор точек для ходьбы в тру.
        }
    }

    private void ChasePlayer()//Преследование игрока
    {
        agent.SetDestination(player.position);//Агент установи место назначения(позиция игрока)
    }

    private void AttackPlayer()//Атака игрока
    {
        //Создадим экземпляр нового снаряда
        Rigidbody rb = Instantiate(projectile, transform.position, Quaternion.identity).GetComponent<Rigidbody>();
        //Добавим к нему силу движения вперед и вверх
        rb.AddForce(transform.forward * 32f, ForceMode.Impulse);
        rb.AddForce(transform.up * 8f, ForceMode.Impulse);

        //Помешать игроку двигаться с агентом
        agent.SetDestination(transform.position);

        transform.LookAt(player);//Через трансформ.посмотри на (игрока)

        if (!alreadyAttacked)//Проверь не атаковал ли ты еще. Если не атаковал то установи для уже атакованой атаки тру 
        {
            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);//Вызови функцию сброса атаки с указанием времени между атаками в качестве задержки
        }
    }
    private void ResetAttack()//Сбросить уровень атаки
    {
        alreadyAttacked = false;//Уже для атакованой атаки фолс
    }

    public void TakeDamage(int damage)//Наносить урон врагам
    {
        health -= damage;

        if (health <= 0) Invoke(nameof(DestroyEnemy), 0.5f);
    }
    private void DestroyEnemy()
    {
        Destroy(gameObject);
    }

    private void OnDrawGizmosSelected()//Для визуализации дальности атаки и обзора
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, sightRange);
    }
}
