namespace Infrostructure.Services.Interfaces;
using Infrostructure.Models;

    public interface ICassa
    {
        bool CreateCassa(Cassa cassa);
        bool DeleteCassa(int id);
        bool UpdateCassa(Cassa cassa);
        Cassa GetCassaById(int id);
        List<Cassa> GetCassa();
    }
