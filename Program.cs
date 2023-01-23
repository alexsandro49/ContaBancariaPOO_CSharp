using System;
using System.Globalization;

namespace ContaBancaria
{
    class Program
    {
        public static Conta conta;
        static void Main(string[] args)
        {
            Console.Write("Entre o número da conta: ");
            int numero = int.Parse(Console.ReadLine());
            Console.Write("Entre o titular da conta: ");
            string titular = Console.ReadLine();
            while (true)
            {
                Console.Write("Haverá um deposito inicial (s/n)? ");
                string opc1 = Console.ReadLine();

                if (opc1.ToUpper() == "S")
                {
                    Console.Write("Entre o valor de depósito inicial: R$");
                    float deposito = float.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                    conta = new Conta(numero, titular, deposito);
                    break;
                }
                else if (opc1.ToUpper() == "N")
                {
                    conta = new Conta(numero, titular);
                    break;
                }
                else
                {
                    Console.WriteLine("Opção inválida! Por favor, tente novamente.");
                    Console.WriteLine();
                }
            }
            Console.WriteLine();

            while (true)
            {
                Console.WriteLine($"Seja bem vindo, {conta.Titular}!");
                Console.WriteLine("=-=-=-=-=-=-=");
                Console.WriteLine("1 - Mostrar saldo");
                Console.WriteLine("2 - Depósito");
                Console.WriteLine("3 - Saque");
                Console.WriteLine("0 - Fechar sistema");
                Console.Write("Como podemos te ajudar? ");
                string opc2 = Console.ReadLine();
                Console.WriteLine();

                if (opc2.ToUpper() == "1")
                {
                    Dados();
                }
                else if (opc2.ToUpper() == "2")
                {
                    Deposito();
                }
                else if (opc2.ToUpper() == "3")
                {
                    Saque();
                }
                else if (opc2.ToUpper() == "0")
                {
                    Console.WriteLine("Tenha um bom dia!");
                    break;
                }
                else
                {
                    Console.WriteLine("Opção inválida! Por favor, tente novamente.");
                    Console.WriteLine();
                }
            }
        }

        public static void Dados()
        {
            Console.WriteLine("Dados da conta:");
            Console.WriteLine(conta);
            Console.WriteLine();
        }
        public static void Deposito()
        {
            Console.Write("Entre um valor para depósito: R$");
            conta.Deposito(float.Parse(Console.ReadLine(), CultureInfo.InvariantCulture));
            Console.WriteLine(conta.depositoStatus);
            Console.WriteLine();
        }

        public static void Saque()
        {
            Console.WriteLine($"Saldo atual: {conta.Saldo:c2}");
            Console.Write("Entre um valor para saque (taxa: R$5): R$");
            conta.Saque(float.Parse(Console.ReadLine(), CultureInfo.InvariantCulture));
            Console.WriteLine(conta.saqueStatus);
            Console.WriteLine();
        }
    }
}