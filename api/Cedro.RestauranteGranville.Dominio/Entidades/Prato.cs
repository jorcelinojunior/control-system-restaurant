using QuickyBuy.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cedro.RestauranteGranville.Dominio.Entidades
{
    public class Prato : Entidade
    {
        public int Id { get; set; }
        public int RestauranteId { get; set;}
        public virtual Restaurante Restaurante { get; set; }
        public string Nome { get; set; }
        public decimal Preco { get; set; }

        public override void Validate()
        {
            LimparMensagensValidacao();

            if(string.IsNullOrEmpty(Nome))
                AdicionarCritica("Crítica - O Prato deve conter um Nome.");
            if(Preco < 0)
                AdicionarCritica("Crítica - O Preco não pode estar abaixo de 0(zero).");
        }
    }
}
