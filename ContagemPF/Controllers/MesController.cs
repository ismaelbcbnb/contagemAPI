using ContagemPF.Data;
using ContagemPF.Data.DTO;
using ContagemPF.Models;
using Microsoft.AspNetCore.Mvc;

namespace ContagemPF.Controllers;

[Route("[controller]")]
[ApiController]

public class MesController : ControllerBase
{
    [HttpGet()]
    public ActionResult Get([FromServices] DAL<Mes> dal)
    {
        var listaMeses = dal.Listar();
        listaMeses = listaMeses.OrderBy(m => m.IdMes);
        return Ok(listaMeses);
    }
    
    [HttpGet("{id}")]
    public ActionResult GetById([FromServices] DAL<Mes> dal, int id)
    {
        var mesAno = dal.RecuperarPor(b => b.IdMes == id);
        if (mesAno is null) return NotFound();

        return Ok(mesAno);
    }

    [HttpPost()]
    public ActionResult Add([FromServices] DAL<Mes> dal, [FromBody] MesDTO mesDto)
    {
        Mes mes = new();
        mes.MesAno = mesDto.MesAno;
        dal.Adicionar(mes);
        return Ok(mes);
    }

    [HttpPut()]
    public ActionResult Update([FromServices] DAL<Mes> dal, [FromBody] Mes mes)
    {
        var mesAAtualizar = dal.RecuperarPor(a => a.IdMes == mes.IdMes);
        if (mesAAtualizar is null) return NotFound();
        mesAAtualizar.MesAno = mes.MesAno;
        dal.Atualizar(mesAAtualizar);
        return Ok(mesAAtualizar);
    }
    
    [HttpDelete("{id}")]
    public ActionResult Delete([FromServices] DAL<Mes> dal, int id)
    {
        var mes = dal.RecuperarPor(a => a.IdMes == id);
        if (mes is null) return NotFound();
        dal.Deletar(mes);
        return NoContent();
    }
}