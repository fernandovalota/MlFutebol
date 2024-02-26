using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MlFutebol.Bussiness.Entities;
using MlFutebol.Bussiness.Entities.Enum;
using MlFutebol.Bussiness.Interfaces.Services;
using MlFutebol.Bussiness.Services;
using MLFutebol.Api.Configurations;
using MLFutebol.Api.ViewsModels;
using System.Net;
using System.Net.Mime;

namespace MLFutebol.Api.Controllers
{
    [Route("api/[controller]")]
    public class JogadoresController : MainController
    {
        private readonly IJogadorService jogadorService;
        private readonly IMapper mapper;
        public JogadoresController(IJogadorService jogadorService,
            IMapper mapper,
            INotificador notificador) : base(notificador)
        {
            this.jogadorService = jogadorService;
            this.mapper = mapper;
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<BaseJogadorViewModel>> ObterJogador(Guid id)
        {
            var jogadorViewModel = await ObterJogadorCompleto(id);
            if (jogadorViewModel == null) { return NotFound(); }
            return jogadorViewModel;
        }


        [HttpPut("lancar-cartao-amarelo/{id}")]
        public async Task<ActionResult<BaseJogadorViewModel>> LancarCartaoAmarelo(Guid id)
        {
            await jogadorService.LancarCartaoAmarelo(id);
            return Ok();
        }

        [HttpPost("adicionar")]
        public async Task<IActionResult> Adicionar([FromBody] BaseJogadorViewModel jogadorViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);                        

            await jogadorService.Adicionar(ConversaoJogador.MapearJogadorViewModelParaEntidade(jogadorViewModel));
            return CustomResponse(HttpStatusCode.Created, jogadorViewModel);
        }


        [HttpPut("{id}")]
        public async Task<ActionResult<BaseJogadorViewModel>> Atualizar(Guid id, [FromBody] JogadorViewModel jogadorViewModel)
        {
            if (id != jogadorViewModel.Id)
            {
                NotificarErro("O id informado não é o mesmo que foi passado na query");
                return CustomResponse();
            }

            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await jogadorService.Atualizar(mapper.Map<Jogador>(jogadorViewModel));

            return CustomResponse(HttpStatusCode.NoContent);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<BaseJogadorViewModel>> Excluir(Guid id)
        {
            await jogadorService.Remover(id);

            return CustomResponse(HttpStatusCode.NoContent);
        }

        [HttpPost("troca-de-time")]
        public async Task<IActionResult> TrocaDeTime([FromQuery] Guid jogadorId, [FromQuery] Guid novoTimeId)
        {
            try
            {
                await jogadorService.TrocaDeTime(jogadorId, novoTimeId);
            }
            catch (Exception ex)
            {
                NotificarErro($"Erro ao trocar o time do jogador: {ex.Message}");
            }
            return CustomResponse();
        }

        [HttpPost("negociar-itens")]
        public async Task<IActionResult> NegociarItens([FromBody] TrocaDeItensInventarioJogadorViewModel jogadores)
        {
            try
            {
                await jogadorService.NegociarItens(mapper.Map<Jogador>(jogadores.JogadorOrigem), mapper.Map<Jogador>(jogadores.JogadorDestino));
            }
            catch (Exception ex)
            {
                NotificarErro($"Erro ao trocar o time do jogador: {ex.Message}");
            }
            return CustomResponse();
        }

        private async Task<JogadorViewModel> ObterJogadorCompleto(Guid id)
        {
            return mapper.Map<JogadorViewModel>(await jogadorService.ObterJogadorCompleto(id));
        }
       
    }
}
