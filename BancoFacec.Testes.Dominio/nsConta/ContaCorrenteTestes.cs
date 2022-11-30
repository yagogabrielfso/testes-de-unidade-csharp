using System;
using BancoFacec.Dominio.nsEntidades;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BancoFacec.Testes.Dominio.nsConta
{

    [TestClass]
    public class ContaCorrenteTestes
    {
        private const string _testOwner = "Yago";
        private const string _category = "IConta"; 
        
        #region Creditar
        [TestMethod]
        [Owner(_testOwner)]
        [TestCategory(_category)]
        public void ContaCorrente_Creditar_ExpectedSucesso()
        {
            // Arrange

            var contaCorrente = new ContaCorrente("Yago", 1000.00m);
            
            // Act
            contaCorrente.Creditar(100.00m);

            // Assert
            Assert.AreEqual(1100.00m, contaCorrente.Saldo);
        }
        [TestMethod]
        [Owner(_testOwner)]
        [TestCategory(_category)]
        public void ContaCorrente_Creditar_ExpectedArgumentOutOfRangeExceptionZero()
        {
            // Arrange

            var contaCorrente = new ContaCorrente("Yago", 1000.00m);
            
            // Act
            // Assert

            Assert.ThrowsException<ArgumentOutOfRangeException>(() => contaCorrente.Creditar(0.00m),
                "Não foi gerada uma exception para valor zero, verifique!");

        }
        [TestMethod]
        [Owner(_testOwner)]
        [TestCategory(_category)]
        public void ContaCorrente_Creditar_ExpectedArgumentOutOfRangeExceptionNegative()
        {
            // Arrange

            var contaCorrente = new ContaCorrente("Yago", 1000.00m);
            
            // Act
            // Assert
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => contaCorrente.Creditar(-1.00m), "Não foi gerada uma exception para valor negativo como parâmetro. Verifique!");

          
        }

        #endregion

        #region Debitar
        [TestMethod]
        [Owner(_testOwner)]
        [TestCategory(_category)]
        public void ContaCorrente_Debitar_ExpectedSucesso()
        {
            // Arrange
            var contaCorrente = new ContaCorrente("Yago", 1000.00m);

            // Act
            contaCorrente.Debitar(100.00m);

            //Assert
            Assert.AreEqual(900.00m, contaCorrente.Saldo);
        }
        [TestMethod]
        [Owner(_testOwner)]
        [Category(_category)]
        public void ContaCorrente_Debitar_ExpectedArgumentOutOfRangeExceptionZero()
        {
            // Arrange

            var contaCorrente = new ContaCorrente("Yago", 1000.00m);

            // Act
            // Assert

            Assert.ThrowsException<ArgumentOutOfRangeException>(() => contaCorrente.Debitar(0.00m),
                "Não foi gerada uma exception para valor zero, verifique!");

        }
        [TestMethod]
        [Owner(_testOwner)]
        [Category(_category)]
        public void ContaCorrente_Debitar_ExpectedArgumentOutOfRangeExceptionNegative()
        {
            // Arrange

            var contaCorrente = new ContaCorrente("Yago", 1000.00m);

            // Act
            // Assert
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => contaCorrente.Debitar(-1.00m), "Não foi gerada uma exception para valor negativo como parâmetro. Verifique!");


        }
        #endregion
         
        #region Bloquear
        [TestMethod]
        [Owner(_testOwner)]
        [TestCategory(_category)]
        public void ContaCorrente_Bloquear_ExpectedSucess()
        {
            //Arrange
            var contaCorrente = new ContaCorrente("Yago", 1000.00m);
            //Act
            contaCorrente.Desbloquear();
            contaCorrente.Bloquear();
            //Assert
            Assert.AreEqual(true, contaCorrente.IsBloqueada);
        }
        #endregion

        #region Desbloquear
        [TestMethod]
        [Owner(_testOwner)]
        [TestCategory(_category)]
        public void ContaCorrente_Desbloquear_ExpectedSucess()
        {
            // Arrange
            var contaCorrente = new ContaCorrente("Yago", 1000.00m);
            //Act
            contaCorrente.Bloquear();
            contaCorrente.Desbloquear();

            //Assert
            Assert.AreEqual(false, contaCorrente.IsBloqueada);
        }

        #endregion


    }
}
