using System;

namespace SistemaCurriculoMVC.Models
{
    public class CurriculoViewModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string Endereco { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public decimal PretensaoSalarial { get; set; }
        public string CargoPretendido { get; set; }
        public DateTime DataNascimento { get; set; }

        // Formação Acadêmica (até 5 registros)
        public string Formacao1 { get; set; }
        public string Formacao2 { get; set; }
        public string Formacao3 { get; set; }
        public string Formacao4 { get; set; }
        public string Formacao5 { get; set; }

        // Experiência Profissional (até 3 registros)
        public string Experiencia1 { get; set; }
        public string Experiencia2 { get; set; }
        public string Experiencia3 { get; set; }

        // Idiomas (até 3 registros)
        public string Idioma1 { get; set; }
        public string Idioma2 { get; set; }
        public string Idioma3 { get; set; }
    }
}
