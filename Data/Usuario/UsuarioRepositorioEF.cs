using infomerc_site.Data; 

namespace infomerc_site.Models.RepositorioEF
{
    public class UsuarioRepositorioEF : Repositorio<Usuario>
    {
        public UsuarioRepositorioEF(InfomercContext repo)
            : base(repo)
        {
        }
    }
}
