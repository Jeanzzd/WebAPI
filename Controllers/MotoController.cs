using Microsoft.AspNetCore.Mvc;
using System.Collections;
using WebAPI.Net.Models;
using WebAPI.Net.Repository;
using WebAPI.Net.Repository.Interface;

namespace WebAPI.Net.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MotoController : ControllerBase
    {

        private readonly IMotoRepository _motoRepository;

        public MotoController(IMotoRepository motoRepository)
        {
            _motoRepository = motoRepository;
        }

        /// <summary>
        /// Obter todos as motos cadastradas
        /// </summary>
        /// <returns></returns>
        /// <response code="200"> Retorna a lista de Motos</response>
        /// <response code="500"> Erro ao obter Motos</response>
        /// <response code="404"> Motos não encontrado</response>



        [HttpGet]
        public async Task<ActionResult<IEnumerable>> GetMoto()
        {
            try
            {
                var Moto = await _motoRepository.GetMotos();

                return Ok(Moto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Erro ao obter exames: " + ex.Message);
            }

        }



        /// <summary>
        /// Obter moto cadastrada pelo ID
        /// </summary>
        /// <returns></returns>
        /// <response code="200"> Retorna a Moto</response>
        /// <response code="500"> Erro ao obter Moto</response>
        /// <response code="404"> Moto não encontrado</response>

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Moto>> GetMoto(int id)
        {
            try
            {
                var result = await _motoRepository.GetMoto(id);
                if (result == null) return NotFound();

                return result;

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao obter Funcionario");
            }


        }
       
        


        /// <summary>
            /// Endpoint para cadastrar novas motos
            /// </summary>
            /// <returns>Retorna a moto</returns>
            /// <response code="201"> Salva o Funcionario</response>
            /// <response code="500"> Erro ao salva o Funcionario</response>
            /// <response code="400"> Faltou algo</response>
            /// 
         
        [HttpPost]
        public async Task<ActionResult<Moto>> AddMoto([FromBody] Moto moto)
        {
            try
            {
                if (moto == null) return BadRequest();

                var createFunc = await _motoRepository.CriarMoto(moto);


                return CreatedAtAction(nameof(GetMoto),
                    new { id = createFunc.MotoId }, createFunc);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao obter Moto");
            }
        }




        /// <summary>
        /// Deletar as motos
        /// </summary>
        /// <returns></returns>
        /// <response code="201"> Deletar a moto</response>
        /// <response code="500"> Erro ao Deletar Moto</response>
        /// 

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeletarMoto(int id)
        {
            try
            {
                var funToDelete = await _motoRepository.GetMoto(id);

                if (funToDelete == null)
                    return NotFound($"moto com id {id} não encontrado");

                await _motoRepository.DeletarMoto(id);

                return Ok($"moto com id {id} deletado");
            }
            catch (Exception ex)
            {
        
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao deletar moto");
            }
        }


        /// <summary>
        /// Atualizar dados
        /// </summary>
        /// <returns></returns>
        /// 

        [HttpPut("{id:int}")]
        public async Task<ActionResult<Moto>> UpdateMoto([FromBody] Moto moto )
        {
            try
            {
                var FunUpdate = await _motoRepository.GetMoto(moto.MotoId);

                if (FunUpdate == null) return NotFound($"MOTO com id {moto.MotoId} não encontrado");

                return await _motoRepository.AtualizarMoto(moto);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao atualizar moto");
            }
        }


    }
}
