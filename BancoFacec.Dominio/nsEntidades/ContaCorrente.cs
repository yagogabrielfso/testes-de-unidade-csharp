using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BancoFacec.Dominio.nsExceptions;
using BancoFacec.Dominio.nsInterfaces;

namespace BancoFacec.Dominio.nsEntidades
{
    public class ContaCorrente : IConta
    {

        public string NomeCliente { get; private set; }
        public bool IsBloqueada { get; private set; }
        public decimal Saldo { get; private set; }


        public ContaCorrente(string nomeCliente, decimal saldo)
        {
            NomeCliente = nomeCliente;
            Saldo = saldo;
        }

        public void Bloquear() => IsBloqueada = true;

        public void Creditar(decimal valor)
        {
            ValidarValor(valor);
            ValidarContaBloqueada();
            Saldo += valor;
        }

        public void Debitar(decimal valor)
        {
            ValidarValor(valor);
            Saldo -= valor;
        }

        public void Desbloquear() => IsBloqueada = false;

        private void ValidarValor(decimal valor)
        {
            if (valor <= 0)
                throw new ArgumentOutOfRangeException("valor não pode ser negativo ou zero. Verifique!");
        }

        private void ValidarContaBloqueada()
        {
            if (IsBloqueada)
            {
                throw new BusinessRuleExceptions("Conta Corrente encontra-se bloqueada, não é permitido efetuar movimentações!");
            }
        }
    }
}
