using Microsoft.AspNetCore.Mvc;
using MlFutebol.Bussiness.Interfaces.Services;

namespace MLFutebol.Api.Controllers
{
    [Route("api/[controller]")]
    public class RelatoriosController : MainController
    {
        private readonly IJogadorService jogadorService;
        public RelatoriosController(IJogadorService jogadorService,
            INotificador notificador) : base(notificador)
        {
            this.jogadorService = jogadorService;
        }

        [HttpGet("porcentagem-jogadores-ativos")]
        public async Task<ActionResult<Dictionary<string, double>>> ObterPorcentagemJogadoresAtivosPorTime()
        {            
            var relatorio = await jogadorService.ObterPorcentagemJogadoresAtivosPorTime();
            return Ok(relatorio);
        }

        [HttpGet("jogadores-suspensos-por-time")]
        public async Task<ActionResult<Dictionary<string, double>>> ObterJogadoresSuspensosPorTime()
        {
            var relatorio = await jogadorService.ObterJogadoresSuspensosPorTime();
            return Ok(relatorio);
        }

        [HttpGet("quantidade-media-itens-por-jogador")]
        public async Task<ActionResult<Dictionary<string, double>>> CalcularMediaItensPorJogador()
        {
            var relatorio = await jogadorService.CalcularMediaItensPorJogador();
            return Ok(relatorio);
        }
    }
}
