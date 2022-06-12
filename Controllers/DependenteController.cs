using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using Projeto.Business.Contracts;
using Projeto.Entities;
using Projeto.Services.Models.Request;
using Projeto.Services.Models.Response;

namespace Projeto.Services.Controllers
{
    [RoutePrefix("api/dependente")]
    public class DependenteController : ApiController
    {
        private IDependenteBusiness business;

        public DependenteController(IDependenteBusiness business)
        {
            this.business = business;
        }

        [Route("cadastrar")]
        [HttpPost]
        public HttpResponseMessage Cadastrar(DependenteCadastroRequest request)
        {
            var response = new DependenteCadastroResponse();

            if (ModelState.IsValid)
            {
                try
                {
                    Dependente d = new Dependente();
                    d.Nome = request.Nome;
                    d.DataNascimento = request.DataNascimento;
                    d.IdFuncionario = request.IdFuncionario;

                    business.Cadastrar(d);

                    response.Mensagem = $"Dependente {request.Nome}, cadastrado com sucesso.";
                    return Request.CreateResponse(HttpStatusCode.OK, response);

                }
                catch (Exception e)
                {
                    response.Mensagem = e.Message;
                    return Request.CreateResponse(HttpStatusCode.BadRequest, response);
                }
            }
            else
            {
                response.Mensagem = ObterMensagensDeValidacao(ModelState);
                return Request.CreateResponse(HttpStatusCode.BadRequest, response);
            }
        }

        [Route("atualizar")]
        [HttpPut]
        public HttpResponseMessage Atualizar(DependenteEdicaoRequest request)
        {
            var response = new DependenteEdicaoResponse();

            if (ModelState.IsValid)
            {
                try
                {
                    Dependente d = new Dependente();
                    d.IdDependente = request.IdDependente;
                    d.Nome = request.Nome;
                    d.DataNascimento = request.DataNascimento;
                    d.IdFuncionario = request.IdFuncionario;

                    business.Atualizar(d);

                    response.Mensagem = $"Dependente {request.Nome}, atualizado com sucesso.";
                    return Request.CreateResponse(HttpStatusCode.OK, response);

                }
                catch (Exception e)
                {
                    response.Mensagem = e.Message;
                    return Request.CreateResponse(HttpStatusCode.BadRequest, response);
                }
            }
            else
            {
                response.Mensagem = ObterMensagensDeValidacao(ModelState);
                return Request.CreateResponse(HttpStatusCode.BadRequest, response);
            }
        }


        [Route("excluir")]
        [HttpDelete]
        public HttpResponseMessage Excluir(int id)
        {
            var response = new DependenteExclusaoResponse();

            if (ModelState.IsValid)
            {
                try
                {

                    Dependente d = business.ConsultaPorId(id);
                    business.Excluir(d);


                    response.Mensagem = $"Dependente {d.Nome}, excluído com sucesso.";
                    return Request.CreateResponse(HttpStatusCode.OK, response);


                }
                catch (Exception e)
                {
                    response.Mensagem = e.Message;
                    return Request.CreateResponse(HttpStatusCode.BadRequest, response);
                }
            }
            else
            {
                response.Mensagem = ObterMensagensDeValidacao(ModelState);
                return Request.CreateResponse(HttpStatusCode.BadRequest, response);
            }

        }

        [Route("consultar")]
        [HttpGet]
        public HttpResponseMessage ConsultarTodos()
        {
            List<DependenteConsultaResponse> lista = new List<DependenteConsultaResponse>();

            try
            {
                foreach (Dependente d in business.ConsultaTodos())
                {
                    DependenteConsultaResponse response = new DependenteConsultaResponse();
                    response.Funcionario = new FuncionarioConsultaResponse();

                    response.IdDependente = d.IdDependente;
                    response.Nome = d.Nome;
                    response.DataNascimento = d.DataNascimento;
                    response.IdFuncionario = d.IdFuncionario;
                    response.Funcionario.DataAdmissao = d.Funcionario.DataAdmissao;
                    response.Funcionario.IdFuncionario = d.Funcionario.IdFuncionario;
                    response.Funcionario.Nome = d.Funcionario.Nome;
                    response.Funcionario.Salario = d.Funcionario.Salario;
                    lista.Add(response);
                }

                return Request.CreateResponse(HttpStatusCode.OK, lista);
            }
            catch (Exception)
            {
                //response.Mensagem = e.Message;
                return Request.CreateResponse(HttpStatusCode.BadRequest, lista);
            }
        }


        [Route("consultarporid")] //api/dependente/consultarporid
        [HttpGet] //verbo HTTP GET..
        public HttpResponseMessage ConsultarPorId(int id)
        {
            DependenteConsultaResponse model = new DependenteConsultaResponse();
            model.Funcionario = new FuncionarioConsultaResponse();

            try
            {
                //buscando o funcionário pelo id..
                Dependente d = business.ConsultaPorId(id);
                if (d != null)
                { 
                model.IdDependente = d.IdDependente;
                model.Nome = d.Nome;
                model.DataNascimento = d.DataNascimento;
                model.IdFuncionario = d.IdFuncionario;
                model.Funcionario.DataAdmissao = d.Funcionario.DataAdmissao;
                model.Funcionario.IdFuncionario = d.Funcionario.IdFuncionario;
                model.Funcionario.Nome = d.Funcionario.Nome;
                model.Funcionario.Salario = d.Funcionario.Salario;

                return Request.CreateResponse(HttpStatusCode.OK, model);
                }
                else 
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, model);
                }
            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, model);
            }
        }

        private string ObterMensagensDeValidacao(ModelStateDictionary model)
        {
            List<string> erros = new List<string>();

            foreach (var m in model)
            {
                if (m.Value.Errors.Count > 0)
                {
                    erros.Add(m.Value.Errors.Select(s => s.ErrorMessage).FirstOrDefault());
                }
            }

            return string.Join(",", erros);
        }

    }
}
