using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;

//Controller
public class EnemyExample : MonoBehaviour
{  
    EnemyModel enemy = new EnemyModel(200);

    // Start is called before the first frame update
    void Start()
    {
        var attackBtn = transform.Find("Button").GetComponent<Button>();
        var hpText = transform.Find("Text").GetComponent<Text>();

        attackBtn.OnClickAsObservable().Subscribe(_ => {
            enemy.HP.Value -= 99;
        });

        enemy.HP.SubscribeToText(hpText);
        enemy.IsDead
            .Where(isDead => isDead)
            .Select(isDead => !isDead)
            .SubscribeToInteractable(attackBtn);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}


//Model
public class EnemyModel
{
    public ReactiveProperty<long> HP;

    public IReadOnlyReactiveProperty<bool> IsDead;

    public EnemyModel(long initialHP)
    {
        HP = new ReactiveProperty<long>(initialHP);

        IsDead = HP.Select(hp => hp <= 0).ToReactiveProperty();
    }

}