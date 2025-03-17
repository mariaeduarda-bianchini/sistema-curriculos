using SistemaCurriculoMVC.Models;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System;
using System.Linq;

namespace SistemaCurriculoMVC.DAO
{
    public class CurriculoDAO
    {
        public void Inserir(CurriculoViewModel curriculo)
        {
            string sql = @"
            INSERT INTO Curriculos (Nome, CPF, Endereco, Telefone, Email, PretensaoSalarial, CargoPretendido, DataNascimento,
                                    Formacao1, Formacao2, Formacao3, Formacao4, Formacao5,
                                    Experiencia1, Experiencia2, Experiencia3,
                                    Idioma1, Idioma2, Idioma3)
            VALUES (@Nome, @CPF, @Endereco, @Telefone, @Email, @PretensaoSalarial, @CargoPretendido, @DataNascimento,
                    @Formacao1, @Formacao2, @Formacao3, @Formacao4, @Formacao5,
                    @Experiencia1, @Experiencia2, @Experiencia3,
                    @Idioma1, @Idioma2, @Idioma3)";

            HelperDAO.ExecutaSQL(sql, CriaParametros(curriculo));
        }

        public void Alterar(CurriculoViewModel curriculo)
        {
            string sql = @"
            UPDATE Curriculos SET 
                Nome = @Nome, CPF = @CPF, Endereco = @Endereco, Telefone = @Telefone, Email = @Email, 
                PretensaoSalarial = @PretensaoSalarial, CargoPretendido = @CargoPretendido, DataNascimento = @DataNascimento,
                Formacao1 = @Formacao1, Formacao2 = @Formacao2, Formacao3 = @Formacao3, Formacao4 = @Formacao4, Formacao5 = @Formacao5,
                Experiencia1 = @Experiencia1, Experiencia2 = @Experiencia2, Experiencia3 = @Experiencia3,
                Idioma1 = @Idioma1, Idioma2 = @Idioma2, Idioma3 = @Idioma3
            WHERE Id = @Id";

            HelperDAO.ExecutaSQL(sql, CriaParametrosComId(curriculo));
        }

        public void Excluir(int id)
        {
            string sql = "DELETE FROM Curriculos WHERE Id = @Id";
            HelperDAO.ExecutaSQL(sql, new SqlParameter[] { new SqlParameter("@Id", id) });
        }

        public List<CurriculoViewModel> Listagem()
        {
            List<CurriculoViewModel> lista = new List<CurriculoViewModel>();
            string sql = "SELECT * FROM Curriculos ORDER BY Id";
            DataTable tabela = HelperDAO.ExecutaSelect(sql, null);
            foreach (DataRow registro in tabela.Rows)
                lista.Add(MontaCurriculo(registro));
            return lista;
        }

        private SqlParameter[] CriaParametros(CurriculoViewModel curriculo)
        {
            return new SqlParameter[]
            {
                new SqlParameter("@Nome", curriculo.Nome),
                new SqlParameter("@CPF", curriculo.CPF),
                new SqlParameter("@Endereco", curriculo.Endereco ?? (object)DBNull.Value),
                new SqlParameter("@Telefone", curriculo.Telefone ?? (object)DBNull.Value),
                new SqlParameter("@Email", curriculo.Email),
                new SqlParameter("@PretensaoSalarial", curriculo.PretensaoSalarial),
                new SqlParameter("@CargoPretendido", curriculo.CargoPretendido ?? (object)DBNull.Value),
                new SqlParameter("@DataNascimento", curriculo.DataNascimento),

                // Formação Acadêmica
                new SqlParameter("@Formacao1", curriculo.Formacao1 ?? (object)DBNull.Value),
                new SqlParameter("@Formacao2", curriculo.Formacao2 ?? (object)DBNull.Value),
                new SqlParameter("@Formacao3", curriculo.Formacao3 ?? (object)DBNull.Value),
                new SqlParameter("@Formacao4", curriculo.Formacao4 ?? (object)DBNull.Value),
                new SqlParameter("@Formacao5", curriculo.Formacao5 ?? (object)DBNull.Value),

                // Experiência Profissional
                new SqlParameter("@Experiencia1", curriculo.Experiencia1 ?? (object)DBNull.Value),
                new SqlParameter("@Experiencia2", curriculo.Experiencia2 ?? (object)DBNull.Value),
                new SqlParameter("@Experiencia3", curriculo.Experiencia3 ?? (object)DBNull.Value),

                // Idiomas
                new SqlParameter("@Idioma1", curriculo.Idioma1 ?? (object)DBNull.Value),
                new SqlParameter("@Idioma2", curriculo.Idioma2 ?? (object)DBNull.Value),
                new SqlParameter("@Idioma3", curriculo.Idioma3 ?? (object)DBNull.Value)
            };
        }

        private SqlParameter[] CriaParametrosComId(CurriculoViewModel curriculo)
        {
            var parametros = CriaParametros(curriculo);
            Array.Resize(ref parametros, parametros.Length + 1);
            parametros[parametros.Length - 1] = new SqlParameter("@Id", curriculo.Id);
            return parametros;
        }

        private CurriculoViewModel MontaCurriculo(DataRow registro)
        {
            return new CurriculoViewModel
            {
                Id = Convert.ToInt32(registro["Id"]),
                Nome = registro["Nome"].ToString(),
                CPF = registro["CPF"].ToString(),
                Endereco = registro["Endereco"] is DBNull ? null : registro["Endereco"].ToString(),
                Telefone = registro["Telefone"] is DBNull ? null : registro["Telefone"].ToString(),
                Email = registro["Email"].ToString(),
                PretensaoSalarial = registro["PretensaoSalarial"] == DBNull.Value ? 0 : Convert.ToDecimal(registro["PretensaoSalarial"]),
                CargoPretendido = registro["CargoPretendido"] is DBNull ? null : registro["CargoPretendido"].ToString(),
                DataNascimento = Convert.ToDateTime(registro["DataNascimento"]),

                // Formação Acadêmica
                Formacao1 = registro["Formacao1"] is DBNull ? null : registro["Formacao1"].ToString(),
                Formacao2 = registro["Formacao2"] is DBNull ? null : registro["Formacao2"].ToString(),
                Formacao3 = registro["Formacao3"] is DBNull ? null : registro["Formacao3"].ToString(),
                Formacao4 = registro["Formacao4"] is DBNull ? null : registro["Formacao4"].ToString(),
                Formacao5 = registro["Formacao5"] is DBNull ? null : registro["Formacao5"].ToString(),

                // Experiência Profissional
                Experiencia1 = registro["Experiencia1"] is DBNull ? null : registro["Experiencia1"].ToString(),
                Experiencia2 = registro["Experiencia2"] is DBNull ? null : registro["Experiencia2"].ToString(),
                Experiencia3 = registro["Experiencia3"] is DBNull ? null : registro["Experiencia3"].ToString(),

                // Idiomas
                Idioma1 = registro["Idioma1"] is DBNull ? null : registro["Idioma1"].ToString(),
                Idioma2 = registro["Idioma2"] is DBNull ? null : registro["Idioma2"].ToString(),
                Idioma3 = registro["Idioma3"] is DBNull ? null : registro["Idioma3"].ToString()
            };
        }

        public CurriculoViewModel Consulta(int id)
        {
            string sql = "SELECT * FROM Curriculos WHERE Id = @Id";
            SqlParameter[] parametros = { new SqlParameter("@Id", id) };

            DataTable tabela = HelperDAO.ExecutaSelect(sql, parametros);

            if (tabela.Rows.Count == 0)
                return null; // Retorna null se não encontrar um currículo com o ID fornecido

            return MontaCurriculo(tabela.Rows[0]); // Converte o resultado em um objeto CurriculoViewModel
        }
    }

}

