using Microsoft.VisualStudio.TestTools.UnitTesting;
using ObrasBibliograficas.Model;
using System;

namespace ObrasBibliograficas.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Autor autor = new Autor();
            string resultado;

            // Apenas um nome
            resultado = autor.RetornaAutorSobrenome("LavAnder");

            // Nome com SobreNome
            resultado = autor.RetornaAutorSobrenome("JOsUE laVander");

            // Terminacao em "FILHO", "FILHA", "NETO", "NETA", "SOBRINHO", "SOBRINHA" ou "JUNIOR"
            resultado = autor.RetornaAutorSobrenome("ANTonio CARlos Junior");

            // Contendo "da", "de", "do", "das", "dos"
            resultado = autor.RetornaAutorSobrenome("Joao do Amaral Neto");

            resultado = autor.RetornaAutorSobrenome("Roberto Luiz Carlos da Silva");

            resultado = autor.RetornaAutorSobrenome("Carlos Eduardo Pereira da Silva Sobrinho");


        }
    }
}
