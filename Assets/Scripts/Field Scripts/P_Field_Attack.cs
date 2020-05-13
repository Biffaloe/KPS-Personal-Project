using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P_Field_Attack : MonoBehaviour
{
    public Animator anim;
    public Transform AttackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;

    private void Update()
    {
        if (Input.GetKeyDown("z"))
        {
            Attack();
        }
    }

    void Attack()
    {
        anim.SetTrigger("Attack");

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(AttackPoint.position, attackRange, enemyLayers);

        foreach(Collider2D enemy in hitEnemies)
        {
            Debug.Log("We hit " + enemy.name);
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (AttackPoint == null)
            return;

        Gizmos.DrawWireSphere(AttackPoint.position, attackRange);
    }
}
