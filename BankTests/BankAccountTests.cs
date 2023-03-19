using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Bank;
namespace BankTests
{
    [TestClass]
    public class BankAccountTests
    {
        [TestMethod]
        public void Debit_WithValidAmount_UpdatesBalance() //Списание с действительной суммой. Обновляет баланс
        {
            // Arrange
            double beginningBalance = 11.99;
            double debitAmount = 4.55;
            double expected = 7.44;
            BankAccount account = new BankAccount("Mr. Bryan Walton", beginningBalance);
            // Act
            account.Debit(debitAmount);
            // Assert
            double actual = account.Balance;
            Assert.AreEqual(expected, actual, 0.001, "Account not debited correctly");
        }

        [TestMethod]
        public void Debit_WhenAmountIsLessThanZero_ShouldThrowArgumentOutOfRange() //Списание когда сумма меньше нуля. Следует выбросить аргумент за пределы диапазона исключения
        {
            // Arrange
            double beginningBalance = 11.99;
            double debitAmount = -100.00;
            BankAccount account = new BankAccount("Mr. Bryan Walton", beginningBalance);
            // Act and assert
            Assert.ThrowsException<System.ArgumentOutOfRangeException>(() =>
            account.Debit(debitAmount));
        }

        [TestMethod]
        public void Debit_WhenAmountIsMoreThanBalance_ShouldThrowArgumentOutOfRange()//Списание когда сумма больше, чем баланс, следует выдать исключение за пределы диапазона исключения
        {
            // Arrange
            double beginningBalance = 11.99;
            double debitAmount = 20.0;
            BankAccount account = new BankAccount("Mr. Bryan Walton", beginningBalance);
            // Act
            try
            {
                account.Debit(debitAmount);
            }
            catch (System.ArgumentOutOfRangeException e)
            {
                // Assert
                StringAssert.Contains(e.Message, BankAccount.DebitAmountExceedsBalanceMessage);
                return;
            }
            Assert.Fail("The expected exception was not thrown.");
        }
        [TestMethod]
        public void Debit_WhenAmountIsZero_ShouldThrowArgumentOutOfRange()//Списание когда сумма равна нулю, следует выдать исключение за пределы диапазона исключения
        {
            // Arrange
            double beginningBalance = 11.99;
            double debitAmount = 0.00;
            BankAccount account = new BankAccount("Mr. Bryan Walton", beginningBalance);
            // Act
            try
            {
                account.Debit(debitAmount);
            }
            catch (System.ArgumentOutOfRangeException e)
            {
                // Assert
                StringAssert.Contains(e.Message, BankAccount.DebitAmountIsZeroMessage);
                return;
            }
            //Assert.Fail("The expected exception was not thrown.");
        }
        [TestMethod]
        public void Debit_WhenAmountIsEqualToTheBalance_UpdatesBalance() //Списание когда сумма равна балансу. Обновляет баланс
        {
            // Arrange
            double beginningBalance = 11.99;
            double debitAmount = 11.99;
            double expected = 0.00;
            BankAccount account = new BankAccount("Mr. Bryan Walton", beginningBalance);
            // Act
            account.Debit(debitAmount);
            // Assert
            double actual = account.Balance;
            Assert.AreEqual(expected, actual, 0.001, "Account not debited correctly");
        }

        //[TestMethod]
        //public void  Credit_WhenAmountIsMoreThanBalance_ShouldThrowArgumentOutOfRange()//Списание когда сумма меньше, чем баланс, следует выдать исключение за пределы диапазона исключения
        //{
        //    // Arrange
        //    double beginningBalance = 11.99;
        //    double creditAmount = 20.0;
        //    double expected = 8.01;
        //    BankAccount account = new BankAccount("Mr. Bryan Walton", beginningBalance);
        //    try
        //    {
        //        account.Credit(creditAmount);
        //    }
        //    catch (System.ArgumentOutOfRangeException e)
        //    {
        //        StringAssert.Contains(e.Message, BankAccount.CreditAmountMessage);
        //        return;
        //    }

        //}
    }
}
