using System.ComponentModel.Design;
using System.Diagnostics.CodeAnalysis;

do
{
    if (AuthenticateUser())
    {
        break;
    }
    Console.WriteLine("Acceso denegado. Intenta de nuevo.");
} while (true);

int option;

do
{
    Console.Clear();
    Console.WriteLine("Menu de Ejercicios de Modularizacion: ");
    Console.WriteLine("1. Calculadora Basica");
    Console.WriteLine("2. Verificar Numero Primo");
    Console.WriteLine("3. Suma de Numeros Pares");
    Console.WriteLine("4. Conversion de Temperatura");
    Console.WriteLine("5. Contador de Vocales");
    Console.WriteLine("6. Calculo de Factorial");
    Console.WriteLine("7. Juego de Adivinanzas");
    Console.WriteLine("8. Paso por Referencia");
    Console.WriteLine("9. Tabla de Multiplicar");
    Console.WriteLine("0. Salir");
    Console.WriteLine("Elige una opcion:");

    if (int.TryParse(Console.ReadLine(), out option))
    {
        switch (option)
        {
            case 1:
                BasicCalculator();
                break;
            case 2:
                PrimeNumberCheck();
                break;
            case 3:
                SumEvenNumbers();
                break;
            case 4:
                TemperatureConversion();
                break;
            case 5:
                VowelCounter();
                break;
            case 6:
                FactorialCalculation();
                break;
            case 7:
                GuessingGame();
                break;
            case 8:
                ReferenceSwap();
                break;
            case 9:
                MultiplicationTable();
                break;
            case 0:
                Console.WriteLine("Saliendo...");
                break;
            default:
                Console.WriteLine("La opcion que acaba de colocar es invalida.");
                break;
        }
    }
    else
    {
        Console.WriteLine("Ingresa un numero que sea valido.");
    }
    Console.WriteLine("\nPresiona una tecla para continuar...");
    Console.ReadKey();
} while (option != 0);

static bool AuthenticateUser()
{
    Console.WriteLine("Ingresa el usuario: ");
    string username = Console.ReadLine() ?? string.Empty;

    Console.WriteLine("Ingresa la contrasena: ");
    string password = Console.ReadLine() ?? string.Empty;

    return username == "Jose" && password == "2611";
}

static void BasicCalculator()
{
    Console.WriteLine("Ingresa el primer numero: ");
    if (!double.TryParse(Console.ReadLine(), out double num1))
    {
        Console.WriteLine("El numero es invalido.");
        return;
    }
    Console.WriteLine("Ingresa el segundo numero: ");
    if (!double.TryParse(Console.ReadLine(), out double num2))
    {
        Console.WriteLine("El numero es invalido.");
        return;
    }
    Console.WriteLine("Elige una operacion matematica: +,-,*,/");
    string operation = Console.ReadLine() ?? string.Empty;

    double result = operation switch
    {
        "+" => num1 + num2,
        "-" => num1 - num2,
        "*" => num1 * num2,
        "/" => num2 != 0 ? num1 / num2 : double.NaN,
        _ => double.NaN
    };

    Console.WriteLine($"Resultado: {result}");
}

static void PrimeNumberCheck()
{
    Console.WriteLine("Ingrese un numero: ");
    if (int.TryParse(Console.ReadLine(), out int num))
    {
        bool isPrime = IsPrime(num);
        Console.WriteLine(isPrime ? "El numero es Primo" : "El numero no es Primo");
    }
    else
    {
        Console.WriteLine("El Numero es Invalido.");
    }
}

static bool IsPrime(int num)
{
    if (num < 2) return false;
    for (int i = 2; i * i <= num; i++)
    {
        if (num % i == 0) return false;
    }
    return true;
}

static void SumEvenNumbers()
{
    int sum = 0, num;
    do
    {
        Console.WriteLine("Ingresa un numero (0 para Salir): ");
        if (int.TryParse(Console.ReadLine(), out num) && num % 2 == 0)
        {
            sum += num;
        }
    } while (num != 0);

    Console.WriteLine($"La Suma de Pares es: {sum}");
}

static void TemperatureConversion()
{
    Console.WriteLine("Ingresa la Temperatura: ");
    if (!double.TryParse(Console.ReadLine(), out double temp))
    {
        Console.WriteLine("El numero es invalido. ");
        return;
    }
    Console.WriteLine("Elige una opcion: C para Celsius a Fahrenheit o F para Fahrenheit a Celsius");
    string option = Console.ReadLine()?.ToUpper() ?? string.Empty;

    double result = option switch
    {
        "C" => (temp * 9 / 5) + 32,
        "F" => (temp - 32) * 5 / 9,
        _ => double.NaN
    };

    Console.WriteLine($"La Temperatura Convertida es: {result}");
}

static void VowelCounter()
{
    Console.WriteLine("Ingresa una frase: ");
    string phrase = Console.ReadLine()?.ToLower() ?? string.Empty;
    int count = 0;
    foreach (char c in phrase)
    {
        if ("aeiou".Contains(c)) count++;
    }
    Console.WriteLine($"El numero de Vocales es: {count}");
}

static void FactorialCalculation()
{
    Console.Write("Ingresa un numero: ");
    if (int.TryParse(Console.ReadLine(), out int num))
    {
        long factorial = 1;
        for (int i = 1; i <= num; i++)
            factorial *= i;

        Console.WriteLine($"Factorial de {num}: {factorial}");
    }
    else
    {
        Console.WriteLine("Numero invalido.");
    }
}

static void GuessingGame()
{
    Random rand = new Random();
    int secretNumber = rand.Next(1, 101), guess;
    Console.WriteLine("Adivina el numero secreto (1-100)");

    do
    {
        Console.WriteLine("Ingresa un numero: ");
        if (int.TryParse(Console.ReadLine(), out guess))
        {
            if (guess < secretNumber) Console.WriteLine("Demasiado bajo.");
            else if (guess > secretNumber) Console.WriteLine("Demasiado alto.");
        }
    } while (guess != secretNumber);

    Console.WriteLine("¡Adivinaste!");
}

static void ReferenceSwap()
{
    Console.Write("Ingresa el primer numero: ");
    if (!int.TryParse(Console.ReadLine(), out int num1))
    {
        Console.WriteLine("Numero invalido.");
        return;
    }

    Console.Write("Ingresa el segundo numero: ");
    if (!int.TryParse(Console.ReadLine(), out int num2))
    {
        Console.WriteLine("Numero invalido.");
        return;
    }

    Swap(ref num1, ref num2);

    Console.WriteLine($"Valores intercambiados: {num1}, {num2}");
}

static void Swap(ref int a, ref int b)
{
    int temp = a;
    a = b;
    b = temp;
}

static void MultiplicationTable()
{
    Console.Write("Ingresa un numero: ");
    if (int.TryParse(Console.ReadLine(), out int num))
    {
        for (int i = 1; i <= 10; i++)
        {
            Console.WriteLine($"{num} x {i} = {num * i}");
        }
    }
    else
    {
        Console.WriteLine("Numero invalido.");
    }
}



