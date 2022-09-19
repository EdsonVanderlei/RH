using RH.Entities.Enum;
using System;
using System.Collections.Generic;
using System.Linq;


namespace RH.Entities
{
    internal class Funcionario
    {
        public int Codigo { get;private set; }
        public string Nome { get; private set; }
        public string Email { get; private set; }
        public string Telefone { get; private set; }

        private List<Contato> Contatos = new List<Contato>();

        public Funcionario(int codigo, string nome, string email, string telefone)
        {
            Codigo = codigo;
            Nome = nome;
            Email = email;
            Telefone = telefone;
        }


        public void AdicionarContato(int codigo,string nome,string telefone, Relacao relacao)
        {

            try
            {
                foreach (Contato item in Contatos)
                {
                    if (item.Relacao == relacao && item.Telefone == telefone)
                    {
                        throw new Exception("Relação e Telefone iguais");
                    }
                }




                Contato contato = new Contato(codigo, nome, telefone, relacao);
                Contatos.Add(contato);
                Contatos = Contatos.OrderBy(x => x.Codigo).ToList();
            }   
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void ImprimirLIsta()
        {
            foreach (Contato item in Contatos)
            {
                Console.WriteLine(item.ToString());
            }
        }
    }
}
