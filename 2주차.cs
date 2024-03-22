using System;
using System.Security.Cryptography.X509Certificates;
using System.Xml;
using Unity.PlasticSCM.Editor.WebApi;
using Unity.VisualScripting;
using Unity.VisualScripting.Dependencies.Sqlite;
using UnityEditor.Build.Reporting;
using UnityEditor.U2D.Path;
using UnityEngine;
using UnityEngine.Animations;



public class NewBehaviourScript1 : MonoBehaviour
{
    // 추상클래스의 프로퍼티
    public abstract class BaseEntity
    {
        abstract public int Shield
        {
            get; set;
        }
        public int Defense
        {
            get; set;
        }
    }

    public class Player : BaseEntity
    {
        public override int Shield 
        {
            get; set;
        }
        public string ID
        {
            get; set;
        }
    }

    public class GameController
    {
        private void Awake()
        {
            Player player = new Player();
            player.ID = "이세연";
            player.Shield = 50;
            player.Defense = 10;
            

            Debug.Log($"ID : {player.ID}");
            Debug.Log($"방어력 : {player.Defense}, 방어막 : {player.Shield}");
        }
    }


    /* 인터페이스의 프로퍼티
    interface IBaseEntity
    {
        string ID {get; set;}
        int Damage {get; set;}
        int CurrentHP {get; set;}
    }

    public class Player : IBaseEntity
    {
        private string id;
        public string ID
        {
            get => id;
            set => id = value;
        }
        public int Damage
        {
            get; set;
        }
        public int CurrentHP
        {
            get; set;
        }
    }


    /* 현재 클래스 내부에서만 set 사용할 수 있게 private 이용
    public class Player
    {
        private int currentHP;
        public int CurrentHP
        {
            private set; get;
        }
    }


    /* 쓰기 전용 프로퍼티
    public class Player
    {
        private int currentHP;
        public int CurrentHP
        {
            set => currentHP = value;
        }
    }


    /* 읽기 전용 프로퍼티
    public class Player
    {
        private int currentHP;
        public int CurrentHP
        {
            get => currentHP;
        }
    }


    /* 자동 구현 프로퍼티
    public class Player
    {
        public int CurrentHP
        {
            get; set;
        }
        public string ID
        {
            get; set;
        }
    }

    public class GameController
    {
        private void Awake()
        {
            Player player = new Player();
            player.ID = "이세연";
            player.CurrentHP = 100;
            Debug.Log($"{player.ID} HP : {player.CurrentHP}");
        }
    }


    /* 프로퍼티 선언
    public class Player
    {
        private int currentHP;
        public int CurrentHP
        {
            get => currentHP;
            set
            {
                if ( currentHP > 0 ){
                    currentHP = value;
                }
                else {
                    currentHP = 0;
                }
            }
        }
    }

    public class GameController
    {
        private void Awake() {
            Player player = new Player();
            player.CurrentHP = 100;
            Debug.Log($"Player HP : {player.CurrentHP}");
            player.CurrentHP = -100;
            Debug.Log($"Player HP : {player.CurrentHP}");
        }
    }


    /* 이름 공간 - 왜 오류나는지 모르겠음
    namespace MySpace
    {
        public class Player
        {

        }
    }

    namespace YourSpace
    {
        public class Player
        {

        }
    }

    using MySpace;

    public class GameController
    {
        private void Awake() {
            Player player01;
            YourSpace.Player palyer02;
        }
    }


    /* 정적 클래스
    public static class Calculator
    {
        public static int num;

        static Calculator()
        {
            num = 1;
        }

        public static int Sum ( int a, int b )
        {
            return a+b;
        }
    }

    public class GameController
    {
        private void Awake() {
            Debug.Log(Calculator.Sum(20,55));
            Debug.Log((Calculator.num));
        }
    }


    /* 정적 변수
    public class Enemy
    {
        public int numeric;
        public static string species;
    }

    public class GameController
    {
        private void Awake() {
            Enemy enemy01 = new Enemy();
            enemy01.numeric = 0;
            Enemy enemy02 = new Enemy();
            enemy02.numeric = 1;

            Debug.Log(enemy01.numeric);
            Debug.Log(enemy02.numeric);

            Enemy.species = "고블린";
            Debug.Log(Enemy.species);
        }
    }


    /* 정적 메소드
    public class Enemy
    {
        public int InstanceRun(){return 1;}

        public static int StaticRun()
        {
            return 1;
        }
    }

    public class GameController
    {
        private void Awake() {
            
            int j = Enemy.StaticRun();

            Enemy enemy01 = new Enemy();
            int i = enemy01.InstanceRun();
        }
    }


    /* 구조체
    public struct Stats
    {
        public string ID;
        public int currentHP;
        public int damage;
    }

    public class GameController : MonoBehaviour
    {
        private void Awake() {
            Stats player01 = new Stats();
            Stats player02;

            player02.ID = "이세연";
            player02.currentHP = 100000;
            player02.damage = 99999;

            Debug.Log($"{player01.ID}, 체력 : {player01.ID}, 공격력 : {player01.damage}");
            Debug.Log($"{player02.ID}, 체력 : {player02.ID}, 공격력 : {player02.damage}");
        }
    }


    /* 오버라이딩 봉인
    public class Entity
    {
        public virtual void TakeDamage(int damage)
        {
            Debug.Log($"Entity : {damage}만큼 체력 감소");
        }
    }

    public class MovingEntity : Entity
    {
        public sealed override void TakeDamage(int damage)
        {
            Debug.Log($"Entity : {damage}만큼 체력 감소");
        }
    }

    public class Player : MovingEntity
    {
        public override void TakeDamage(int damage)
        {
            Debug.Log($"Entity : {damage}만큼 체력 감소");
        }
    }


    /* 메소드 숨기기
    public class Parent
    {
        public void Method01()
        {
            Debug.Log("Parent");
        }
    }

    public class Child : Parent
    {
        public new void Method01()
        {
            Debug.Log("Child");
        }
    }

    public class GameController : MonoBehaviour
    {
        private void Awake() {
            Parent p = new Parent();
            p.Method01();

            Child c = new Child();
            c.Method01();

            Parent pc = new Child();
            pc.Method01(); 
        }
    }



    /* 인터페이스 상속 & 다중 상속
    interface IMovingEntity
    {
        void MoveTo(Vector2 destination);
    }

    interface ICombatEntity
    {
        void Attack(Player target);
    }

    interface IPerson : IMovingEntity
    {
        void Talk(string word);
    }

    public class Goblin : IMovingEntity
    {
        public void MoveTo(Vector2 destination)
        {
            Debug.Log($"{destination}까지 걸어서 이동");
        }
    }

    public class Player : IPerson, ICombatEntity
    {
        private string ID = "이세연";

        public void MoveTo(Vector2 destination)
        {
            Debug.Log($"{ID}님이 {destination}으로 이동");
        }

        public void Attack(Player target)
        {
            Debug.Log($"{target}을 공격합니다.");
        }

        public void Talk(string word)
        {
            Debug.Log($"{ID} : {word}");
        }
    }

    public class GameController : MonoBehaviour
    {
        private IMovingEntity goblin;
        private IPerson player;

        private void Awake() {
            goblin = new Goblin();
            player = new Player();

            goblin.MoveTo(new Vector2(1,2));
            player.MoveTo(new Vector2(3,4));
            player.Talk("안녕하세요. 이세연 입니다.");
        }
    }


    /* 인터페이스
    interface IMovingEntity
    {
        void MoveTo(Vector2 destination);
    }

    public class Goblin : IMovingEntity
    {
        public void MoveTo(Vector2 destination)
        {
            Debug.Log($"{destination}까지 걸어서 이동");
        }
    }

    public class Slime : IMovingEntity
    {
        public void MoveTo(Vector2 destination)
        {
            Debug.Log($"{destination}까지 기어서 이동");
        }
    }

    public class Dragon : IMovingEntity
    {
        public void MoveTo(Vector2 destination)
        {
            Debug.Log($"{destination}까지 날아서 이동");
        }
    }

    public class GameController : MonoBehaviour
    {
        private IMovingEntity goblin;
        private IMovingEntity slime;
        private IMovingEntity dragon;

        private void Awake() {
            goblin = new Goblin();
            slime = new Slime();
            dragon = new Dragon();

            goblin.MoveTo(new Vector2(1, 2));
            slime.MoveTo(new Vector2(3, 4));
            dragon.MoveTo(new Vector2(5, 6));
        }
    }


    /* 추상 클래스
    public abstract class Entity
    {
        protected int damage;
        protected int currentHP;

        public abstract void Attack(Entity target);
        public void TakeDamage(int damage)
        {
            if(currentHP > damage){
                currentHP -= damage;
                Debug.Log($" 체력이 {damage} 감소");
            }
            else{
                Debug.Log("Die");
            }
        }
    }

    public class Goblin : Entity
    {
        public Goblin(int damage, int hp)
        {
            base.damage = damage;
            currentHP = hp;
        }

        public override void Attack(Entity target)
        {
            Debug.Log("고블린의 몽둥이 스매시!");
            target.TakeDamage(damage);
        }
    }

    public class Slime : Entity
    {
        public Slime(int damage, int hp)
        {
            base.damage = damage;
            currentHP = hp;
        }

        public override void Attack(Entity target)
        {
            Debug.Log("슬라임의 몸통 박치기");
            target.TakeDamage(damage);
        }
    }

    public class GameController : MonoBehaviour
    {
        private Entity goblin;
        private Entity slime;

        private void Awake() {
            goblin = new Goblin(5,100);
            slime = new Slime(10,50);

            goblin.Attack(slime);
            slime.Attack(goblin);
        }
    }


    /* is, as 연산자
    public class Entity
    {
        public virtual void Attack()
        {
            Debug.Log("적을 공격한다.");
        }
    }

    public class Slime : Entity
    {
    }

    public class Goblin : Entity
    {
    }

    public class GameController : MonoBehaviour
    {
        private void Awake()
        {
            Entity entity = new Slime();
            if ( Entity is Slime)
            {
                Debug.Log("Entity type is Slime");
            }

            Goblin goblin = entity as Goblin;
            if (goblin == null)
            {
                Debug.Log("Goblin is null");
            }
        }
    }


    /* 오버라이딩
    public class Entity
    {
        public virtual void Attack()
        {
            Debug.Log("적을 공격한다.");
        }
    }

    public class Slime : Entity
    {
        public override void Attack()
        {
            Debug.Log("슬라임의 몸통 박치기 공격!");
        }
    }

    public class Goblin : Entity
    {
        public override void Attack()
        {
            Debug.Log("고블린의 몽둥이 스매시!!");
        }
    }

    public class GameController
    {
        private Slime slime;
        private Goblin goblin;

        private void Awake()
        {
            slime.Attack();
            goblin.Attack();
        }
    }


    /* 업캐스팅
    public class Goblin
    {
        public void TakeDamage(int damage)
        {
            Debug.Log($"고블린 : {damage}만큼 체력 감소");
        }
    }

    public class Slime
    {
        public void TakeDamage(int damage)
        {
            Debug.Log($"슬라임 : {damage}만큼 체력 감소");
        }
    }

    public class Dragon
    {
        public void TakeDamage(int damage)
        {
            Debug.Log($"드래곤 : {damage}만큼 체력 감소");
        }
    }

    public class Player
    {
        private int damage = 10;

        public void Hit(Goblin goblin)
        {
            goblin.TakeDamage(damage);
        }

        public void Hit(Slime slime)
        {
            slime.TakeDamage(damage);
        }

        public void Hit(Dragon dragon)
        {
            dragon.TakeDamage(damage);
        }
    }

    public class GameController : MonoBehaviour
    {
        private void Awake()
        {
            Player player = new Player();

            Goblin goblin = new Goblin();
            Slime slime = new Slime();
            Dragon dragon = new Dragon();

            player.Hit(goblin);
            player.Hit(slime);
            player.Hit(dragon);
        }
    }


    /* base
    public class Entity
    {
        public string ID;
        protected int currentHP;
    }

    public class Player : Entity
    {
        private string ID;

        public Player(string id, int hp)
        {
            base.ID = "Noname";
            ID = id;
            currentHP = hp;
        }
    }


    /* 상속
    public class Entity
    {
        public string ID;
        protected int currentHP;

        private void Initialize()
        {
            ID = "Noname";
        }

        public void RecoveryHP(int hp)
        {
            currentHP += hp;
        }
    }

    public class Player : Entity
    {
        public Player(string id,int hp)
        {
            ID = id;
            currentHP = hp;

            RecoveryHP(1000);
        }
    }


    /* 정보 은닉 & 캡슐화
    public class Player
    {
        private int currentHP;

        public void SetCurrentHP(int hp)
        {
            if (hp > 0)
            {
                currentHP = hp;
            }
        }

        public int GetCurrentHP()
        {
            return currentHP;
        }
    }

    public class GameController : MonoBehaviour
    {
        private void Awake() {
            Player player = new Player();

            player.SetCurrentHP(100);
            Debug.Log($"HP : {player.GetCurrentHP()}");
        }
    }


    /* this
    public class Player
    {
        public string ID = "이세연";


        public void SetID(string ID)
        {
            Debug.Log($"ID : {ID}");
            Debug.Log($"ID : {this.ID}");
        }
    }

    public class GameController 
    {
        public Player player01;

        private void Awake()
        {
            player01.SetID("유니티");
        }
    }


    /* 깊은 복사
    public class Player
    {
        public string ID;
        private int currentHP;
        
        public Player DeepCopy()
        {
            Player clone = new Player();
            clone.ID = ID;
            clone.currentHP = currentHP;

            return clone;
        }
    }

    public class GameController : MonoBehaviour
    {
        public Player player01;
        public Player player02;

        private void Awake()
        {
            player01 = new Player("이세연", 1000);

            player02 = player01.DeepCopy();
            player02.ID = "유니티";

            Debug.Log($"ID : {player01.ID}");
            Debug.Log($"ID : {player02.ID}");
        }
    }


    /* 얕은 복사
    public class Player
    {
        public string ID;
        private int currentHP;

        public Player(string id, int hp)
        {
            ID = id;
            currentHP = hp;
        }
    }

    public class GameController : MonoBehaviour
    {
        public Player player01;
        public Player player02;

        private void Awake()
        {
            player01 = new Player("이세연",1000);
            player02 = player01; 
            player02.ID = "유니티";

            Debug.Log($"ID : {player01.ID}");
            Debug.Log($"ID : {player02.ID}");
        }
    }


    /* 클래스 - 생성자 / 소멸자는 사용 X
    public class Player
    {
        private string ID = "이세연";
        private int currentHP = 1000;

        public void TakeDamage(int damage)
        {
            if (currentHP > damage)
            {
                currentHP -= damage;
            }
        }
    }

    public class Enemy
    {
        private Player player;

        public void AttackToTarget(Player target)
        {
            target.TakeDamage(100);
        }
    }

    public class GameController : MonoBehaviour
    {
        public Player player01;
        public Player player02;

        private void Awake() {
            player01 = new Player(); //Player 클래스의 인스턴스가 player01에 할당된다.
            player01.TakeDamage(100);
            player02.TakeDamage(200);
        }
    }



    /* 가변 길이 매개 변수
    private void Awake() {
        Sum(1,2);
        Sum(1,2,3);
        Sum(1,2,3,4);
    }

    public void Sum(params int[] nums)
    {
        int sum = 0;
        for ( int i = 0; i < nums.Length; ++i )
        {
            sum += nums[i];
        }
        Debug.Log($"합계 : {sum}");
    }


    /* 동일한 메소드 이름
    private void Awake() {
        Add(10,20);
        Add(172.3f, 89.5f);
    }

    public void Add(int num1, int num2)
    {
        int result = num1 + num2;
        Debug.Log($"{num1}+{num2}={result}");
    }

    public void Add(float num1, float num2)
    {
        float result = num1 + num2;
        Debug.Log($"{num1}+{num2}={result}");
    }


    /* 출력 전용 매개 변수 out
    private void Awake()
    {
        int a = 5, b = 4, result1 = 0, result2 = 0;
        Divide(a, b, out result1, out result2);
        Debug.Log($"몫 = {result1}, 나머지 = {result2}");
    }

    public void Divide(int num1, int num2, out int result1, out int result2)
    {
        result1 = num1 / num2;
        result2 = num1 % num2;
    }


    /* 참조에 의한 전달
    private void Awake() {
        int a = 3, b = 4;
        Debug.Log($"a={a}, b={b}");
        Swap(ref a, ref b);
        Debug.Log($"a={a}, b={b}");
    }

    public void Swap(ref int num1, ref int num2)
    {
        int temp = num1;
        num1=num2;
        num2=temp;
    }


    /* return02
    public void Divide(int num1, int num2)
    {
        if (num2==0)
        {
            Debug.Log("나누려는 값이 0이기 때문에 프로그램 종료");
            return; //num이 0일 경우 메소드 바로 탈출
        }

        float result = num1 / num2;
        Debug.Log($"{num1}/{num2}={result}");
    }



    /* return01
    private void Awake() {

        int a = Max(10,20);
        Debug.Log(Max(100,200));
        Max(5,10);
    }

    public int Max(int num1, int num2)
    {
        if(num1 > num2)
        {
            return num1;
        }
        return num2;
    }


    /* 메소드
    private void Awake() {
        Multiple(3,4);
    }

    public void Multiple(int num1, int num2)
    {
        int result = num1 * num2;
        Debug.Log($"{num1}x{num2}={result}");
    }


    /* 클래스
   public class Calculator
   {
        public int Add (int num1, int num2)
        {
        int result = num1 + num2;
        return result; 
        }

        public void Multiple(int num1, int num2)
        {
        int result = num1 * num2;
        Debug.Log($"{num1} x {num2} = {result}");
        }
    }
    */

}
