using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public Animator animator;

    public Transform attackPoint;
    public float attackRange = 0.5f; //диапозон для атаки
    public LayerMask enemyLayers; //Слой для определения врага

    public int attackDamage = 20;

    public float attackRate = 2f;
    float nextAttackTime = 0f;

    void Update()
    {
        if (Time.time >= nextAttackTime) //Если текущее время больше или равно времени атаки
        {
            if (Input.GetKeyDown(KeyCode.Space) && !Players.died)//Проверить нажат ли левый шифт для атаки
            {
                Attack();

                nextAttackTime = Time.time + 4f / attackRate; //добавить 0.5 к нашему текущему времени и сказать что это следующий раз когда мы можем атаковать и когда мы достигнем этого времени мы сможем атаковать снова
            }
        }


    }

    void Attack()
    {
        //Воспроизвести анимацию атаки
        animator.SetTrigger("Attack");




        //Обнаружить всех врагов которые находятся в пределах досигаемости атаки
        Collider[] hitEnemies = Physics.OverlapSphere(attackPoint.position, attackRange, enemyLayers); //Функция физикс создает окружность из заданой точки с указаным нами радиусом и собирает все объекты на которые попадает этот круг. Сохраним в массив коллайдеров

        //Нанести этим врагам урон
        foreach (Collider enemy in hitEnemies)
        {
            enemy.GetComponent<Enemy>().Damage(attackDamage);  //получаем доступ к скрипту Enemy на объекте, а затем вызови функцию нанесения урона
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)//Если точка атаки равна нулю, вернуться
            return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
