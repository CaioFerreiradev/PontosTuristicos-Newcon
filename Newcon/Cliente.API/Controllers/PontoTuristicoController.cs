using Microsoft.AspNetCore.Mvc;
using Dominio.Entidades;
using PontoTuristicos.API.DTO;
using System;
using System.Data;
using System.Data.SqlClient;
using AcessoBancoDados;
using Dominio.ViewModel;
using System.Collections.Generic;
using System.Text;

namespace Cliente.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PontoTuristicoController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            var listaPontoTuristico = new List<PontoTuristicoViewModel>();
            var sqlServer = new AcessoDadosSqlServer();
            var conexao = sqlServer.CriarConexao();
            string sql = "SELECT * FROM PontoTuristico order by CriadoEm Desc";
            using (var comando = new SqlCommand(sql, conexao))
            {
                SqlDataReader sdr = comando.ExecuteReader();
                while (sdr.Read())
                {
                    listaPontoTuristico.Add(new PontoTuristicoViewModel
                    {
                       Nome = sdr["Nome"].ToString(),
                       Descricao = sdr["Descricao"].ToString(),
                       Logradouro = sdr["Logradouro"].ToString(),
                       Bairro = sdr["Bairro"].ToString(),
                       CriadoEm = (DateTime)sdr["CriadoEm"],
                       EstadoId = (int)sdr["EstadoId"],
                       MunicipioId = (int)sdr["MunicipioId"],
                    });
                }
            }
                return Ok(listaPontoTuristico);
        }
        [HttpGet("/byFilter")]
        public IActionResult GetByFilter([FromQuery]Dominio.Filtros.PontoTuristicoFilter pontoTuristicoFilter)
        {
            var listaPontoTuristico = new List<PontoTuristicoViewModel>();
            var sqlServer = new AcessoDadosSqlServer();
            var conexao = sqlServer.CriarConexao();
            var countFiltros = 0; 
            StringBuilder builder = new StringBuilder ("SELECT * FROM PontoTuristico Where ");
            if (pontoTuristicoFilter.Nome != "")
            {
                countFiltros++;
                builder.Append(" Nome = @Nome;");
            }
            if (pontoTuristicoFilter.Descricao != "")
            {
                countFiltros++;
                builder.Append(" Descricao = @Descricao;");
            }
            if (pontoTuristicoFilter.MunicipioId > 0)
            {
                countFiltros++;
                builder.Append(" MunicipioId = @MunicipioId;");
            }
            if (pontoTuristicoFilter.EstadoId > 0)
            {
                countFiltros++;
                builder.Append(" EstadoId = @EstadoId;");
            }
            var sql = builder.ToString();

            if (countFiltros > 1)

            {   
                var newSql = sql.Replace(";", " and");
                newSql = newSql.Trim().Remove(newSql.Length - 3);
                sql = newSql;
            }
                using (var comando = new SqlCommand(sql, conexao))
            {
                comando.Parameters.AddWithValue("@Nome", pontoTuristicoFilter.Nome);
                comando.Parameters.AddWithValue("@Descricao", pontoTuristicoFilter.Descricao);
                comando.Parameters.AddWithValue("@EstadoId", pontoTuristicoFilter.EstadoId);
                comando.Parameters.AddWithValue("@MunicipioId", pontoTuristicoFilter.MunicipioId);

                SqlDataReader sdr = comando.ExecuteReader();
                while (sdr.Read())
                {
                    listaPontoTuristico.Add(new PontoTuristicoViewModel
                    {
                        Nome = sdr["Nome"].ToString(),
                        Descricao = sdr["Descricao"].ToString(),
                        Logradouro = sdr["Logradouro"].ToString(),
                        Bairro = sdr["Bairro"].ToString(),
                        CriadoEm = (DateTime)sdr["CriadoEm"],
                        EstadoId = (int)sdr["EstadoId"],
                        MunicipioId = (int)sdr["MunicipioId"],
                    });
                }
            }
            return Ok(listaPontoTuristico);
        }
        [HttpPost]
        public IActionResult Post([FromBody] PontoTuristicoDTO pontoTuristico)


        {
            if (pontoTuristico.EstadoId == 0 || pontoTuristico.MunicipioId == 0)
            {
                return BadRequest(" Essa cidade ou estado não encontrado "); 
            }
            var sqlServer = new AcessoDadosSqlServer();
            var conexao = sqlServer.CriarConexao();
            string sql = "INSERT INTO dbo.PontoTuristico(Nome, Descricao, Logradouro, Bairro, EstadoId, MunicipioId) VALUES(@Nome, @Descricao, @Logradouro, @Bairro, @EstadoId, @MunicipioId)";

            using (var comando = new SqlCommand(sql, conexao))

            { 
                comando.Parameters.Add("@Nome", SqlDbType.VarChar, 100).Value = pontoTuristico.Nome;
                comando.Parameters.Add("@Descricao", SqlDbType.VarChar).Value = pontoTuristico.Descricao;
                comando.Parameters.Add("@Logradouro", SqlDbType.VarChar).Value = pontoTuristico.Logradouro;
                comando.Parameters.Add("@Bairro", SqlDbType.VarChar).Value = pontoTuristico.Bairro;
                comando.Parameters.Add("@EstadoId", SqlDbType.Int).Value = pontoTuristico.EstadoId;
                comando.Parameters.Add("@MunicipioId", SqlDbType.Int).Value = pontoTuristico.MunicipioId;
                comando.CommandType = CommandType.Text;
                comando.ExecuteNonQuery();
            }
            return Ok();

        }

    }

}
