using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ObrasBibliograficas.Data;
using ObrasBibliograficas.Model;

namespace ObrasBibliograficas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SampleDataController : ControllerBase
    {

        private readonly ObraBibliograficaDbContext _context;

        public SampleDataController(ObraBibliograficaDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("ListarAutores")]
        public async Task<IEnumerable<Autor>> ListarAutores()
        {
            return await _context.Autor.OrderBy(x => x.NomeCompleto).ToListAsync();
        }

        [HttpPost]
        [Route("IncluirAutor")]
        public async Task<int> IncluirAutor([FromBody] Autor autor)
        {
            if (String.IsNullOrWhiteSpace(autor.NomeCompleto))
                return 0;

            try
            {
                autor.NomeCompleto = autor.RetornaAutorSobrenome(autor.NomeCompleto);

                await _context.Autor.AddAsync(autor);
                await _context.SaveChangesAsync();
                return autor.id;
            }
            catch(Exception ex)
            {
                return 0;
            }
        }

        [HttpPost]
        [Route("Remover")]
        public void Remover()
        {
            // remover dados
            List<Autor> lst = new List<Autor>();
            lst = _context.Autor.OrderBy(x => x.NomeCompleto).ToList();

            foreach (var item in lst)
            {
                _context.Remove(_context.Autor.Single(a => a.id == item.id));
            }
            _context.SaveChanges();

        }

    }
}
