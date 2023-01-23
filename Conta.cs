using System;
using System.Globalization;

namespace ContaBancaria
{
    class Conta
    {
        public int Numero { get; private set; }
        public string Titular { get; private set; }
        public float Saldo { get; private set; }
        public string depositoStatus { get; private set; }
        public string saqueStatus { get; private set; }

        public Conta(int numero, string titular)
        {
            Numero = numero;
            Titular = titular;
        }

        public Conta(int numero, string titular, float depositoInicial) : this(numero, titular)
        {
            Deposito(depositoInicial);
        }

        public void Deposito(float quantia)
        {
            Saldo += quantia;
            depositoStatus = "Depósito realizado com sucesso!";
        }

        public void Saque(float quantia)
        {
            if ((quantia + 5.0f) <= Saldo)
            {
                Saldo -= (quantia + 5.0f);
                saqueStatus = "Saque realizado com sucesso!";
            }
            else
            {
                saqueStatus = "Saque inválido! Saldo insuficiente.";
            }
        }

        public override string ToString()
        {
            return $"Conta {Numero}, Titular {Titular}, Saldo {Saldo:c2}";
        }
    }
}
