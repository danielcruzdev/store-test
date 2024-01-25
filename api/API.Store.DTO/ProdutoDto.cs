using API.Store.Domain.Models;

namespace API.Store.DTO
{
    public class ProdutoDto
    {
        public int Id { get; set; }
        public string NomeProduto { get; set; }
        public decimal Valor { get; set; }

        public static implicit operator Produto(ProdutoDto dto)
        {
            return new Produto 
            { 
                Id = dto.Id, 
                NomeProduto = dto.NomeProduto, 
                Valor = dto.Valor 
            };
        }
    }
}