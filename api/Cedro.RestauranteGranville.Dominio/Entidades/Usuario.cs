using QuickyBuy.Dominio.Entidades;

namespace Cedro.RestauranteGranville.Dominio.Entidades
{
    public class Usuario : Entidade
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string SobreNome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }

        public override void Validate()
        {
            LimparMensagensValidacao();

            if(string.IsNullOrEmpty(Nome))
                AdicionarCritica("Crítica - O Usuário deve conter um Nome.");

            if(Nome.Length < 3)
                AdicionarCritica("Crítica - O Nome do Usuário não deve ser menor de 3 caracteres.");

            if(string.IsNullOrEmpty(SobreNome))
                AdicionarCritica("Crítica - O Usuário deve conter um SobreNome.");

            if(SobreNome.Length < 3)
                AdicionarCritica("Crítica - O SobreNome do Usuário não deve ser menor de 3 caracteres.");

            if(string.IsNullOrEmpty(Email))
                AdicionarCritica("Crítica - O Email não foi informado.");

            if(string.IsNullOrEmpty(Senha))
                AdicionarCritica("Crítica - A Senha não foi informada.");

        }
    }
}
