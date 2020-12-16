using System;
using System.Collections.Generic;
using System.Data.Entity; //faz a relação da tabela cidade do banco de dados com a classe cidade do sistema
using System.Linq;
using System.Web;

namespace Projeto2WebAPI.Models
{
    public class meuBanco:DbContext
    {
        public meuBanco():base("bancoDados") //conexão com o banco de dados através do construtor
        {

        }

        public DbSet<Cidade> cidades { get; set; } //objeto da cidade, toda vez que for utilizar a tabela cidade eu vou chamar esse objeto
        public DbSet <Usuário> usuarios { get; set; } //objeto do usuário
    }
}