﻿using System.ComponentModel.DataAnnotations;

namespace VendasOnline.Dominio.DTOs
{
    public class ItemPedidoDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O ID do produto é obrigatório")]
        public int ProdutoId { get; set; }

        [Required(ErrorMessage = "A quantidade é obrigatória")]
        [Range(1, int.MaxValue, ErrorMessage = "A quantidade deve ser maior que zero")]
        public int Quantidade { get; set; }
    }
}
