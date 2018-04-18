using infomerc_site.Data; 

namespace infomerc_site.Models.RepositorioEF
{
    public class PostRepositorioEF : Repositorio<Blog_Post>
    {
        public PostRepositorioEF(InfomercContext repo)
            : base(repo)
        {
        }
    }


    public class CategoriaRepositorioEF : Repositorio<Blog_Categoria>
    {
        public CategoriaRepositorioEF(InfomercContext repo)
            : base(repo)
        {
        }
    }

}
