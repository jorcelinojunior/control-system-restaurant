using Cedro.RestauranteGranville.Dominio.Contratos;
using Cedro.RestauranteGranville.Dominio.Entidades;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace Cedro.RestauranteGranville.Api.Controllers
{
    [Route("api/[controller]")]
    public class RestauranteController : Controller
    {
        private readonly IRestauranteRepositorio _restauranteRepositorio;
        public RestauranteController(IRestauranteRepositorio restauranteRepositorio)
        {
            _restauranteRepositorio = restauranteRepositorio;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_restauranteRepositorio.ObterTodos());
            }
            catch (Exception ex)
            {
                return BadRequest("Ocorreu um erro: " + ex.Message);;
            }
        }

        [Route("[action]/{chave}")]
        [HttpGet]
        public IActionResult Pesquisar(string chave)
        {
            try
            {
                return Ok(_restauranteRepositorio.ObterTodos()
                                        .ToList()
                                        .Where(r => r.Nome.ToUpper().Contains(chave.ToUpper().Trim())));
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
                return Ok(_restauranteRepositorio.ObterPorId(id));
            }
            catch (Exception ex)
            {
                return BadRequest("Ocorreu um erro: " + ex.Message);;
            }
        }

        public IActionResult Post([FromBody]Restaurante restaurante)
        {
            try
            {
                _restauranteRepositorio.Adicionar(restaurante);
                return Created("api/restaurante", restaurante);
            }
            catch (Exception ex)
            {
                return BadRequest("Ocorreu um erro: " + ex.Message);
            }
        }

        [HttpPut]
        public IActionResult Put([FromBody]Restaurante restaurante)
        {
            try
            {
                _restauranteRepositorio.Atualizar(restaurante);
                return Created("api/restaurante", restaurante);
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
                var restaurante = new Restaurante();
                restaurante.Id = id;
                _restauranteRepositorio.Remover(restaurante);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest("Ocorreu um erro: " + ex.Message);
            }
        }


    }
}