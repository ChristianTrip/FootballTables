

namespace FootballTables.services;

public interface ICrud<Model, Id>
{
    public void Create(Model model);
    public Model GetById(Id id);
    public List<Model> GetAll();
    public void Update(Model model);
    public void Delete(Id id);
}