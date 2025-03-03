using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Controllers.Context;
using Entidades;

namespace Controllers.Repositorio
{
    public class DentistaRep
    {
        SistemaContext ctx = new SistemaContext();
        public void Cadastrar(Dentista obj)
        {

            ctx.Dentistas.Add(obj);
            ctx.SaveChanges();

        }

        public Dentista Buscar(int id)
        {
            Dentista obj = new Dentista();

            obj = ctx.Dentistas.Find(id);
            return obj;

        }

        public List<Dentista> Listar()
        {

            var dentistas = (from obj in ctx.Dentistas select obj).OrderBy(x => x.Nome).ToList();
            return dentistas;

        }

        public void Deletar(int id)
        {

            Dentista obj = ctx.Dentistas.Find(id);
            ctx.Dentistas.Remove(obj);
            ctx.SaveChanges();

        }

        public void Editar(Dentista objNovo)
        {

            Dentista objAntigo = ctx.Dentistas.Find(objNovo.Id);
            objAntigo.Nome = objNovo.Nome;
            objAntigo.Email = objNovo.Email;
            objAntigo.Telefone = objNovo.Telefone;
            objAntigo.Celular = objNovo.Celular;
            objAntigo.CRO = objNovo.CRO;
            ctx.SaveChanges();

        }
    }
}
