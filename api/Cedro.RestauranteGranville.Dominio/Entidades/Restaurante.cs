using QuickyBuy.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cedro.RestauranteGranville.Dominio.Entidades
{
    public class Restaurante : Entidade
    {
        public Restaurante()
        {
            Pratos = new List<Prato>();
        }
        public int Id { get; set; }
        
        public string Nome{ get; set; }
        /// <summary>
        /// Um Restaurante pode ter nenhum ou muitos pratos associados a ele.
        /// </summary>
        public virtual ICollection<Prato> Pratos{ get; set; }

        public override void Validate()
        {
            LimparMensagensValidacao();

            if(string.IsNullOrEmpty(Nome))
                AdicionarCritica("Crítica - O Nome do Restaurante deve estar preenchido.");
        }
    }
}
