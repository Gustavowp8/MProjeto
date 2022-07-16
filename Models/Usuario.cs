using System.Collections.Generic;
using System.Linq;

namespace MProjeto.Models
{
    public class Usuario
    {
        public int IdUsuario { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }


         private static List<Usuario> listagem = new List<Usuario>();
         public static IQueryable<Usuario> Listagem
        {
            get
            {
                return listagem.AsQueryable();
            }
        }

        static Usuario()
        {
            Usuario.listagem.Add(
                new Usuario {IdUsuario = 1, Nome = "Gustaff", Email = "gustaff@gamil.com"});

                 Usuario.listagem.Add(
                new Usuario {IdUsuario = 2, Nome = "Augusto", Email = "augusto@gamil.com"});

                 Usuario.listagem.Add(
                new Usuario {IdUsuario = 3, Nome = "Jaquline", Email = "jaqueline@gamil.com"});

                 Usuario.listagem.Add(
                new Usuario {IdUsuario = 4, Nome = "Vitor", Email = "vitor@gamil.com"});

                 Usuario.listagem.Add(
                new Usuario {IdUsuario = 5, Nome = "Gilvania", Email = "gilvania@gamil.com"});

                 Usuario.listagem.Add(
                new Usuario {IdUsuario = 6, Nome = "Juliana", Email = "juliana@gamil.com"});
        }

        public static void Salvar(Usuario usuario)
        {
            var usuarioExistente = Usuario.listagem.Find(u => u.IdUsuario == usuario.IdUsuario);
            if(usuarioExistente != null){
                usuarioExistente.Nome = usuario.Nome;
                usuarioExistente.Email = usuario.Email;
            }
            else
            {
                int maiorId = Usuario.Listagem.Max(u => u.IdUsuario);
                usuario.IdUsuario = maiorId + 1;
                Usuario.listagem.Add(usuario);
            }
        }

        public static bool Excluir(int iDUsuario)
        {
            var usuarioExistente = Usuario.listagem.Find(u => u.IdUsuario == iDUsuario);
            if(usuarioExistente != null){
               return Usuario.listagem.Remove(usuarioExistente);
            }
            return false;
        }
    }

}