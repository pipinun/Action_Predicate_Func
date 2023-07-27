Console.WriteLine("Action");
#region Action
//Делегат Action представляет некоторое действие, которое ничего не возвращает, то есть в качестве возвращаемого типа имеет тип void: public delegate void Action(); public delegate void Action<in T>(T obj)
//Данный делегат имеет ряд перегруженных версий. Каждая версия принимает разное число параметров: от Action<in T1> до Action<in T1, in T2,....in T16>.
//Таким образом можно передать до 16 значений в метод.
//Как правило, этот делегат передается в качестве параметра метода и предусматривает вызов определенных действий в ответ на произошедшие действия. Например:


DoOperationAction(10,6, Add);
DoOperationAction(10,6, Multiply);


void DoOperationAction(int a, int b, Action<int, int> operation) => operation(a, b);

void Add(int x, int y) => Console.WriteLine($"{x} + {y} = {x + y}");
void Multiply(int x, int y) => Console.WriteLine($"{x} * {y} = {x * y}");


#endregion
Console.WriteLine("Predicate");
#region Prdicate
//Делегат Predicate<T> принимает один параметр и возвращает значение типа bool: delegate bool Predicate<in T>(T obj);
//Как правило, используется для сравнения, сопоставления некоторого объекта T определенному условию.
//В качестве выходного результата возвращается значение true, если условие соблюдено, и false, если не соблюдено:
Predicate<int> isPositive = (int x) => x > 0;
 
Console.WriteLine(isPositive(20));
Console.WriteLine(isPositive(-20));
#endregion
Console.WriteLine("Func");
#region Func
//Еще одним распространенным делегатом является Func. Он возвращает результат действия и может принимать параметры.
//Он также имеет различные формы: от Func<out T>(), где T - тип возвращаемого значения, до Func<in T1, in T2,...in T16, out TResult>(), то есть может принимать до 16 параметров.
// TResult Func<out TResult>()
// TResult Func<in T, out TResult>(T arg)
// TResult Func<in T1, in T2, out TResult>(T1 arg1, T2 arg2)
// TResult Func<in T1, in T2, in T3, out TResult>(T1 arg1, T2 arg2, T3 arg3)
// TResult Func<in T1, in T2, in T3, in T4, out TResult>(T1 arg1, T2 arg2, T3 arg3, T4 arg4)
//Данный делегат также часто используется в качестве параметра в методах:
int result3 = DoOperationFunc(6, DoubleNumber);
Console.WriteLine($"DoOperationFunc-DoubleNamber: {result3}");


int result = DoOperationFunc(6, SquareNumber);
Console.WriteLine($"DoOperationFunc-SquareNumber: {result}");

int DoOperationFunc(int n, Func<int, int> operation) => operation(n);
int DoubleNumber(int n) => 2 * n;
int SquareNumber(int n) => n * n;
//Другой пример:
Func<int, int, string> createString = (a, b) => $"{a}{b}";
Console.WriteLine(createString(1, 5));  // 15
Console.WriteLine(createString(3, 5));  // 35
//Здесь переменная createString представляет лямбда-выражение, которое принимает два числа int и возвращает строку, то есть представляет делегат Func<int, int, string>.
#endregion