using System;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace Hackathon_API.Models
{
    public class Candidato
    {
        public int Id { get; set; }
        [StringLength(60, MinimumLength = 3, ErrorMessage = "O campo Nome deve ter no minimo 3 caracteres.")]
        [Required(ErrorMessage = "O campo Nome � obrigat�rio.")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "O campo Cidade � obrigat�rio.")]
        public string Cidade { get; set; }
        [Range(0,100,ErrorMessage = "A nota deve estar entre 0 e 100")]
        [Required(ErrorMessage = "O campo Nota � obrigat�rio.")]
        public double Nota { get; set; }
        public bool Situacao { get; set; }
    }
}