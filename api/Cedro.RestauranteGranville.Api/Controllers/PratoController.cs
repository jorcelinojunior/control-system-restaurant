using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cedro.RestauranteGranville.Dominio.Contratos;
using Cedro.RestauranteGranville.Dominio.Entidades;
using Microsoft.AspNetCore.Mvc;

namespace Cedro.RestauranteGranville.Api.Controllers
{
    [Route("api/[controller]")]
    public class PratoController : Controller
    {
        private readonly IPratoRepositorio _pratoRepositorio;
        public PratoController(IPratoRepositorio pratoRepositorio)
        {
            _pratoRepositorio = pratoRepositorio;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                //if(condicao == false)
                //{
                //    return BadRequest("");
                //}
                return Ok(_pratoRepositorio.ObterTodos());
            }
            catch (Exception ex)
            {
                return BadRequest("Ocorreu um erro: " + ex.Message);;
            }
        }

        [HttpGet]
        [Route("{id:int}")]
        public IActionResult Get(int id)
        {
            try
            {
                //if(condicao == false)
                //{
                //    return BadRequest("");
                //}
                return Ok(_pratoRepositorio.ObterPorId(id));
            }
            catch (Exception ex)
            {
                return BadRequest("Ocorreu um erro: " + ex.Message);;
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody]Prato prato)
        {
            try
            {
                _pratoRepositorio.Adicionar(prato);
                return Created("api/prato", prato);
            }
            catch (Exception ex)
            {
                return BadRequest("Ocorreu um erro: " + ex.Message);
            }
        }

        [HttpPut]
        public IActionResult Put([FromBody]Prato prato)
        {
            try
            {
                _pratoRepositorio.Atualizar(prato);
                return Created("api/prato", prato);
            }
            catch (Exception ex)
            {
                return BadRequest("Ocorreu um erro: " + ex.Message);
            }
        }

        [HttpDelete]
        [Route("{id:int}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var prato = new Prato();
                prato.Id = id;
                _pratoRepositorio.Remover(prato);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest("Ocorreu um erro: " + ex.Message);
            }
        }


    }
}