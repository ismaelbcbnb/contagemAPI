using ContagemPF.Data;
using ContagemPF.Data.DTO;
using ContagemPF.Models;
using Microsoft.AspNetCore.Mvc;

namespace ContagemPF.Controllers;

[Route("[controller]")]
[ApiController]

public class ContagemController : ControllerBase
{
    [HttpGet("")]
    public ActionResult Get([FromServices] DAL<Contagem> dal)
    {
        if (dal is null) return NotFound();
        var listaContagem = dal.Listar();

        listaContagem = listaContagem.OrderBy(s => s.Sistema).OrderBy(c => c.NumCard);
        
        return Ok(listaContagem);
    }

    [HttpGet("{id}")]
    public ActionResult GetById([FromServices] DAL<Contagem> dal, int id)
    {
        var contagem = dal.RecuperarPor(b => b.IdContagem == id);
        if (contagem is null) return NotFound();

        return Ok(contagem);
    }

    [HttpPost("")]
    public ActionResult Add([FromServices] DAL<Contagem> dal, [FromBody] ContagemDTO contagemDTO)
    {
        Contagem contagem = new();
        contagem.NumCard = contagemDTO.NumCard;
        contagem.NumContagem = contagemDTO.NumContagem;
        contagem.PontosDeFuncao = contagemDTO.PontosDeFuncao;
        contagem.Sistema = contagemDTO.Sistema;
        contagem.Validado = contagemDTO.Validado;
        if (contagemDTO.Link is null) contagem.Link = "";
        else contagem.Link = contagemDTO.Link;
        contagem.Entregue = contagemDTO.Entregue;
        contagem.Mes = contagemDTO.Mes;
        dal.Adicionar(contagem);
        return (Ok(contagem));
    }

    [HttpPut("")]
    public ActionResult Update([FromServices] DAL<Contagem> dal, [FromBody] Contagem contagem)
    {
        var contagemAAtualizar = dal.RecuperarPor(b => b.IdContagem == contagem.IdContagem);

        if (contagemAAtualizar is null) return NotFound();
        contagemAAtualizar.NumCard = contagem.NumCard;
        contagemAAtualizar.NumContagem = contagem.NumContagem;
        contagemAAtualizar.PontosDeFuncao = contagem.PontosDeFuncao;
        contagemAAtualizar.Sistema = contagem.Sistema;
        contagemAAtualizar.Validado = contagem.Validado;
        contagemAAtualizar.Entregue = contagem.Entregue;
        contagemAAtualizar.Link = contagem.Link;
        contagemAAtualizar.Mes = contagem.Mes;

        dal.Atualizar(contagemAAtualizar);
        return Ok(contagemAAtualizar);
    }

    [HttpPut("entregar")]
    public ActionResult Entregar([FromServices] DAL<Contagem> dal, [FromBody] Contagem contagem)
    {
        var contagemAAtualizar = dal.RecuperarPor(b => b.IdContagem == contagem.IdContagem);

        if (contagemAAtualizar is null) return NotFound();

        contagemAAtualizar.Entregue = contagemAAtualizar.Entregue?false:true;

        dal.Atualizar(contagemAAtualizar);
        return Ok(contagemAAtualizar);
    }

    [HttpPut("validar")]
    public ActionResult ValidarInvalidar([FromServices] DAL<Contagem> dal, [FromBody] Contagem contagem)
    {
        var contagemAAtualizar = dal.RecuperarPor(b => b.IdContagem == contagem.IdContagem);

        if (contagemAAtualizar is null) return NotFound();

        contagemAAtualizar.Validado = contagemAAtualizar.Validado ? false : true;

        dal.Atualizar(contagemAAtualizar);
        return Ok(contagemAAtualizar);
    }

    [HttpDelete("{id}")]
    public ActionResult Delete([FromServices] DAL<Contagem> dal, int id)
    {
        var contagem = dal.RecuperarPor(a => a.IdContagem == id);
        if (contagem is null) return NotFound();
        dal.Deletar(contagem);
        return NoContent();
    }



}