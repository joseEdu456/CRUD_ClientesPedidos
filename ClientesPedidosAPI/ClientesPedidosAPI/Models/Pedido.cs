using System.ComponentModel.DataAnnotations;
using System.Data;

namespace ClientesPedidosAPI.Models;

public class Pedido
{
    public int Id { get; set; }
    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    public int ClienteId { get; set; }
    public DateTime Data { get; private set; }
    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    [Range(1, double.MaxValue, ErrorMessage = "O valor deve ser maior que 0")]
    public decimal ValorTotal { get; set; }

    public Pedido()
    {
        Data = DateTime.Now;
    }
}