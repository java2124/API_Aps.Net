using Projeto2WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace Projeto2WebAPI.Controllers
{
    public class UsuariosController : ApiController
    {
        private meuBanco db = new meuBanco();

        public IQueryable<Usuário> GetUsuarios() //Get que lista todos os clientes
        {
            return db.usuarios; //select*from usuários
        }

        [ResponseType(typeof(Usuário))]
        public async Task<IHttpActionResult> GetClientes(int id) //lista um usuario de acordo com o seu código
        {
            Usuário usuário = await db.usuarios.FindAsync(id);

            if (usuário == null)
            {
                return NotFound();
            }
            return Ok(usuário);
        }

        public IQueryable <Usuário> GetClientes(string nome_cliente) //Get que lista cliente a partir do nome
        {
            //usando link (para procurar coisas avançadas)
            var usuarios = from c in db.usuarios
                          where c.nome_cliente.Contains(nome_cliente)
                          select c;

            return usuarios;
            //por lambda//return db.usuarios.Where(c => c.nome_cliente.Contains (nome_cliente)); 
        }

        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutClientes(int id, Usuário cliente)
        {
            if (!ModelState.IsValid) //verifica se informações estão correras (cliente)
            {
                return BadRequest(ModelState);
            }

            if (id != cliente.cod_cliente)
            {
                return BadRequest();
            }

            db.Entry(cliente).State = System.Data.Entity.EntityState.Modified; //modifica os campos em memória

            try
            {
                await db.SaveChangesAsync(); //gravar informação no bd fisíco
            }
            catch (Exception error)
            {
                throw;
            }
            return StatusCode(HttpStatusCode.NoContent); //retorna um ok, e nada de diferente
        }

        [ResponseType(typeof(Usuário))]
        public async Task<IHttpActionResult> PostCliente(Usuário cliente)
        {
            if (!ModelState.IsValid) //verifica se informações estão correras (cliente)
            {
                return BadRequest(ModelState);
            }

            db.usuarios.Add(cliente); //cria um objeto e adiciona na lista de objetos

            try
            {
                await db.SaveChangesAsync(); //gravar informação no bd fisíco
            }
            catch (Exception error)
            {
                throw;
            }
            return CreatedAtRoute("DefaultApi", new { id = cliente.cod_cliente }, cliente); //retorna dados do objeto criado
        }

        [ResponseType(typeof(Usuário))]
        public async Task<IHttpActionResult> DeleteCliente(int id) //deler=ta usuário pelo id
        {
            Usuário cliente = await db.usuarios.FindAsync(id);

            if (cliente == null)
            {
                return NotFound();
            }

            db.usuarios.Remove(cliente);

            try
            {
                await db.SaveChangesAsync(); //gravar informação no bd fisíco
            }
            catch (Exception error)
            {
                throw;
            }
            return Ok(cliente);
        }


    }
}

