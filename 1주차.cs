using System;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    //enum lsy { lsy1, lsy2, lsy3 }
    private int x = 10;

    private void Awake() {
        // 33. 가변 배열
        int[][] array = new int[3][];

        array[0] = new int[3] {1, 2, 3};
        array[1] = new int[] { 10, 20, 30,40 };
        array[2] = new int[] { 100, 200, 300, 400, 500 };

        for ( int i = 0; i < array.Length; ++ i )
        {
            for ( int j = 0; j < array[i].Length; ++ j)
            {
                Debug.Log($"[{i}][{j}] = {array[i][j]}");
            }
        }


        /* 32.배열
        int[] enemys = new int[5];

        Debug.Log($"배열의 타입 : {enemys.GetType()}");
        Debug.Log($"배열의 기본 타입 : {enemys.GetType().BaseType}");

        Debug.Log("==정렬 전==");
        for ( int i = 0; i < enemys.Length; ++ i )
        {
            enemys[i] = UnityEngine.Random.Range(0,100);

            Debug.Log(enemys[i]);
        }

        Array.Sort(enemys);

        Debug.Log("==정렬 후==");
        for (int i = 0; i < enemys.Length; ++i)
        {
            Debug.Log(enemys[i]);
        }

        Debug.Log($"Dimensions : {enemys.Rank}");

        /* 31. 반복문 while
        int result = 0;
        int index = 1;

        while ( index <= 100 )
        {
            result += index;

            index ++;
        }

        Debug.Log($"1부터 100까지의 합은 {result}");


        /* 30. 반복문 for
        for ( int index = 0; index < 10; ++ index )
        {
            Debug.Log(index);
        }

        for ( int x = 1; x < 10; ++ x )
        {
            for ( int y = 1; y < 10; ++y )
            {
                Debug.Log($"{x} x {y} = {x * y}");
            }
        }


        /* 29. switch-case
        x /= 10;

        switch(x)
        {
            case 10:
                Debug.Log("학점 A+");
                break;
            case 9:
                Debug.Log("학점 A+");
                break;
            case 8:
                Debug.Log("학점 B+");
                break;
            case 7:
                Debug.Log("학점 C+");
                break;
            case 6:
                Debug.Log("학점 D+");
                break;
            default:
                Debug.Log("학점 F");
                break;
        }


        /* 28. if-else if-else
        if (x>=90)
        {
            Debug.Log("학점 : A+");
        }
        else if (x >= 80)
        {
            Debug.Log("학점 : B+");
        }
        else if (x >= 70)
        {
            Debug.Log("학점 : C+");
        }
        else if (x >= 60)
        {
            Debug.Log("학점 : D+");
        }
        else
        {
            Debug.Log("학점 : F");
        }



        /* 27. if-else
        if (x % 2 == 0)
        {
            Debug.Log(("x는 짝수다."));
        }
        else
        {
            Debug.Log("x는 홀수다.");
        }


        /* 26. if문
        if (x  % 2 == 0)
        {
            Debug.Log(("x는 짝수다."));
        }

        if ( x > 5 && x < 10)
        {
            Debug.Log("x는 5보다 크고 10보다 작다.");
        }

        if (x > 5 )
        {
            if ( x < 10)
            {
                Debug.Log("x는 5보다 크고 10보다 작다.");
            }
        }


        /* 25. 비트 연산자
        int a = 3;

        Debug.Log($"{a} << 1 = {a << 1}");
        Debug.Log($"{a} << 2 = {a << 2}");
        Debug.Log($"{a} << 3 = {a << 3}");
        Debug.Log($"{a} << 4 = {a << 4}");

        a = 255;
        Debug.Log($"{a} >> 1 = {a >> 1}");
        Debug.Log($"{a} >> 2 = {a >> 2}");
        Debug.Log($"{a} >> 3 = {a >> 3}");
        Debug.Log($"{a} >> 4 = {a >> 4}");

        a = -255;
        Debug.Log($"{a} >> 1 = {a >> 1}");
        Debug.Log($"{a} >> 2 = {a >> 2}");
        Debug.Log($"{a} >> 3 = {a >> 3}");
        Debug.Log($"{a} >> 4 = {a >> 4}");

        Debug.Log(Convert.ToString( a >> 4, 2));

        Debug.Log($"10 & 6 = {10 & 6}");

        Debug.Log($"10 | 6 = {10 | 6}");

        Debug.Log($"10 ^ 6 = {10 ^ 6}");

        Debug.Log($"~10 = {~10}");


        /* 24. 논리 연산자, 조건(삼항) 연산자
        bool result = false;
        int x = 5, y = 2;

        result = x > 2 && y != 5;
        Debug.Log($"{x} > 2 && {y} != 5 = {result}");

        result = x < 4 || y == 3;
        Debug.Log($"{x} < 4 || {y} == 3 = {result}");

        Debug.Log(result);
        result = !result;
        Debug.Log(result);

        int hp = -10;
        hp = hp < 0 ? 0 : hp;
        Debug.Log("체력 :"+ hp);


        /* 23. 비교(관계) 연산자
        int x =5, y = 2;

        Debug.Log($"{x} > {y} = {x > y}");
        Debug.Log($"{x} < {y} = {x < y}");
        Debug.Log($"{x} >= {y} = {x >= y}");
        Debug.Log($"{x} <= {y} = {x <= y}");
        Debug.Log($"{x} == {y} = {x == y}");
        Debug.Log($"{x} != {y} = {x != y}");


        /* 22. 증감 연산자
        int a =10;
        Debug.Log(a);

        a ++;
        Debug.Log(a);

        ++ a;
        Debug.Log(a);

        Debug.Log(a++);
        Debug.Log(a);
        Debug.Log(++a);
        Debug.Log(a);


        /* 21. 대입(할당) 연산자
        int a = 10;
        Debug.Log(($"a = 10 : {a}"));

        a += 10;
        Debug.Log($"a += 10 : 결과 값 {a}");

        Debug.Log($"a -= 9 : 결과 값 {a -= 9}");
        Debug.Log($"a *= 8 : 결과 값 {a *= 8}");
        Debug.Log($"a /= 7 : 결과 값 {a /= 7}");
        Debug.Log($"a %= 6 : 결과 값 {a %= 6}");
        Debug.Log($"a &= 5 : 결과 값 {a &= 5}");
        Debug.Log($"a |= 4 : 결과 값 {a |= 4}");
        Debug.Log($"a ^= 3 : 결과 값 {a ^= 3}");
        Debug.Log($"a <<= 2 : 결과 값 {a <<= 2}");
        Debug.Log($"a >>= 1 : 결과 값 {a >>= 1}");



        /* 20. 산술연산자
        int a = 5+6;
        int b = a-3;
        int c = a+b;
        int d = c/8;
        int e = d%4;

        Debug.Log($"{a} = 5+6");
        Debug.Log($"{b} = {a} - 3");
        Debug.Log($"{c} =  {a} + {b}");
        Debug.Log($"{d} = {c} / 8");
        Debug.Log($"{e} = {d} % 4");


        /* 19. 문자열 분할
        string position = "3, 5, 6";

        string[] str = position.Split(',');
        Debug.Log($"{str[0]}, {str[1]}, {str[2]}");

        string str2 = "HELLO  WORLD";

        str2 = str2.Substring(7);
        Debug.Log(str2);


        /* 18. 문자열 변형
        string str = "HELLO WORLD";
        Debug.Log(str);

        str = str.ToLower();
        Debug.Log($"ToLower() - {str}");

        str = str.ToUpper();
        Debug.Log($"ToUpper() - {str}");

        str = str.Insert(0, "Hi~");
        Debug.Log($"Insert() - {str}");

        str = str.Remove(0, 4);
        Debug.Log($"Remove() - {str}");

        Debug.Log("== Trim ==");

        str = "    " + str + "    ";
        Debug.Log(str + "공백 체크");

        str = str.Trim();

        Debug.Log(str + "공백 체크");

        Debug.Log($"Before Replace : {str}");
        str = str.Replace("HELLO", "BYE");
        Debug.Log($"After Replace : {str}");



        /* 17. 문자열 탐색
        string str = "Hello, World";
        Debug.Log(str);

        int numeric = str.IndexOf('o');
        Debug.Log($"o는 뒤에서부터 {numeric+1}번쨰에 있습니다.");

        numeric = str.LastIndexOf('o');
        Debug.Log($"o는 뒤에서부터 {numeric}번째에 있습니다.");

        bool isTrue = str.StartsWith("Hello");
        Debug.Log($"{str} 문장은 Hello부터 시작한다? {isTrue}");

        isTrue = str.StartsWith("World");
        Debug.Log($"{str} 문장은 World부터 시작한다? {isTrue}");

        isTrue = str.EndsWith("Hello");
        Debug.Log($"{str} 문장은 Hello로 끝난다? {isTrue}");

        isTrue = str.EndsWith("World");
        Debug.Log($"{str} 문장은 World로 끝난다? {isTrue}");

        isTrue = str.Contains("Hello");
        Debug.Log($"{str} 문장은 Hello이 포함되어 있다?? {isTrue}");




        /* 16. string.Format() vs 문자열 보간
        int minutes = 1;
        int seconds = 15;

        Debug.Log(string.Format("기본 : {0}{1}{2}", minutes, ":", seconds));

        Debug.Log($"{minutes} : {seconds}");

        Debug.Log(string.Format("{0, -10:D5}", minutes));

        Debug.Log($"{minutes, -10:D5}");


        /* 15. string.Format()을 이용한 문자열 가공
        int minutes = 1;
        int seconds = 15;

        Debug.Log(string.Format("기본 : {0}{1}{2}", minutes, ":", seconds));
        Debug.Log(string.Format("왼쪽 맞춤 : {0,-5}{1}{2}", minutes, ":", seconds));
        Debug.Log(string.Format("오른쪽 맞춤 : {0,5}{1}{2}", minutes, ":", seconds));

        Debug.Log(string.Format("10진수 서식화 : {0:D}",123));
        Debug.Log(string.Format("10진수 서식화(5자리) : {0:D5}", 123));

        Debug.Log(string.Format("16진수 서식화 : {0:X}", 0x00));
        Debug.Log(string.Format("16진수 서식화(10자리) : {0:X10}", 0x00));

        Debug.Log(string.Format("고정소수점 서식화 : {0:F}", 1.23));
        Debug.Log(string.Format("고정소수점 서식화(소수점 1자리) : {0:F1}", 1.23));

        Debug.Log(string.Format("콤마로 구분 : {0:N}", 1234567890));
        Debug.Log(string.Format("지수 : {0:E}", 1234567890));

        DateTime dt = new DateTime(2020, 2, 22, 13, 40, 0);
        String str = dt.ToString("yyyy-MM-dd tt hh:mm:ss (dddd)");
        Debug.Log(str);

        str = dt.ToString("yyyy-MM-dd HH:mm:ss (dddd)");
        Debug.Log(str);




        /* 14. var
        int? lsy;

        lsy = null;
        Debug.Log(lsy.HasValue);

        lsy = 30;
        Debug.Log(lsy.HasValue);
        Debug.Log(lsy.Value);

        var lsy1 = 33;
        var lsy2 = 33.4567f;
        var lsy3 = "문자열";

        Debug.Log("1 :" + lsy1);
        Debug.Log("2 :" + lsy2);
        Debug.Log("3 :" + lsy3);



        /* 13. 열거형을 이용한 플레이어 상태 관리
        lsy lsy4 = lsy.lsy1;
            
        switch(lsy4)
        {
            case lsy.lsy1:
                Debug.Log("플레이어 상태 : 대기");
                break;
            case lsy.lsy2:
                Debug.Log("플레이어 상태 : 이동");
                break;
            case lsy.lsy3:
                Debug.Log("플레이어 상태 : 공격");
                break;
        }


        /* 12. 상수를 이용한 플레이어 상태 관리
        const int lsy = 0;
        const int lsy1 = 1;
        const int lsy2 = 2;

        int lsy3 = lsy2;

        switch (lsy3)
        {
            case lsy:
                Debug.Log("플레이어 상태 : 대기");
                break;
            case lsy1:
                Debug.Log("플레이어 상태 : 이동");
                break;
            case lsy2:
                Debug.Log("플레이어 상태 : 공격");
                break;
        }


        /* 11. 숫자를 문자열로 형 변환
        string lsy = "숫자가 아닙니다.";
        int lsy1 = 10;
        
        bool lsy2 = int.TryParse(lsy, out lsy1);
        if (lsy2 == true)
        {
            Debug.Log("1 :" + lsy);
            Debug.Log("2 :" + lsy1);
        }
        else
        {
            Debug.Log("lsy 변수에 들어있는 내용이 숫자가 아니어서 형 변환에 실패하였습니다.");
        }


        /* 09. 문자열을 숫자로 형 변환
        int lsy = 10;
        float lsy1 = 12.3456f;
        string lsy2 = "33";

        Debug.Log("1 :" + lsy);
        Debug.Log("2 :" + lsy1);
        Debug.Log("3 :" + lsy2);

        lsy = int.Parse(lsy2);
        lsy2 = "33.4567";
        lsy1 = float.Parse(lsy2);

        Debug.Log("1 :" + lsy);
        Debug.Log("2 :" + lsy1);
        Debug.Log("3 :" + lsy2);


        /* 08. 부동 소수점과 정수 사이의 형 변환
        float lsy = 0.9f;
        int lsy1 = (int)lsy;

        Debug.Log("1 :" + lsy);
        Debug.Log("2 :" + lsy1);

        lsy = 1.1f;
        lsy1 = (int)lsy;

        Debug.Log("1 :" + lsy);
        Debug.Log("2 :" + lsy1);


        /* 07. 크기가 서로 다른 부동 소수점 사이의 형 변환
        float lsy = 69.6875f;
        double lsy1 = (double)lsy;

        Debug.Log("1 :" + lsy);
        Debug.Log("2 :" + lsy1);

        lsy = 0.1f;
        lsy1 = (double)lsy;

        Debug.Log("1 :" + lsy);
        Debug.Log("2 :" + lsy1);


        /* 06. 부호 있는 정수와 부호 없는 정수 사이의 형 변환
        sbyte lsy = 31;
        byte lsy1 = (byte)lsy;

        Debug.Log("1 :" + lsy);
        Debug.Log("2 :" + lsy1);

        lsy = -31;
        lsy1 = (byte)lsy;

        Debug.Log("1 :" + lsy);
        Debug.Log("2 :" + lsy1);

        lsy1 = 200;
        lsy = (sbyte)lsy1;

        Debug.Log("1 :" + lsy);
        Debug.Log("2 :" + lsy1);



        /* 05. 크기가 서로 다른 정수(int, sbyte) 사이의 형 변환
        sbyte lsy = 10;
        int lsy1 = (int)lsy;

        Debug.Log("1 :" + lsy);
        Debug.Log("2 :" + lsy1);

        lsy1 = 130;
        lsy = (sbyte)lsy1;

        Debug.Log("1 :" + lsy);
        Debug.Log("2 :" + lsy1);


        /* 04. 오브젝트 변수
        object lsy = 31;
        object lsy1 = 3.14159265358979f;
        object lsy2 = "객체지향 프로그래밍";
        object lsy3 = false;
        
        Debug.Log("1 :" + lsy);
        Debug.Log("2 :" + lsy1);
        Debug.Log("3 :" + lsy2);
        Debug.Log("4 :" + lsy3);


        /* 03. 문자열,논리
        string lsy = "안녕하세요. 이세연입니다.";
        bool lsy1 = true;

        Debug.Log("1: "+lsy);
        Debug.Log("2 : "+lsy1);


        /* 02. 실수
        float lsy = 3.14159265358979323846264338279f;
        float lsy1 = 31.14159265358979323846264338279f;
        double lsy2 = 3.14159265358979323846264338279;
        decimal lsy3 = 3.14159265358979323846264338279m;

        Debug.Log("1 :" + lsy);
        Debug.Log("2 :" + lsy1);
        Debug.Log("3 :" + lsy2);
        Debug.Log("4 :" + lsy3);
        


        /* 01. 정수
        int lsy = 1;
        char lck = 'K';

        Debug.Log("lsy :"+lsy);
        Debug.Log("lck :"+lck);
        */
    }
}
