using System.ComponentModel.DataAnnotations;

namespace API.Store.Domain.Dtos.Request
{
    public class PedidoUpdateRequest
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O Nome do Cliente é um campo obrigatório")]
        [DataType(DataType.Text)]
        [MinLength(1, ErrorMessage = "O Nome do Cliente é não pode ser vazio")]
        [MaxLength(60, ErrorMessage = "O tamanho máximo do nome do cliente é 60 caracteres")]
        public string NomeCliente { get; set; }

        [Required(ErrorMessage = "O E-mail do Cliente é um campo obrigatório")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage = "O e-mail informado não é valido")]
        [MaxLength(60, ErrorMessage = "O tamanho máximo do email do cliente é 60 caracteres")]
        public string EmailCliente { get; set; }

        public bool Pago { get; set; }

        public List<ItensPedidoUpdateRequest> ItensPedido { get; set; } = new();
    }

    public class ItensPedidoUpdateRequest
    {
        public int Id { get; set; }
        public int IdProduto { get; set; }

        [Required(ErrorMessage = "É obrigatório informar a quantidade do item")]
        [Range(1, long.MaxValue, ErrorMessage = "Por favor insira uma quantidade superior a 0")]
        public int Quantidade { get; set; }

        [Required(ErrorMessage = "O nome do produto é um campo obrigatório")]
        [DataType(DataType.Text)]
        [MinLength(1, ErrorMessage = "O nome do produto não pode ser vazio")]
        [MaxLength(20, ErrorMessage = "O tamanho máximo do nome do produto é 20 caracteres")]
        public string NomeProduto {  get; set; }


        [Required(ErrorMessage = "É obrigatório informar o valor do produto")]
        [Range(1, long.MaxValue, ErrorMessage = "Por favor insira uma quantidade superior a 0")]
        public decimal ValorProduto { get; set; }
    }
}
