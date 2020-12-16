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
    public class CidadesController : ApiController
    {
        private meuBanco db = new meuBanco();

        public IQueryable<Cidade> GetCidades() //Get que lista todas as cidades
        {
            return db.cidades; //select*from cidades
        }

        [ResponseType(typeof(Cidade))]
        public async Task<IHttpActionResult> GetCidade(int id) //lista uma cidade de acordo com o seu código
        {
            Cidade cidade = await db.cidades.FindAsync(id);

            if (cidade == null)
            {
                return NotFound();
            }
            return Ok(cidade);
        }

        public IQueryable<Cidade> GetCidades(string nome_cidade) //Get que lista cidade a partir do nome
        {
            //usando link (para procurar coisas avançadas)
            var cidades = from c in db.cidades 
                          where c.nome_cidade.Contains(nome_cidade) select c;

            return cidades;
            //por lambda//return db.cidades.Where(c => c.nome_cidade.Contains (nome_cidade)); 
        }

        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutCidade(int id, Cidade cidade) 
        {
            if (!ModelState.IsValid) //verifica se informações estão correras (cidade)
            {
                return BadRequest(ModelState);
            }

            if(id != cidade.cod_cidade)
            {
                return BadRequest();
            }

            db.Entry(cidade).State = System.Data.Entity.EntityState.Modified; //modifica os campos em memória

            try
            {
                await db.SaveChangesAsync(); //gravar informação no bd fisíco
            }catch (Exception error)
            {
                throw;
            }
            return StatusCode(HttpStatusCode.NoContent); //retorna um ok, e nada de diferente
        }

        [ResponseType(typeof(Cidade))]
        public async Task<IHttpActionResult> PostCidade(Cidade cidade)
        {
            if (!ModelState.IsValid) //verifica se informações estão correras (cidade)
            {
                return BadRequest(ModelState);
            }

            db.cidades.Add(cidade); //cria um objeto e adiciona na lista de objetos

            try
            {
                await db.SaveChangesAsync(); //gravar informação no bd fisíco
            }
            catch (Exception error)
            {
                throw;
            }
            return CreatedAtRoute("DefaultApi", new { id = cidade.cod_cidade }, cidade); //retorna dados do objeto criado
        }

        [ResponseType(typeof(Cidade))]
        public async Task<IHttpActionResult> DeleteCidade(int id) //deleta cidade pelo id
        {
            Cidade cidade = await db.cidades.FindAsync(id);

            if (cidade == null)
            {
                return NotFound();
            }

            db.cidades.Remove(cidade);

            try
            {
                await db.SaveChangesAsync(); //gravar informação no bd fisíco
            }
            catch (Exception error)
            {
                throw;
            }
            return Ok(cidade);
        }


    }
}
