using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossBrain : IBrain
{
    //public GameObject BossBrain;

    public override void move()
    {
        base.move();
    }

    public override void Attack0(float damage)
    {
        base.Attack0(damage);
    }

    public override void Health()
    {
        base.Health();
    }



    public class Boss1 : bossBrain//boss i�in �zelle�mi� fonk.lar
    {
        //public GameObject BossBrain1;
        public override void move()
        {
            base.move();
            Debug.Log("boss 1 hareket eder. ");
        }
        public override void Attack0(float damage)
        {
            base.Attack0(damage * 3);
            Debug.Log("boss1 hasar :  " + (damage * 3));
        }
        public override void Health()
        {
            base.Health();
        }



        /*ibrain �zerinden t�retilen classtan miras al�narak tekrar 1,2 ve3. bosslar i�in �zel tan�ml�
        fonk.lar tan�mlanmak �zere a��ld�.Sonras�nda tan�mlama yap�lacak.*/

        public class Boss2 : bossBrain// �zelle�mi� fonk.lar
        {
            //public GameObject BossBrain2;
            public override void move()
            {
                base.move();
                Debug.Log("boss2 hareket eder. ");
            }
            public override void Attack0(float damage)
            {
                base.Attack0(damage * 4);
                Debug.Log("boss2 hasar :  " + (damage * 4));
            }
            public override void Health()
            {
                base.Health();
                Debug.Log("Health de�eri �al��makta.");
            }
        }

        public class Boss3 : bossBrain//boss3 i�in �zelle�mi� fonk.lar
        {
            //public GameObject BossBrain3;
            public override void move()
            {
                base.move();
                Debug.Log("boss 1 hareket eder. ");
            }
            public override void Attack0(float damage)
            {
                base.Attack0(damage * 5);
                Debug.Log("boss3 hasar :  " + (damage * 5));
            }
            public override void Health()
            {
                base.Health();
                Debug.Log("Health de�eri �al��makta.");
            }
        }
    }
}