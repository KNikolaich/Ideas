using System;
using Xunit;
using System.Security.Cryptography;
using System.Text;
using System.IO;
using Core;

namespace XUnitTest.Core
{
    public class CryptoTest
    {
        [Fact]
        public void EncryptDecript_Equals()
        {
            string sBegintext = "����� ��� ����������.!@#$%^&)(*'";
            var sKey = "���� �������";
            var encriptedText = Crypto.Encript(sBegintext, sKey);
            var decriptedText = Crypto.Decript(encriptedText, sKey);
            Assert.Equal(sBegintext, decriptedText);
        }
    }
}
