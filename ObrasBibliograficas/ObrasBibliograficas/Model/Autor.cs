using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


namespace ObrasBibliograficas.Model
{
    public class Autor
    {
        [Key]
        public int id { get; set; }
        public string NomeCompleto { get; set; }


        // Retorna Nome
        public string RetornaAutorNome(string texto)
        {
            // retorna o primeiro nome e formata a primeira letra como maiúscula. 
            return texto.Substring(0, texto.IndexOf(" "));

        }


        // Retorna Sobrenome
        public string RetornaAutorSobrenome(string texto)
        {

            string textoLimpo = texto.Trim();

            string[] auxiliar = textoLimpo.Split(' ');

            // Entrou apenas um nome 
            if (auxiliar.Length == 1)
                return texto.ToUpper();

            // Entrada Nome e Sobrenome
            if (auxiliar.Length == 2)
                return String.Format("{0}, {1}", auxiliar[1].ToUpper(), PrimeiraLetraMaiuscula(auxiliar[0]));


            string nomeRetorno = String.Empty;

                string primeiro = String.Empty; // PrimeiraLetraMaiuscula(auxiliar[0]);
                string meio = String.Empty;
                string ultimo = String.Empty;
                int retirar = 1;
                int ajuste = 0;
                int qtd = auxiliar.Length;

            if (VerificaTerminacao(texto))
            {
                retirar = 1;
                ajuste = 1;
                ultimo = auxiliar[auxiliar.Length - 1].ToUpper();
            }

            bool fazParteSobrenome = true;


            for (int i = qtd - ajuste ; i > 0; i--)
                {
                    if(fazParteSobrenome)
                    {
                        if(VerificaSeFazParteSobrenome(auxiliar[i-retirar]))
                        {
                            ultimo = String.IsNullOrEmpty(ultimo) ? auxiliar[i - retirar].ToUpper() + ',' : auxiliar[i - retirar].ToUpper() + " " + ultimo + ',';
                            //ultimo = auxiliar[i-retirar].ToUpper() + " " + ultimo + ',';
                            fazParteSobrenome = false;
                        }
                        else
                        {
                            fazParteSobrenome = false;
                            meio = String.IsNullOrEmpty(meio) ? auxiliar[i - retirar].ToLower() : " " + auxiliar[i - retirar].ToLower() + " " + meio;
                        }
                    }
                    else
                    {
                        if(VerificaSeFazParteSobrenome(auxiliar[i-retirar]))
                        {
                            meio = String.IsNullOrEmpty(meio) ? PrimeiraLetraMaiuscula(auxiliar[i - retirar]) : " " + PrimeiraLetraMaiuscula(auxiliar[i - retirar]) + " " + meio;
                        }
                        else
                        {
                            meio = String.IsNullOrEmpty(meio) ? auxiliar[i - retirar].ToLower() : " " + auxiliar[i - retirar].ToLower() + " " + meio;
                        }
                    }
                }

                return  ultimo + " " + primeiro + " " + meio;
        }

        private string PrimeiraLetraMaiuscula(string texto)
        {
            string retorno;

            // pegamos a primeira letra do parametro e deixamos maiuscula;
            retorno = texto.Substring(0, 1).ToUpper();

            // pegamos o restante e fazemos minuscula, e juntamos com a primeira letra
            retorno += texto.Substring(1, texto.Length - 1).ToLower();

            return retorno;

}

        private bool VerificaTerminacao(string texto)
        {
            string[] termino = new string[] { "FILHO", "FILHA", "NETO", "NETA", "SOBRINHO", "SOBRINHA", "JUNIOR" };

            for (int i = 0; i < termino.Length; i++)
            {
                if(texto.ToUpper().EndsWith(termino[i]))
                {
                    return true;
                }
            }

            return false;
        }

        private bool VerificaSeFazParteSobrenome(string texto)
        {
            string[] termino = new string[] { "da", "de", "do", "das", "dos" };

            for (int i = 0; i < termino.Length; i++)
            {
                if (texto.ToLower() == termino[i])
                {
                    return false;
                }
            }

            return true;
        }


    }
}
