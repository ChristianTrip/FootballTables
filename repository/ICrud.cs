
namespace FootballTables.repository;

public interface ICrud<Model, Id>
{
    public void Create(Model model);
    public Model GetById(Id id);
    public List<Model> GetAll();
}