using System;

Console.WriteLine("123");
test.test.start();

namespace test
{
    class test
    {
        test() { }

        public static void MakeTextLog(string text)
        {
            Console.WriteLine("FROM MAKE LOG: " + text);
        }

        delegate void MakeLog(string text);
        static public void start()
        {
            /* [0] Console.WriteLine(text)
             * [1] Console.WriteLine(text)
             * [2] Console.Write(text)
            */

            // Console.WriteLine(string);
            // Console.Write(string);

            MakeLog deleagateVar = Console.WriteLine;
            deleagateVar += Console.Write;
            deleagateVar += Console.WriteLine;

            deleagateVar -= Console.WriteLine;

            MakeLog otherDelegate = Console.WriteLine;
            otherDelegate += Console.Write;
            deleagateVar += otherDelegate;

            deleagateVar += delegate (string text)
            {
                Console.WriteLine(text);
            };

            deleagateVar += (string text) =>
            {
                text = text+text;
                Console.WriteLine("anonymous lambda " + text);
            };

            deleagateVar("text");

            foreach (Delegate d in deleagateVar.GetInvocationList())
            {
                string methodName = d.Method.ToString();
                Console.WriteLine(methodName);
            }

            // Что Func, что Action - это типы данных, просто созданы они не нами, как MakeLog тип делегата, а майкрософтом для нашего удобства

            // Возвращает значение, тип возвращаемого значения указан последним типом в перечислении <>, в данном случае string
            Func<int, double, string> delegateIN = new Func<int, double, string>(
                (int x, double y) =>
                {
                    return x + Console.ReadLine();
                }
            );
            var res = delegateIN(655, 324.2);
            Console.WriteLine(res);

            // Делегат Action - не возвращает значение
            Action<string, int> actionDelegStrInt = new Action<string, int>((string ff, int u) => Console.WriteLine(ff + u));
            actionDelegStrInt.Invoke("anystr", 888);
        }

    }

}