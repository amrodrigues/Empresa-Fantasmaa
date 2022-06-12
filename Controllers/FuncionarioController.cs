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
    [RoutePrefix("api/funcionario")]
    public class FuncionarioController : ApiController
    {

        private IFuncionarioBusiness business;

        public FuncionarioController(IFuncionarioBusiness business)
        {
            this.business = business;
        }

        [Route("cadastrar")]
        [HttpPost]
        public HttpResponseMessage Cadastrar(FuncionarioCadastroRequest request)
        {
            var response = new FuncionarioCadastroResponse();

            if (ModelState.IsValid)
            {
                try
                {
                    Funcionario f = new Funcionario();
                    f.Nome = request.Nome;
                    f.Salario = request.Salario;
                    f.DataAdmissao = request.DataAdmissao;

                    business.Cadastrar(f);


                    response.Mensagem = $"Funcionário {request.Nome}, cadastrado com sucesso.";
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
                // response.Mensagem = "Ocorreram erros de validação.";
                return Request.CreateResponse(HttpStatusCode.BadRequest, response);
            }

        }

        [Route("atualizar")]
        [HttpPut]

        public HttpResponseMessage Atualizar(FuncionarioEdicaoRequest request)
        {
            var response = new FuncionarioEdicaoResponse();

            if (ModelState.IsValid)
            {
                try
                {
                    Funcionario f = new Funcionario();
                    f.IdFuncionario = request.IdFuncionario;
                    f.Nome = request.Nome;
                    f.Salario = request.Salario;
                    f.DataAdmissao = request.DataAdmissao;

                    business.Atualizar(f);

                    response.Mensagem = $"Funcionário {request.Nome}, atualizado com sucesso.";
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
                //  response.Mensagem = "Ocorreram erros de validação.";
                return Request.CreateResponse(HttpStatusCode.BadRequest, response);
            }
        }


        [Route("excluir")]
        [HttpDelete]
        public HttpResponseMessage Excluir(int id)
        {
            var response = new FuncionarioExlusaoRespose();

            if(ModelState.IsValid)
            {
                try
                {
                    Funcionario f = business.ConsultaPorId(id);
                    business.Excluir(f);

                    response.Mensagem = $"Funcionário {f.Nome}, excluido com sucesso.";
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
                //  response.Mensagem = "Ocorreram erros de validação.";
                return Request.CreateResponse(HttpStatusCode.BadRequest, response);
            }
        }


        [Route("consultar")]
        [HttpGet]
        public HttpResponseMessage ConsultarTodos()
        {
            List<FuncionarioConsultaResponse> lista = new List<FuncionarioConsultaResponse>();
            try
            {
                foreach(Funcionario f in business.ConsultarTodos())
                {

                    FuncionarioConsultaResponse response = new FuncionarioConsultaResponse();
                    response.IdFuncionario = f.IdFuncionario;
                    response.Nome = f.Nome;
                    response.Salario = f.Salario;
                    response.DataAdmissao = f.DataAdmissao;

                    lista.Add(response);
                }
              
                return Request.CreateResponse(HttpStatusCode.OK,lista);
            }
            catch (Exception)
            {
               // lista = e.Message;
                return Request.CreateResponse(HttpStatusCode.BadRequest, lista);
            }
        }

        [Route("consultarporid")] //api/funcionario/consultarporid
        [HttpGet] //verbo HTTP GET..
        public HttpResponseMessage ConsultarPorId(int id)
        {
            FuncionarioConsultaResponse model = new FuncionarioConsultaResponse();

            try
            {
                //buscando o funcionário pelo id..
                Funcionario f = business.ConsultaPorId(id);

                model.IdFuncionario = f.IdFuncionario;
                model.Nome = f.Nome;
                model.Salario = f.Salario;
                model.DataAdmissao = f.DataAdmissao;

                return Request.CreateResponse(HttpStatusCode.OK, model);
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
                    erros.Add(m.Value.Errors.Select

                    (s => s.ErrorMessage).FirstOrDefault());

                }
            }
            return string.Join(",", erros);
        }
    }

}
