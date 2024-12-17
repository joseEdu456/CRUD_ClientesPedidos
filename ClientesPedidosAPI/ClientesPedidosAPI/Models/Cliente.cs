using System.ComponentModel.DataAnnotations;

namespace ClientesPedidosAPI.Models;

public class Cliente
{
    public int Id { get; set; }
    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    public string Nome { get; set; }
    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    public string Email { get; set; }
    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    public string Telefone { get; set; }
}