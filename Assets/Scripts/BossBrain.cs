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



    public class Boss1 : bossBrain//boss için özelleþmiþ fonk.lar
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



        /*ibrain üzerinden türetilen classtan miras alýnarak tekrar 1,2 ve3. bosslar için özel tanýmlý
        fonk.lar tanýmlanmak üzere açýldý.Sonrasýnda tanýmlama yapýlacak.*/

        public class Boss2 : bossBrain// özelleþmiþ fonk.lar
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
                Debug.Log("Health deðeri çalýþmakta.");
            }
        }

        public class Boss3 : bossBrain//boss3 için özelleþmiþ fonk.lar
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
                Debug.Log("Health deðeri çalýþmakta.");
            }
        }
    }
}